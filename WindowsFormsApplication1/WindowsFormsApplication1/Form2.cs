using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSS
{
    public partial class Form2 : Form
    {


        LinkedList<process> FinalList;

        private void DrawIt(LinkedList<process> Final)
        {


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //process[] pp = new process[FinalList.Count];
            //FinalList.CopyTo(pp, 0);
            //double totalburst = 0.0;
            //double[] wait = new double[FinalList.Count];
            //wait[0] = 0;
            //int i = 0;
            //bool first = false;

            panel1.Width = 80 * FinalList.Count;
            panel1.AutoScroll = true;
            int x = 0;
            int y = 0;
            int x2 = 25;
            int y2 = 25;
            foreach (process process in FinalList)
            {
                string drawString = process.getName();
                Console.WriteLine(drawString);
                System.Drawing.Font drawFont = new System.Drawing.Font("Times New Roman", 14);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkRed);
                System.Drawing.Graphics graphics = panel1.CreateGraphics();
                System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(x, y, 80, 80);
                graphics.DrawString(drawString, drawFont, drawBrush, x2, y2);
                //if (!first)
                //{
                    //graphics.DrawString(Convert.ToString(process.getArrival()), drawFont, drawBrush, 1, 50);
                //}
                //if (first)
                //{
                    //totalburst += pp[i - 1].getBurst();
                    //if (totalburst < pp[i].getArrival())
                    //{
                        //wait[i] = 0.0;
                    //}
                    //else
                    //{
                        //wait[i] = totalburst - pp[i].getArrival();
                    //}
                //}
                //tring time = Convert.ToString(process.getTotal() + wait[i]);
                //i++;
                //first = true;
                //graphics.DrawString(time, drawFont, drawBrush, x2 + 32, 50);
                x = x + 80;
                x2 = x2 + 80;
                graphics.DrawRectangle(System.Drawing.Pens.Black, rectangle);
            }
        }
        public Form2(double waitingtime, LinkedList<process> Final)
        {
            InitializeComponent();

            label1.Text = "Average Waiting Time is : " + waitingtime.ToString() + " ms";
            FinalList = Final;
            panel1.Paint += new PaintEventHandler(panel1_Paint);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void panel1_Resize(object sender, EventArgs e)
        {
            //panel1.Paint += new PaintEventHandler(panel1_Paint);

        }
    }
}
