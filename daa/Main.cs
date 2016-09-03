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
            //lbl2.Style = MetroFramework.MetroColorStyle.Red;
            delay = 2000;
            this.arr = new MetroTile[] { lbl0, lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblI.Text = null;
            lblJ.Text = null;
            cmbAlgorithm.SelectedIndex = 0;
            lblKey.Visible = true;
            lblKeyBtn.Visible = true;
            dgvAlgo.Rows[0].Selected = false;
            lblStepsBubble.Visible = false;
            lblDescriptionBubble.Visible = false;
            btnReset.Enabled = false;
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
                    lblStepsBubble.Visible = false;
                    lblDescriptionBubble.Visible = false;
                    break;
                case 1:
                    dgvAlgo.Rows.Clear();
                    dgvAlgo.Rows.Add("for j <- 1 to length[A]");
                    dgvAlgo.Rows.Add("do");
                    dgvAlgo.Rows.Add("      for i <- 1 to length[A] - 1");
                    dgvAlgo.Rows.Add("      do");
                    dgvAlgo.Rows.Add("              if a[i] > a[i + 1]");
                    dgvAlgo.Rows.Add("              do swap(a[i], a[i + 1])");
              
                    lblKeyBtn.Visible = false;
                    lblKey.Visible = false;
                    lblStepsInsert.Visible = false;
                    lblStepsBubble.Visible = true;
                    lblDescriptionBubble.Visible = true;
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
                //ctrlEnabled(false);
                //txt0.Enabled = false;
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
        private void ctrlEnabled(bool val)
        {
            if (val)
            {
                txt0.Enabled = true;
                txt1.Enabled = true;
                txt2.Enabled = true;
                txt3.Enabled = true;
                txt4.Enabled = true;
                txt5.Enabled = true;
                txt6.Enabled = true;
                txt7.Enabled = true;
                txt8.Enabled = true;
                txt9.Enabled = true;
                trck.Enabled = true;
                cmbAlgorithm.Enabled = true;
                btnRandom.Enabled = true;
                btnSort.Enabled = true;
                this.arr = new MetroTile[] { };
                txt0.Text = null;
                txt1.Text = null;
                txt2.Text = null;
                txt3.Text = null;
                txt4.Text = null;
                txt5.Text = null;
                txt6.Text = null;
                txt7.Text = null;
                txt8.Text = null;
                txt9.Text = null;
            }
            else
            { 
                txt0.Enabled = false;
                //lbl0.Refresh();
                txt1.Enabled = false;
                txt2.Enabled = false;
                txt3.Enabled = false;
                txt4.Enabled = false;
                txt5.Enabled = false;
                txt6.Enabled = false;
                txt7.Enabled = false;
                txt8.Enabled = false;
                txt9.Enabled = false;
                trck.Enabled = false;
                cmbAlgorithm.Enabled = false;
                btnRandom.Enabled = false;
                btnSort.Enabled = false;
            }
        }

        private async void InsertionSort()
        {
            btnReset.Enabled = false;
            btnSort.Enabled = false;
            for (int j = 1; j < this.arr.Length; j++)
            {
                setJ(j+1);   
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
                setI(i+1);
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
                    setI(i + 1);
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
            btnReset.Enabled = true;
            complete();
        }

        private async void BubbleSort()
        {
            btnReset.Enabled = false;
            int length = arr.Length;
            for(int j = 0; j < length; j++)
            {
                setJ(j+1);
                dgvAlgo.Rows[0].Selected = true;
                await Task.Delay(delay);
                dgvAlgo.Rows[0].Selected = false;

                int i;
                for(i=1;i<length; i++)
                {
                    
                    arr[i-1].Style = MetroFramework.MetroColorStyle.Red;
                    arr[i-1].Refresh();
                    
                    arr[i].Style = MetroFramework.MetroColorStyle.Red;
                    arr[i].Refresh();
                    
                    setI(i);
                    dgvAlgo.Rows[2].Selected = true;
                    await Task.Delay(delay);
                    dgvAlgo.Rows[2].Selected = false;
                    arr[i - 1].Style = MetroFramework.MetroColorStyle.Silver;
                    arr[i - 1].Refresh();
                    arr[i].Style = MetroFramework.MetroColorStyle.Silver;
                    arr[i].Refresh();
                    if (Convert.ToInt32(arr[i].Text) < Convert.ToInt32(arr[i - 1].Text)) { 
                        arr[i - 1].Style = MetroFramework.MetroColorStyle.Blue;
                        arr[i].Style = MetroFramework.MetroColorStyle.Blue;
                        arr[i - 1].Refresh();
                        arr[i].Refresh();
                        dgvAlgo.Rows[5].Selected = true;
                        await Task.Delay(delay);
                        exchange(arr[i-1], arr[i]);
                        await Task.Delay(4000);
                        dgvAlgo.Rows[5].Selected = false;
                        arr[i - 1].Style = MetroFramework.MetroColorStyle.Silver;
                        arr[i].Style = MetroFramework.MetroColorStyle.Silver;
                        arr[i - 1].Refresh();
                        arr[i].Refresh();
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
            btnReset.Enabled = true;
            complete();
        }

        private void setIJ(int i, int j)
        {
            setI(i);
            setJ(j);
        }

        private void setI(int i)
        {
            this.lblI.Text = i.ToString();
        }

        private void setJ(int j)
        {
            this.lblJ.Text = j.ToString();
        }

        private void complete()
        {
            lbl0.Style = MetroFramework.MetroColorStyle.Lime;
            lbl1.Style = MetroFramework.MetroColorStyle.Lime;
            lbl2.Style = MetroFramework.MetroColorStyle.Lime;
            lbl3.Style = MetroFramework.MetroColorStyle.Lime;
            lbl4.Style = MetroFramework.MetroColorStyle.Lime;
            lbl5.Style = MetroFramework.MetroColorStyle.Lime;
            lbl6.Style = MetroFramework.MetroColorStyle.Lime;
            lbl7.Style = MetroFramework.MetroColorStyle.Lime;
            lbl8.Style = MetroFramework.MetroColorStyle.Lime;
            lbl9.Style = MetroFramework.MetroColorStyle.Lime;
            lbl0.Refresh();
            lbl1.Refresh();
            lbl2.Refresh();
            lbl3.Refresh();
            lbl4.Refresh();
            lbl5.Refresh();
            lbl6.Refresh();
            lbl7.Refresh();
            lbl8.Refresh();
            lbl9.Refresh();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            ctrlEnabled(true);
            lbl0.Style = MetroFramework.MetroColorStyle.Lime;
            lbl1.Style = MetroFramework.MetroColorStyle.Lime;
            lbl2.Style = MetroFramework.MetroColorStyle.Lime;
            lbl3.Style = MetroFramework.MetroColorStyle.Lime;
            lbl4.Style = MetroFramework.MetroColorStyle.Lime;
            lbl5.Style = MetroFramework.MetroColorStyle.Lime;
            lbl6.Style = MetroFramework.MetroColorStyle.Lime;
            lbl7.Style = MetroFramework.MetroColorStyle.Lime;
            lbl8.Style = MetroFramework.MetroColorStyle.Lime;
            lbl9.Style = MetroFramework.MetroColorStyle.Lime;
            lbl0.Refresh();
            lbl1.Refresh();
            lbl2.Refresh();
            lbl3.Refresh();
            lbl4.Refresh();
            lbl5.Refresh();
            lbl6.Refresh();
            lbl7.Refresh();
            lbl8.Refresh();
            lbl9.Refresh();
        }
    }
}
