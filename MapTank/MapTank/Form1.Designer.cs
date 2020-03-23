using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapTank
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        /// 
        List<WallObject> listwalls;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            this.Paint += PntMap;
            listwalls = new List<WallObject>();
            listwalls.Add(new WallObject(new Point(0,0),new Point(0,this.Height)));
            listwalls.Add(new WallObject(new Point(0,0),new Point(this.Width,0)));
            listwalls.Add(new WallObject(new Point(this.Width,0),new Point(this.Width, this.Height)));
            listwalls.Add(new WallObject(new Point(0,this.Height),new Point(this.Width, this.Height)));
          


            
             
          
        }

        private void PntMap(object sender, PaintEventArgs e)
        {
            foreach (var item in listwalls)
            {
                DrawObject(e, item.second, item.first);
            }
        }

        GameHeroObject tank1 = new GameHeroObject();

        int pacStep=5;
        int wallwidth = 0;



        private void DrawObject(PaintEventArgs e,Point second, Point first)
        {
            Pen pen1 = new Pen(Brushes.Black, 10);
            e.Graphics.DrawLine(pen1, first,second);
        }

        private bool CanRightMove()
        {
            bool maperror = false;
            foreach (var item in listwalls)
            {
                if ((tank1.pos.Y + tank1.Height >= item.first.Y && tank1.pos.Y <= item.second.Y) || (item.first.Y == item.second.Y && item.first.Y + wallwidth > tank1.pos.Y && item.first.Y - wallwidth < tank1.pos.Y + tank1.Width))
                {
                    if (tank1.pos.X + tank1.Width <= item.first.X && (tank1.pos.X + tank1.Width + pacStep) >= item.first.X)
                    {
                        maperror = true;
                        break;
                    }
                }

            }
            return maperror;
           


        }

        private bool UpMove()
        {
            bool maperror = false;
            foreach (var item in listwalls)
            {
                if ((tank1.pos.X + tank1.Width >= item.first.X && tank1.pos.X <= item.second.X))
                {
                    if ((tank1.pos.Y >= item.first.Y && (tank1.pos.Y - pacStep) <= item.first.Y))
                    {
                        maperror = true;
                        break;
                    }
                }

                if ((item.first.X == item.second.X && item.second.X + wallwidth > item.first.X && item.second.X - wallwidth < item.first.X + item.first.X))
                {
                    if ((tank1.pos.Y >= item.second.Y && (tank1.pos.Y - pacStep) <= item.second.Y))
                    {
                        maperror = true;
                        break;
                    }
                }

            }
            return maperror;


        }

        private bool DownMove(object sender, PaintEventArgs e)
        {
            bool maperror = false;
            foreach (var item in listwalls)
            {
                if ((tank1.pos.X + tank1.Width >= item.first.X && tank1.pos.X <= item.second.X))
                {
                    if ((tank1.pos.Y + tank1.Height <= item.first.Y && (tank1.pos.Y + tank1.Width + pacStep) >= item.first.Y))
                    {
                        maperror = true;
                        break;
                    }
                }

                if ((item.first.X == item.second.X && item.first.X - wallwidth > tank1.pos.X && item.first.X + wallwidth < tank1.pos.X + tank1.Width))
                {
                    if ((tank1.pos.Y + tank1.Height <= item.first.Y && (tank1.pos.Y + tank1.Height + pacStep) >= item.first.Y))
                    {
                        maperror = true;
                        break;
                    }
                }

            }
            return maperror;
        }


        private bool LeftMove(object sender, PaintEventArgs e)
        {
            bool maperror = false;
            foreach (var item in listwalls)
            {
                if ((tank1.pos.Y + tank1.Height >= item.first.Y && tank1.pos.Y <= item.second.Y) || (item.first.Y == item.second.Y && item.first.Y + 5 > tank1.pos.Y && item.first.Y - 5 < tank1.pos.Y + tank1.Height))
                {
                    if (tank1.pos.X >= item.second.X && (tank1.pos.X - pacStep) <= item.second.X)
                    {
                        maperror = true;
                        break;
                    }
                }

            }
            return maperror;
        }



        #endregion


        class GameHeroObject
        {
            public Point pos { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public GameHeroObject()
            {
                pos = new Point(1, 1);
                Width = 10;
                Height = 10;
            }





        }


        class WallObject
        {
            public Point first;
            public Point second;
            public WallObject()
            {
                first = new Point();
                second = new Point();
            }

            public WallObject(Point first, Point second)
            {
                this.first = new Point(first.X, first.Y);
                this.second = new Point(second.X, second.Y);
            }

        }
    }
}

