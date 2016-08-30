using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace daa
{
    public class Algorithm
    {
        public MetroGrid Grid { get; set; }
        public MetroTile tile1 { get; set; }
        public MetroTile tile2 { get; set; }

        private Timer timerUpTile1;
        private Timer timerUpTile2;
        private Timer timerMoveTile1;
        private Timer timerMoveTile2;
        private Timer timerDownTile1;
        private Timer timerDownTile2;
        private int coordX1;
        private int coordX2;

        private MetroTile t0;
        private MetroTile t1;
        private MetroTile t2;
        private MetroTile t3;
        private MetroTile t4;
        private MetroTile t5;
        private MetroTile t6;
        private MetroTile t7;
        private MetroTile t8;
        private MetroTile t9;

        public MetroTile lblKey { get; set; }
        private int[] arr;
        private MetroTile[] arrM;
        public Algorithm()
        {
            lblKey = new MetroTile();
            this.t0 = new MetroTile();
            this.t1 = new MetroTile();
            this.t2 = new MetroTile();
            this.t3 = new MetroTile();
            this.t4 = new MetroTile();
            this.t5 = new MetroTile();
            this.t6 = new MetroTile();
            this.t7 = new MetroTile();
            this.t8 = new MetroTile();
            this.t9 = new MetroTile();
            arrM = new MetroTile[] { t0, t1, t2, t3, t4, t5, t6, t7, t8, t9 };
        }
        public Algorithm(MetroTile t0, MetroTile t1, MetroTile t2, MetroTile t3, MetroTile t4,
                        MetroTile t5, MetroTile t6, MetroTile t7, MetroTile t8, MetroTile t9)
        {
            new Algorithm();
            this.t0 = t0;
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
            this.t4 = t4;
            this.t5 = t5;
            this.t6 = t6;
            this.t7 = t7;
            this.t8 = t8;
            this.t9 = t9;

            this.tile1 = t0;
            this.tile2 = t1;
        }

        public async void InsertionSort(int[] arr)
        {
            this.arr = arr;
            //set timer
            
            for (int j = 1; j < arr.Length; j++)
            {
                int key = arr[j];
                int i = j - 1;
                while (i >= 0 && arr[i] > key)
                {
                    arr[i + 1] = arr[i];
                    exchange(i);
                    await Task.Delay(6000);           
                    i--;
                    //System.Threading.Thread.Sleep(200);
                }
                arr[i + 1] = key;
            }

            for (int i = 0; i < arr.Length - 1; i++)
                Console.WriteLine(arr[i]);
        }

        public async void InsertionSort()
        {

            //set array
            //arrM{ t0, t1, t2, t3, t4, t5, t6, t7, t8, t9 };
            
            for (int j = 1; j < this.arrM.Length; j++)
            { 
                MetroTile key = arrM[j];
                lblKey.Text = arrM[j].Text;
                lblKey.Style = MetroFramework.MetroColorStyle.Red;
                arrM[j].Style = MetroFramework.MetroColorStyle.Red;
                arrM[j].Style = MetroFramework.MetroColorStyle.Red;
                int i = j - 1;
                int n1 = Convert.ToInt32(arrM[i].Text);
                int n2 = Convert.ToInt32(key.Text);
                while (i >= 0 && n1 > n2)
                {
                    //exchange(arr[i], arr[i + 1]);
                    arr[i + 1] = arr[i];
                    i--;
                    n1 = Convert.ToInt32(arrM[i + 1].Text);
                    //System.Threading.Thread.Sleep(200);
                }
                //exchange(arr[i + 1], key);
                arrM[i + 1] = key;
                await Task.Delay(2000);
            }

            for (int i = 0; i < arr.Length - 1; i++)
                Console.WriteLine(arrM[i].Text);
        }


        public void exchange(int i)
        {
            switch (i)
            {
                case 0:
                    tile1 = t0;
                    tile2 = t1;
                    break;
                case 1:
                    tile1 = t1;
                    tile2 = t2;
                    break;
                case 2:
                    tile1 = t2;
                    tile2 = t3;
                    break;
                case 3:
                    tile1 = t3;
                    tile2 = t4;
                    break;
                case 4:
                    tile1 = t4;
                    tile2 = t5;
                    break;
            }
            this.coordX1 = tile1.Location.X;
            this.coordX2 = tile2.Location.X;

            this.timerUpTile1 = new Timer();
            timerUpTile1.Interval = 15;
            timerUpTile1.Tick += new EventHandler(timerUpTile1_Tick);

            this.timerUpTile2 = new Timer();
            timerUpTile2.Interval = 15;
            timerUpTile2.Tick += new EventHandler(timerUpTile2_Tick);

            this.timerMoveTile1 = new Timer();
            timerMoveTile1.Interval = 15;
            timerMoveTile1.Tick += new EventHandler(timerMoveTile1_Tick);

            this.timerMoveTile2 = new Timer();
            timerMoveTile2.Interval = 15;
            timerMoveTile2.Tick += new EventHandler(timerMoveTile2_Tick);

            this.timerDownTile1 = new Timer();
            timerDownTile1.Interval = 15;
            timerDownTile1.Tick += new EventHandler(timerDownTile1_Tick);

            this.timerDownTile2 = new Timer();
            timerDownTile2.Interval = 15;
            timerDownTile2.Tick += new EventHandler(timerDownTile2_Tick);

            timerUpTile1.Start();
            timerUpTile2.Start();
            

        }
        public void exchange(MetroTile tile1, MetroTile tile2)
        {
            this.tile1 = tile1;
            this.tile2 = tile2;
            MetroTile temp;

            if (tile1.Location.X > tile2.Location.X)
            {
                temp = tile2;
                tile2 = tile1;
                tile1 = temp;
            }

            this.coordX1 = tile1.Location.X;
            this.coordX2 = tile2.Location.X;

            this.timerUpTile1 = new Timer();
            timerUpTile1.Interval = 15;
            timerUpTile1.Tick += new EventHandler(timerUpTile1_Tick);

            this.timerUpTile2 = new Timer();
            timerUpTile2.Interval = 15;
            timerUpTile2.Tick += new EventHandler(timerUpTile2_Tick);

            this.timerMoveTile1 = new Timer();
            timerMoveTile1.Interval = 15;
            timerMoveTile1.Tick += new EventHandler(timerMoveTile1_Tick);

            this.timerMoveTile2 = new Timer();
            timerMoveTile2.Interval = 15;
            timerMoveTile2.Tick += new EventHandler(timerMoveTile2_Tick);

            this.timerDownTile1 = new Timer();
            timerDownTile1.Interval = 15;
            timerDownTile1.Tick += new EventHandler(timerDownTile1_Tick);

            this.timerDownTile2 = new Timer();
            timerDownTile2.Interval = 15;
            timerDownTile2.Tick += new EventHandler(timerDownTile2_Tick);

            timerUpTile1.Start();
            timerUpTile2.Start();


        }

        void timerUpTile1_Tick(object sender, EventArgs e)
        {
            if (tile1.Location.Y > 150) tile1.SetBounds(tile1.Location.X, tile1.Location.Y - 1, tile1.Width, tile1.Height);
            else
            {
                timerUpTile1.Stop();
                timerMoveTile1.Start();
            }
        }

        void timerUpTile2_Tick(object sender, EventArgs e)
        {
            if (tile2.Location.Y > 210) tile2.SetBounds(tile2.Location.X, tile2.Location.Y - 1, tile2.Width, tile2.Height);
            else timerUpTile2.Stop();
        }

        void timerMoveTile1_Tick(object sender, EventArgs e)
        {
            if (tile1.Location.X < coordX2)
            {
                timerMoveTile2.Start();
                tile1.SetBounds(tile1.Location.X + 1, tile1.Location.Y, tile1.Width, tile1.Height);
            }
            else
            {
                timerMoveTile1.Stop();
                timerDownTile1.Start();
            }
        }

        void timerMoveTile2_Tick(object sender, EventArgs e)
        {
            if (tile2.Location.X > coordX1) tile2.SetBounds(tile2.Location.X - 1, tile2.Location.Y, tile2.Width, tile2.Height);
            else
            {
                timerMoveTile2.Stop();
                timerDownTile2.Start();
            }
        }

        void timerDownTile1_Tick(object sender, EventArgs e)
        {
            if (tile1.Location.Y < 281) tile1.SetBounds(tile1.Location.X, tile1.Location.Y + 1, tile1.Width, tile1.Height);
            else timerDownTile1.Stop();
               
        }

        void timerDownTile2_Tick(object sender, EventArgs e)
        {
            if (tile2.Location.Y < 281) tile2.SetBounds(tile2.Location.X, tile2.Location.Y + 1, tile2.Width, tile2.Height);
            else timerDownTile2.Stop();
        }
        
    }
}
