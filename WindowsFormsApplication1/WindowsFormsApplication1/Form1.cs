using CPUScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool firstClick = true;
        bool reset = false;
        bool reset2 = false;
        bool reset3 = false;
        bool reset4 = false;
        double waitingtime;

        //FCFS 
        List<process> fcfs = new List<process>();
        //SJF 
        List<process> sjf = new List<process>();
        //Priority 
        List<process> priority = new List<process>();
        //RR
        List<process> RR = new List<process>();


        //Functions//

        private void enter(TextBox obj, string text)
        {
            if (obj.Text == text)
            {
                obj.Text = "";
                obj.ForeColor = Color.Black;
            }
        }

        private void leave(TextBox obj, string text)
        {
            if (obj.Text == "")
            {
                obj.Text = text;
                obj.ForeColor = Color.DarkGray;
            }
        }
        /*------------------*/

        ///FCFSTAB///
        private void Process_Enter(object sender, EventArgs e)
        {
            enter(ProcessInput, "Process Name...");
        }

        private void Process_Leave(object sender, EventArgs e)
        {
            leave(ProcessInput, "Process Name...");
        }

        private void ArrivalTime_Enter(object sender, EventArgs e)
        {
            enter(ArrivalTime, "Arrival Time...");
        }

        private void ArrivalTime_Leave(object sender, EventArgs e)
        {
            leave(ArrivalTime, "Arrival Time...");
        }

        private void BurstTime_Enter(object sender, EventArgs e)
        {
            enter(BurstTime, "Burst Time...");
        }

        private void BurstTime_Leave(object sender, EventArgs e)
        {
            leave(BurstTime, "Burst Time...");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ProcessInput.Text == "Process Name..." || ArrivalTime.Text == "Arrival Time..." || BurstTime.Text == "Burst Time...")
            {
                MessageBox.Show("Add process info correctly!");
            }
            else if (firstClick)
            {
                if (!reset)
                {
                    tableLayoutPanel1.Controls.Add(new Label() { Text = "Process Name" }, 1, 0);
                    tableLayoutPanel2.Controls.Add(new Label() { Text = "Arrival Time" }, 1, 0);
                    tableLayoutPanel3.Controls.Add(new Label() { Text = "Burst Time" }, 1, 0);
                }
                //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel1.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel1.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                tableLayoutPanel1.Controls.Add(new Label() { Text = ProcessInput.Text }, 1, tableLayoutPanel1.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp2 = tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel2.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel2.RowStyles.Add(new RowStyle(temp2.SizeType, temp2.Height));
                tableLayoutPanel2.Controls.Add(new Label() { Text = ArrivalTime.Text }, 1, tableLayoutPanel2.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp3 = tableLayoutPanel3.RowStyles[tableLayoutPanel3.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel3.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel3.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel3.Controls.Add(new Label() { Text = BurstTime.Text }, 1, tableLayoutPanel3.RowCount - 1);
                /*---------------------*/

                
                fcfs.Add(new process(ProcessInput.Text, Convert.ToDouble(ArrivalTime.Text), Convert.ToDouble(BurstTime.Text)));

                ProcessInput.Text = "Process Name...";
                ProcessInput.ForeColor = Color.DarkGray;
                ArrivalTime.Text = "Arrival Time...";
                ArrivalTime.ForeColor = Color.DarkGray;
                BurstTime.Text = "Burst Time...";
                BurstTime.ForeColor = Color.DarkGray;
                tableLayoutPanel1.Visible = true;
                tableLayoutPanel2.Visible = true;
                tableLayoutPanel3.Visible = true;
                firstClick = false;
                /*---------------------*/

            }
            else
            {
                //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel1.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel1.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                tableLayoutPanel1.Controls.Add(new Label() { Text = ProcessInput.Text }, 1, tableLayoutPanel1.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp2 = tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel2.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel2.RowStyles.Add(new RowStyle(temp2.SizeType, temp2.Height));
                tableLayoutPanel2.Controls.Add(new Label() { Text = ArrivalTime.Text }, 1, tableLayoutPanel2.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp3 = tableLayoutPanel3.RowStyles[tableLayoutPanel3.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel3.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel3.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel3.Controls.Add(new Label() { Text = BurstTime.Text }, 1, tableLayoutPanel3.RowCount - 1);
                /*---------------------*/
                       
                fcfs.Add(new process(ProcessInput.Text, Convert.ToDouble(ArrivalTime.Text), Convert.ToDouble(BurstTime.Text)));

                ProcessInput.Text = "Process Name...";
                ProcessInput.ForeColor = Color.DarkGray;
                ArrivalTime.Text = "Arrival Time...";
                ArrivalTime.ForeColor = Color.DarkGray;
                BurstTime.Text = "Burst Time...";
                BurstTime.ForeColor = Color.DarkGray;
                /*---------------------*/
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            LinkedList<process> output = Algorithms.FCFS(fcfs, out waitingtime);
            Console.WriteLine(waitingtime);
            OSS.Form2 Chart = new OSS.Form2(waitingtime, output);
            Chart.Show();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
           if (fcfs.Count != 0)
            {
                fcfs.Clear();                
                int count = tableLayoutPanel1.RowCount - 1;
                for (int i = count; i > 0; i--)
                {
                    tableLayoutPanel1.Controls.RemoveAt(i);
                    tableLayoutPanel1.RowStyles.RemoveAt(i);
                    tableLayoutPanel1.RowCount--;
                    tableLayoutPanel2.Controls.RemoveAt(i);
                    tableLayoutPanel2.RowStyles.RemoveAt(i);
                    tableLayoutPanel2.RowCount--;
                    tableLayoutPanel3.Controls.RemoveAt(i);
                    tableLayoutPanel3.RowStyles.RemoveAt(i);
                    tableLayoutPanel3.RowCount--;
                }
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel3.Visible = false;
                firstClick = true;
                reset = true;
                
            }
        }

        /*---------------------*/

        ///SJFTAB///
        private void textBox3_Enter(object sender, EventArgs e)
        {
            enter(textBox3, "Process Name...");
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            leave(textBox3, "Process Name...");
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            enter(textBox2, "Arrival Time...");
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            leave(textBox2, "Arrival Time...");
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            enter(textBox1, "Burst Time...");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            leave(textBox1, "Burst Time...");
        }

        private void button3_Click(object sender, EventArgs e) // Add
        {
            if (textBox3.Text == "Process Name..." || textBox2.Text == "Arrival Time..." || textBox1.Text == "Burst Time...")
            {
                MessageBox.Show("Add process info correctly!");
            }
            else if (firstClick)
            {
                if (!reset2)
                {
                    tableLayoutPanel4.Controls.Add(new Label() { Text = "Process Name" }, 1, 0);
                    tableLayoutPanel6.Controls.Add(new Label() { Text = "Arrival Time" }, 1, 0);
                    tableLayoutPanel5.Controls.Add(new Label() { Text = "Burst Time" }, 1, 0);
                }
                //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel4.RowStyles[tableLayoutPanel4.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel4.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel4.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                tableLayoutPanel4.Controls.Add(new Label() { Text = textBox3.Text }, 1, tableLayoutPanel4.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp2 = tableLayoutPanel6.RowStyles[tableLayoutPanel6.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel6.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel6.RowStyles.Add(new RowStyle(temp2.SizeType, temp2.Height));
                tableLayoutPanel6.Controls.Add(new Label() { Text = textBox2.Text }, 1, tableLayoutPanel6.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp3 = tableLayoutPanel5.RowStyles[tableLayoutPanel5.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel5.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel5.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel5.Controls.Add(new Label() { Text = textBox1.Text }, 1, tableLayoutPanel5.RowCount - 1);
                /*---------------------*/
                
                sjf.Add(new process(textBox3.Text, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox1.Text)));

                textBox3.Text = "Process Name...";
                textBox3.ForeColor = Color.DarkGray;
                textBox2.Text = "Arrival Time...";
                textBox2.ForeColor = Color.DarkGray;
                textBox1.Text = "Burst Time...";
                textBox1.ForeColor = Color.DarkGray;
                tableLayoutPanel4.Visible = true;
                tableLayoutPanel6.Visible = true;
                tableLayoutPanel5.Visible = true;
                firstClick = false;
                /*---------------------*/

            }
            else
            {
                //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel4.RowStyles[tableLayoutPanel4.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel4.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel4.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                tableLayoutPanel4.Controls.Add(new Label() { Text = textBox3.Text }, 1, tableLayoutPanel4.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp2 = tableLayoutPanel6.RowStyles[tableLayoutPanel6.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel6.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel6.RowStyles.Add(new RowStyle(temp2.SizeType, temp2.Height));
                tableLayoutPanel6.Controls.Add(new Label() { Text = textBox2.Text }, 1, tableLayoutPanel6.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp3 = tableLayoutPanel5.RowStyles[tableLayoutPanel5.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel5.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel5.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel5.Controls.Add(new Label() { Text = textBox1.Text }, 1, tableLayoutPanel5.RowCount - 1);
                /*---------------------*/

                sjf.Add(new process(textBox3.Text, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox1.Text)));

                textBox3.Text = "Process Name...";
                textBox3.ForeColor = Color.DarkGray;
                textBox2.Text = "Arrival Time...";
                textBox2.ForeColor = Color.DarkGray;
                textBox1.Text = "Burst Time...";
                textBox1.ForeColor = Color.DarkGray;
                tableLayoutPanel4.Visible = true;
                tableLayoutPanel6.Visible = true;
                tableLayoutPanel5.Visible = true;
                firstClick = false;
                /*---------------------*/
            }
        }

        private void button2_Click(object sender, EventArgs e) // Start
        {
            LinkedList<process> output = new LinkedList<process>();
            if (radioButton1.Checked) // Preemptive
            {
                output = Algorithms.Preemptive_SJF(sjf, out waitingtime);
                Console.WriteLine(waitingtime);
                OSS.Form2 Chart = new OSS.Form2(waitingtime, output);
                Chart.Show();
            }
            else if (radioButton2.Checked) // Non Preemptive 
            {
                output = Algorithms.NonPreemptive_SJF(sjf, out waitingtime);
                Console.WriteLine(waitingtime);
                OSS.Form2 Chart = new OSS.Form2(waitingtime, output);
                Chart.Show();
            }
            else
            {
                MessageBox.Show("Select Preemptive or Non Preemptive!");
            }
        }

        private void button1_Click(object sender, EventArgs e) // Reset
        {
            if (sjf.Count != 0)
            {
                sjf.Clear();
                
                int count = tableLayoutPanel4.RowCount - 1;
                for (int i = count; i > 0; i--)
                {
                    tableLayoutPanel4.Controls.RemoveAt(i);
                    tableLayoutPanel4.RowStyles.RemoveAt(i);
                    tableLayoutPanel4.RowCount--;
                    tableLayoutPanel6.Controls.RemoveAt(i);
                    tableLayoutPanel6.RowStyles.RemoveAt(i);
                    tableLayoutPanel6.RowCount--;
                    tableLayoutPanel5.Controls.RemoveAt(i);
                    tableLayoutPanel5.RowStyles.RemoveAt(i);
                    tableLayoutPanel5.RowCount--;
                }
                tableLayoutPanel4.Visible = false;
                tableLayoutPanel6.Visible = false;
                tableLayoutPanel5.Visible = false;
                firstClick = true;
                reset2 = true;
                /*---------------------*/
            }
        }

        /*---------------------*/

        ///PRIORITYTAB///

        private void textBox6_Enter(object sender, EventArgs e)
        {
            enter(textBox6, "Process Name...");
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            leave(textBox6, "Process Name...");
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            enter(textBox5, "Arrival Time...");
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            leave(textBox5, "Arrival Time...");
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            enter(textBox4, "Burst Time...");
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            leave(textBox4, "Burst Time...");
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            enter(textBox7, "Priority...");
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            leave(textBox7, "Priority...");
        }

        private void button6_Click(object sender, EventArgs e) // Add
        {
            if (textBox6.Text == "Process Name..." || textBox5.Text == "Arrival Time..." || textBox4.Text == "Burst Time..." || textBox7.Text == "Priority...")
            {
                MessageBox.Show("Add process info correctly!");
            }
            else if (firstClick)
            {
                if (!reset3)
                {
                    tableLayoutPanel7.Controls.Add(new Label() { Text = "Process Name" }, 1, 0);
                    tableLayoutPanel9.Controls.Add(new Label() { Text = "Arrival Time" }, 1, 0);
                    tableLayoutPanel8.Controls.Add(new Label() { Text = "Burst Time" }, 1, 0);
                    tableLayoutPanel10.Controls.Add(new Label() { Text = "Priority" }, 1, 0);
                }
                //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel7.RowStyles[tableLayoutPanel7.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel7.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel7.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                tableLayoutPanel7.Controls.Add(new Label() { Text = textBox6.Text }, 1, tableLayoutPanel7.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp2 = tableLayoutPanel9.RowStyles[tableLayoutPanel9.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel9.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel9.RowStyles.Add(new RowStyle(temp2.SizeType, temp2.Height));
                tableLayoutPanel9.Controls.Add(new Label() { Text = textBox5.Text }, 1, tableLayoutPanel9.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp3 = tableLayoutPanel8.RowStyles[tableLayoutPanel8.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel8.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel8.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel8.Controls.Add(new Label() { Text = textBox4.Text }, 1, tableLayoutPanel8.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                temp3 = tableLayoutPanel10.RowStyles[tableLayoutPanel10.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel10.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel10.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel10.Controls.Add(new Label() { Text = textBox7.Text }, 1, tableLayoutPanel10.RowCount - 1);
                /*---------------------*/

                priority.Add(new process(textBox6.Text, Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox4.Text), Convert.ToInt32(textBox7.Text)));

                textBox6.Text = "Process Name...";
                textBox6.ForeColor = Color.DarkGray;
                textBox5.Text = "Arrival Time...";
                textBox5.ForeColor = Color.DarkGray;
                textBox4.Text = "Burst Time...";
                textBox4.ForeColor = Color.DarkGray;
                textBox7.Text = "Priority...";
                textBox7.ForeColor = Color.DarkGray;
                tableLayoutPanel7.Visible = true;
                tableLayoutPanel9.Visible = true;
                tableLayoutPanel8.Visible = true;
                tableLayoutPanel10.Visible = true;
                firstClick = false;
                /*---------------------*/

            }
            else
            {
                //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel7.RowStyles[tableLayoutPanel7.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel7.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel7.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                tableLayoutPanel7.Controls.Add(new Label() { Text = textBox6.Text }, 1, tableLayoutPanel7.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp2 = tableLayoutPanel9.RowStyles[tableLayoutPanel9.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel9.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel9.RowStyles.Add(new RowStyle(temp2.SizeType, temp2.Height));
                tableLayoutPanel9.Controls.Add(new Label() { Text = textBox5.Text }, 1, tableLayoutPanel9.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp3 = tableLayoutPanel8.RowStyles[tableLayoutPanel8.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel8.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel8.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel8.Controls.Add(new Label() { Text = textBox4.Text }, 1, tableLayoutPanel8.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                temp3 = tableLayoutPanel10.RowStyles[tableLayoutPanel10.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel10.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel10.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel10.Controls.Add(new Label() { Text = textBox7.Text }, 1, tableLayoutPanel10.RowCount - 1);
                /*---------------------*/

                priority.Add(new process(textBox6.Text, Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox4.Text), Convert.ToInt32(textBox7.Text)));

                textBox6.Text = "Process Name...";
                textBox6.ForeColor = Color.DarkGray;
                textBox5.Text = "Arrival Time...";
                textBox5.ForeColor = Color.DarkGray;
                textBox4.Text = "Burst Time...";
                textBox4.ForeColor = Color.DarkGray;
                textBox7.Text = "Priority...";
                textBox7.ForeColor = Color.DarkGray;
                tableLayoutPanel7.Visible = true;
                tableLayoutPanel9.Visible = true;
                tableLayoutPanel8.Visible = true;
                tableLayoutPanel10.Visible = true;
                firstClick = false;
                /*---------------------*/
            }
        }

        private void button5_Click(object sender, EventArgs e) // Start
        {
            LinkedList<process> output = new LinkedList<process>();
            if (radioButton4.Checked) // Preemptive
            {
                output = Algorithms.Preemptive_Priority(priority, out waitingtime);
                Console.WriteLine(waitingtime);
                OSS.Form2 Chart = new OSS.Form2(waitingtime, output);
                Chart.Show();
            }
            else if (radioButton3.Checked) // Non Preemptive 
            {
                output = Algorithms.NonPreemptive_Priority(priority, out waitingtime);
                Console.WriteLine(waitingtime);
                OSS.Form2 Chart = new OSS.Form2(waitingtime, output);
                Chart.Show();
            }
            else
            {
                MessageBox.Show("Select Preemptive or Non Preemptive!");
            }
        }

        private void button4_Click(object sender, EventArgs e) // Reset
        {
            if (priority.Count != 0)
            {
                priority.Clear();

                int count = tableLayoutPanel7.RowCount - 1;
                for (int i = count; i > 0; i--)
                {
                    tableLayoutPanel7.Controls.RemoveAt(i);
                    tableLayoutPanel7.RowStyles.RemoveAt(i);
                    tableLayoutPanel7.RowCount--;
                    tableLayoutPanel9.Controls.RemoveAt(i);
                    tableLayoutPanel9.RowStyles.RemoveAt(i);
                    tableLayoutPanel9.RowCount--;
                    tableLayoutPanel8.Controls.RemoveAt(i);
                    tableLayoutPanel8.RowStyles.RemoveAt(i);
                    tableLayoutPanel8.RowCount--;
                    tableLayoutPanel10.Controls.RemoveAt(i);
                    tableLayoutPanel10.RowStyles.RemoveAt(i);
                    tableLayoutPanel10.RowCount--;
                }
                tableLayoutPanel7.Visible = false;
                tableLayoutPanel9.Visible = false;
                tableLayoutPanel8.Visible = false;
                tableLayoutPanel10.Visible = false;
                firstClick = true;
                reset3 = true;
                /*---------------------*/
            }
        }
        
        /*---------------------*/

        ///ROUNDROBINTAB///
       
        private void textBox11_Enter(object sender, EventArgs e)
        {
            enter(textBox11, "Process Name...");
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            leave(textBox11, "Process Name...");
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            enter(textBox10, "Arrival Time...");
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            leave(textBox10, "Arrival Time...");
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            enter(textBox9, "Burst Time...");
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            leave(textBox9, "Burst Time...");
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            enter(textBox8, "Quantum...");
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            leave(textBox8, "Quantum...");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "Process Name..." || textBox10.Text == "Arrival Time..." || textBox9.Text == "Burst Time...")
            {
                MessageBox.Show("Add process info correctly!");
            }
            else if (firstClick)
            {
                if (!reset4)
                {
                    tableLayoutPanel12.Controls.Add(new Label() { Text = "Process Name" }, 1, 0);
                    tableLayoutPanel14.Controls.Add(new Label() { Text = "Arrival Time" }, 1, 0);
                    tableLayoutPanel13.Controls.Add(new Label() { Text = "Burst Time" }, 1, 0);
                }
                //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel12.RowStyles[tableLayoutPanel12.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel12.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel12.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                tableLayoutPanel12.Controls.Add(new Label() { Text = textBox11.Text }, 1, tableLayoutPanel12.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp2 = tableLayoutPanel14.RowStyles[tableLayoutPanel14.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel14.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel14.RowStyles.Add(new RowStyle(temp2.SizeType, temp2.Height));
                tableLayoutPanel14.Controls.Add(new Label() { Text = textBox10.Text }, 1, tableLayoutPanel14.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp3 = tableLayoutPanel13.RowStyles[tableLayoutPanel13.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel13.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel13.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel13.Controls.Add(new Label() { Text = textBox9.Text }, 1, tableLayoutPanel13.RowCount - 1);
                /*---------------------*/

                RR.Add(new process(textBox11.Text, Convert.ToDouble(textBox10.Text), Convert.ToDouble(textBox9.Text)));

                textBox11.Text = "Process Name...";
                textBox11.ForeColor = Color.DarkGray;
                textBox10.Text = "Arrival Time...";
                textBox10.ForeColor = Color.DarkGray;
                textBox9.Text = "Burst Time...";
                textBox9.ForeColor = Color.DarkGray;
                tableLayoutPanel12.Visible = true;
                tableLayoutPanel13.Visible = true;
                tableLayoutPanel14.Visible = true;
                firstClick = false;
                /*---------------------*/

            }
            else
            {
                //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel12.RowStyles[tableLayoutPanel12.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel12.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel12.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                tableLayoutPanel12.Controls.Add(new Label() { Text = textBox11.Text }, 1, tableLayoutPanel12.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp2 = tableLayoutPanel14.RowStyles[tableLayoutPanel14.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel14.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel14.RowStyles.Add(new RowStyle(temp2.SizeType, temp2.Height));
                tableLayoutPanel14.Controls.Add(new Label() { Text = textBox10.Text }, 1, tableLayoutPanel14.RowCount - 1);
                /*---------------------*/
                //get a reference to the previous existent 
                RowStyle temp3 = tableLayoutPanel13.RowStyles[tableLayoutPanel13.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel13.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel13.RowStyles.Add(new RowStyle(temp3.SizeType, temp3.Height));
                tableLayoutPanel13.Controls.Add(new Label() { Text = textBox9.Text }, 1, tableLayoutPanel13.RowCount - 1);
                /*---------------------*/

                RR.Add(new process(textBox11.Text, Convert.ToDouble(textBox10.Text), Convert.ToDouble(textBox9.Text)));

                textBox11.Text = "Process Name...";
                textBox11.ForeColor = Color.DarkGray;
                textBox10.Text = "Arrival Time...";
                textBox10.ForeColor = Color.DarkGray;
                textBox9.Text = "Burst Time...";
                textBox9.ForeColor = Color.DarkGray;
                tableLayoutPanel12.Visible = true;
                tableLayoutPanel13.Visible = true;
                tableLayoutPanel14.Visible = true;
                firstClick = false;
                /*---------------------*/
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double q = Convert.ToDouble(textBox8.Text);
            LinkedList<process> output = Algorithms.RoundRobin(q, RR, out waitingtime);
            Console.WriteLine(waitingtime);
            OSS.Form2 Chart = new OSS.Form2(waitingtime, output);
            Chart.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (RR.Count != 0)
            {
                RR.Clear();

                int count = tableLayoutPanel7.RowCount - 1;
                for (int i = count; i > 0; i--)
                {
                    tableLayoutPanel12.Controls.RemoveAt(i);
                    tableLayoutPanel12.RowStyles.RemoveAt(i);
                    tableLayoutPanel12.RowCount--;
                    tableLayoutPanel13.Controls.RemoveAt(i);
                    tableLayoutPanel13.RowStyles.RemoveAt(i);
                    tableLayoutPanel13.RowCount--;
                    tableLayoutPanel14.Controls.RemoveAt(i);
                    tableLayoutPanel14.RowStyles.RemoveAt(i);
                    tableLayoutPanel14.RowCount--;
                }
                tableLayoutPanel12.Visible = false;
                tableLayoutPanel13.Visible = false;
                tableLayoutPanel14.Visible = false;
                firstClick = true;
                reset4 = true;
                /*---------------------*/
            }
            }

        /*---------------------*/
    }
}

