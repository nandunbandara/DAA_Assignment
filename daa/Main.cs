using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;


namespace daa
{
    public partial class Main : MetroForm
    {

        private MetroTile tile1;
        private MetroTile tile2;
        private Algorithm algo;
        private MetroTile[] arr;
        private int delay;

        private Timer timerUpTile1;
        private Timer timerUpTile2;
        private Timer timerMoveTile1;
        private Timer timerMoveTile2;
        private Timer timerDownTile1;
        private Timer timerDownTile2;
        private int coordX1;
        private int coordX2;
        public Main()
        {
            InitializeComponent();
            this.arr = new MetroTile[] { lbl0, lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9 };
            //lbl2.Style = MetroFramework.MetroColorStyle.Red;
            delay = 2000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbAlgorithm.SelectedIndex = 0;
            lblKey.Visible = true;
            lblKeyBtn.Visible = true;
            dgvAlgo.Rows[0].Selected = false;

            delay = (trck.Value / 10) * 400;
            lblSpeed.Text = (delay / 1000).ToString() + " seconds";
        }

        private void txt0_TextChanged(object sender, EventArgs e)
        {
            lbl0.Text = txt0.Text;
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            lbl1.Text = txt1.Text;
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            lbl2.Text = txt2.Text;
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            lbl3.Text = txt3.Text;
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            lbl4.Text = txt4.Text;
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            lbl5.Text = txt5.Text;
        }

        private void txt6_TextChanged(object sender, EventArgs e)
        {
            lbl6.Text = txt6.Text;
        }

        private void txt7_TextChanged(object sender, EventArgs e)
        {
            lbl7.Text = txt7.Text;
        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {
            lbl8.Text = txt8.Text;
        }

        private void txt9_TextChanged(object sender, EventArgs e)
        {
            lbl9.Text = txt9.Text;
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            txt0.Text = rand.Next(0, 100).ToString();
            txt1.Text = rand.Next(0, 100).ToString();
            txt2.Text = rand.Next(0, 100).ToString();
            txt3.Text = rand.Next(0, 100).ToString();
            txt4.Text = rand.Next(0, 100).ToString();
            txt5.Text = rand.Next(0, 100).ToString();
            txt6.Text = rand.Next(0, 100).ToString();
            txt7.Text = rand.Next(0, 100).ToString();
            txt8.Text = rand.Next(0, 100).ToString();
            txt9.Text = rand.Next(0, 100).ToString();
        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbAlgorithm.SelectedIndex)
            {
                case 0:
                    dgvAlgo.Rows.Clear();
                    dgvAlgo.Rows.Add("for j <- 2 to length[A]");
                    dgvAlgo.Rows.Add("      do key <- A[j]");
                    dgvAlgo.Rows.Add("              i <- j – 1");
                    dgvAlgo.Rows.Add("              While i > 0 and A[i] > key");
                    dgvAlgo.Rows.Add("                      do  A[i+1] <- A[i]");
                    dgvAlgo.Rows.Add("                              i <- i - 1");
                    dgvAlgo.Rows.Add("                      A[i+1] <- key");
                    dgvAlgo.Rows[0].Selected = false;
                    lblKeyBtn.Visible = true;
                    lblKey.Visible = true;
                    lblStepsInsert.Visible = true;
                    break;
                case 1:
                    dgvAlgo.Rows.Clear();
                    lblKeyBtn.Visible = false;
                    lblKey.Visible = false;
                    lblStepsInsert.Visible = false;
                    
                    break;
                case 2:
                    lblKeyBtn.Visible = false;
                    lblKey.Visible = false;
                    break;
                case 3:
                    lblKeyBtn.Visible = false;
                    lblKey.Visible = false;
                    break;
            }
        }

        

        private void btnSort_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(txt0.Text) || String.IsNullOrEmpty(txt1.Text) ||
               String.IsNullOrEmpty(txt2.Text) || String.IsNullOrEmpty(txt3.Text) ||
               String.IsNullOrEmpty(txt4.Text) || String.IsNullOrEmpty(txt5.Text) ||
               String.IsNullOrEmpty(txt6.Text) || String.IsNullOrEmpty(txt7.Text) ||
               String.IsNullOrEmpty(txt8.Text) || String.IsNullOrEmpty(txt9.Text))
                MessageBox.Show("Enter all 10 values or click on 'Randomize' to generate random values");
            else
            {
                btnRandom.Enabled = false;
                // create array
                /*int[] arr = new int[] { Convert.ToInt32(txt0.Text),
                                    Convert.ToInt32(txt1.Text),
                                    Convert.ToInt32(txt2.Text),
                                    Convert.ToInt32(txt3.Text),
                                    Convert.ToInt32(txt4.Text),
                                    Convert.ToInt32(txt5.Text),
                                    Convert.ToInt32(txt6.Text),
                                    Convert.ToInt32(txt7.Text),
                                    Convert.ToInt32(txt8.Text),
                                    Convert.ToInt32(txt9.Text),
                                   };*/

                this.algo = new Algorithm(lbl0, lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9);
                algo.Grid = dgvAlgo;
                switch (cmbAlgorithm.SelectedIndex)
                {
                    case 0:
                        InsertionSort();
                        break;
                    case 1:
                        BubbleSort();
                        break;
                }

            }

        }

        private async void InsertionSort()
        { 
            for (int j = 1; j < this.arr.Length; j++)
            { 
                dgvAlgo.Rows[0].Selected = true;
                //
                await Task.Delay(delay);
                dgvAlgo.Rows[0].Selected = false;
                dgvAlgo.Rows[1].Selected = true;
                MetroTile key = arr[j];
                lblKeyBtn.Text = arr[j].Text;
                arr[j].Style = MetroFramework.MetroColorStyle.Red;
                arr[j].Refresh();
                lblKeyBtn.Style = MetroFramework.MetroColorStyle.Red;
                lblDescription.Text = "KEY value is set to " + lblKeyBtn.Text + " (index " + j + ")";
                await Task.Delay(delay);
                dgvAlgo.Rows[1].Selected = false;
                dgvAlgo.Rows[2].Selected = true;
                int i = j - 1;
                lblDescription.Text = "i is set to " + i;
                await Task.Delay(delay);
                dgvAlgo.Rows[2].Selected = false;
                dgvAlgo.Rows[3].Selected = true;
                //lblDescription.Text 
                if (i < 0) lblDescription.Text = "i = -1 Hence i>=0 condition is false";
                else if (Convert.ToInt32(arr[i].Text) < Convert.ToInt32(lblKeyBtn.Text))
                    lblDescription.Text = "Value at index "+ i +" is less than that at index "+(i+1)+".";
                else lblDescription.Text = "i is greater than 0 and the value at "+
                        "index " + i + " is greater than that at index " + (i + 1) + ".";
                await Task.Delay(delay);
                dgvAlgo.Rows[3].Selected = false;
                while (i >= 0 && Convert.ToInt32(arr[i].Text) > Convert.ToInt32(lblKeyBtn.Text))
                { 
                    lblDescription.Text = null;
                    dgvAlgo.Rows[4].Selected = true;
                    lblDescription.Text = "COPY " + arr[i].Text + " to the index "+(i+1);
                    arr[i].Style = MetroFramework.MetroColorStyle.Blue;
                    arr[i].Refresh();
                    arr[i + 1].Text = arr[i].Text;
                    await Task.Delay(delay);
                    dgvAlgo.Rows[4].Selected = false;
                    arr[i].Style = MetroFramework.MetroColorStyle.Lime;
                    i--;
                    lblDescription.Text = "i is set to " + i;
                    dgvAlgo.Rows[5].Selected = true;
                    await Task.Delay(delay);
                    dgvAlgo.Rows[5].Selected = false;
                    arr[j].Style = MetroFramework.MetroColorStyle.Lime;
                    arr[j].Refresh();
                }
                dgvAlgo.Rows[6].Selected = true;
                lblDescription.Text = "Copy KEY value to index " + (i + 1);
                arr[i + 1].Style = MetroFramework.MetroColorStyle.Red;
                arr[i + 1].Refresh();
                arr[i + 1].Text = lblKeyBtn.Text;
                await Task.Delay(delay);
                arr[i + 1].Style = MetroFramework.MetroColorStyle.Lime;
                arr[i + 1].Refresh();
                dgvAlgo.Rows[6].Selected = false;
                arr[j].Style = MetroFramework.MetroColorStyle.Lime;
                arr[j].Refresh();
                prg.Value = j * 10;
            }
            lbl9.Style = MetroFramework.MetroColorStyle.Lime;
            lbl9.Refresh();
            for (int i = 0; i < arr.Length - 1; i++)
                Console.WriteLine(arr[i].Text);
            prg.Value = 100;
            await Task.Delay(1000);
            prg.Value = 0;
        }

        private async void BubbleSort()
        {
            int length = arr.Length;
            for(int j = 0; j < length; j++)
            {
                int i;
                for(i=1;i<length; i++)
                {
                    if (Convert.ToInt32(arr[i].Text) < Convert.ToInt32(arr[i - 1].Text)){
                        exchange(arr[i-1], arr[i]);
                        await Task.Delay(4000);
                        MetroTile temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                    }
                }
                arr[i-1].Style = MetroFramework.MetroColorStyle.Lime;
                arr[i - 1].Refresh();
                prg.Value = (j+1) * 10;
                length--;
            }
            await Task.Delay(100);
            for (int i = 0; i < arr.Length - 1; i++)
                Console.WriteLine(arr[i].Text);
            prg.Value = 100;
            await Task.Delay(1000);
            prg.Value = 0;
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        { 
            delay = (trck.Value / 10) * 400;
            lblSpeed.Text = (delay / 1000).ToString() + " seconds";
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
            //timerMoveTile2.Start();


        }

        void timerUpTile1_Tick(object sender, EventArgs e)
        {
            if (tile1.Location.Y > 268) tile1.SetBounds(tile1.Location.X, tile1.Location.Y - 1, tile1.Width, tile1.Height);
            else
            {
                timerUpTile1.Stop();
                timerMoveTile1.Start();
                timerMoveTile2.Start();
            }
        }

        void timerUpTile2_Tick(object sender, EventArgs e)
        {
            if (tile2.Location.Y > 180) tile2.SetBounds(tile2.Location.X, tile2.Location.Y - 1, tile2.Width, tile2.Height);
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
            if (tile1.Location.Y < 319) tile1.SetBounds(tile1.Location.X, tile1.Location.Y + 1, tile1.Width, tile1.Height);
            else timerDownTile1.Stop();

        }

        void timerDownTile2_Tick(object sender, EventArgs e)
        {
            if (tile2.Location.Y < 319) tile2.SetBounds(tile2.Location.X, tile2.Location.Y + 1, tile2.Width, tile2.Height);
            else timerDownTile2.Stop();
        }
    }
}
