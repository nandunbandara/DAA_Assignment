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
using System.Threading;

namespace daa
{
    public partial class Main : MetroForm
    {

        private MetroTile tile1;
        private MetroTile tile2;
        private Algorithm algo;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbAlgorithm.SelectedIndex = 0;
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
                    dgvAlgo.Rows.Add("for j <- 2 to length[A]");
                    dgvAlgo.Rows.Add("      do key <- A[j]");
                    dgvAlgo.Rows.Add("              i <- j – 1");
                    dgvAlgo.Rows.Add("              While i > 0 and A[i] > key");
                    dgvAlgo.Rows.Add("                      do  A[i+1] <- A[i]");
                    dgvAlgo.Rows.Add("                              i <- i - 1");
                    dgvAlgo.Rows.Add("                      A[i+1] <- key");
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
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
                int[] arr = new int[] { Convert.ToInt32(txt0.Text),
                                    Convert.ToInt32(txt1.Text),
                                    Convert.ToInt32(txt2.Text),
                                    Convert.ToInt32(txt3.Text),
                                    Convert.ToInt32(txt4.Text),
                                    Convert.ToInt32(txt5.Text),
                                    Convert.ToInt32(txt6.Text),
                                    Convert.ToInt32(txt7.Text),
                                    Convert.ToInt32(txt8.Text),
                                    Convert.ToInt32(txt9.Text),
                                   };
                this.algo = new Algorithm(lbl0, lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8, lbl9);
                algo.Grid = dgvAlgo;
                algo.InsertionSort(arr);

            }

        }
        

    }
}
