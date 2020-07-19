using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sortingAlgorithmVisualizer
{
    public partial class Form1 : Form
    {

        static int elements=100;
        static float gap = 8.016F;
        static float lw =  gap-1;
        static string algo ;
        static int delay=10;
        static int h,w;
        static bool reset = false;
        bool start = false;
        static bool stop = false;
        int[] arr = new int[100000 ];

        Graphics g;
        Pen myPen = new Pen(Color.Turquoise,lw);
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            generateElements();
            h = panel2.Height;
            w = panel2.Width;

        }

        private void swap(int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }




        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
           
            if(reset==true)
            {
                for (int i = 0; i < elements; i++)
                {
                    g.DrawLine(new Pen(Color.Turquoise, lw), (float)i *(gap), h, (float)i *(gap), h - arr[i]);
                  //MessageBox.Show((float)i * (gap)+"");
                }
                reset = false;
            }

           if(start)
            {
                start = false;

                // Bubble sort
                if (algo == "Bubble Sort")
                {
                    for(int i=0; i<elements; i++)
                    {
                        for(int j=0; j<elements-i-1; j++)
                        {
                            g.DrawLine(new Pen(Color.Black, lw), (float)j * gap, h, (float)j * gap, 0);
                            g.DrawLine(new Pen(Color.Black, lw), (float)(j + 1) * gap, h, (float)(j + 1) * gap, 0);
                            g.DrawLine(new Pen(Color.FromArgb(227, 18, 178), lw), (float)j * gap, h, (float)j * gap, h - arr[j]);
                            System.Threading.Thread.Sleep(delay);
                           
                            g.DrawLine(new Pen(Color.FromArgb(227, 18, 178), lw), (float)(j + 1) * gap, h, (float)(j + 1) * gap, h - arr[j + 1]);
                            System.Threading.Thread.Sleep(delay);

                            if (arr[j]>arr[j+1])
                            {
                               
                                g.DrawLine(new Pen(Color.Black, lw), (float)j *gap, h, (float)j *gap, 0);
                                g.DrawLine(new Pen(Color.Black, lw), (float)(j + 1) * gap, h, (float)(j + 1) * gap, 0);

                                g.DrawLine(new Pen(Color.Turquoise, lw), (float)j *gap, h, (float)j *gap, h- arr[j+1]);
                                g.DrawLine(new Pen(Color.Turquoise, lw), (float)(j + 1)*gap, h, (float)(j + 1)*gap, h - arr[j]);
                              

                                swap(j, j + 1);
                            }
                            else
                            {
                              
                                g.DrawLine(new Pen(Color.Turquoise, lw), (float)j * gap, h, (float)j * gap, h - arr[j]);
                      
                                g.DrawLine(new Pen(Color.Turquoise, lw), (float)(j + 1) * gap, h, (float)(j + 1) * gap, h - arr[j + 1]);
                               
                            }
                        }
                    }

                }
                else if(algo=="Insertion Sort")
                {
                    for(int i=1; i<elements; i++)
                    {
                        int key = arr[i];
                        g.DrawLine(new Pen(Color.FromArgb(242, 22, 22), lw), i * gap, h, i * gap, h - arr[i]);
                        System.Threading.Thread.Sleep(delay);
                        int j = i - 1;

                        while (j>=0 && arr[j]>key)
                        {
                            g.DrawLine(new Pen(Color.FromArgb(242, 22, 22), lw), (j+1) * gap, h, (j+1) * gap, h-arr[j]);
                            System.Threading.Thread.Sleep(delay);
                            g.DrawLine(new Pen(Color.Black, lw), (j+1) * gap, h, (j+1) * gap, 0);
             
                            g.DrawLine(new Pen(Color.FromArgb(3, 252, 136), lw), (j+1) * gap, h, (j+1) * gap, h - arr[j]);
                           System.Threading.Thread.Sleep(delay);
                            arr[j + 1] = arr[j];
                            j--;
                        }
                        arr[j+1] = key;
                        g.DrawLine(new Pen(Color.Black, lw), (j+1) * gap, h, (j+1) * gap, 0);
                        g.DrawLine(new Pen(Color.FromArgb(3, 252, 136), lw), (j+1) * gap, h, (j+1) * gap, h - key);
                        System.Threading.Thread.Sleep(delay);
                    }
                }
                else if(algo=="Selection Sort")
                {
                    for(int i=0; i<elements; i++)
                    {
                        int min_ind = i;
                        g.DrawLine(new Pen(Color.FromArgb(242, 22, 22), lw), (float)i * gap, h, (float)i * gap, h - arr[i]);


                        for (int j=i+1; j<elements; j++)
                        {
                            g.DrawLine(new Pen(Color.FromArgb(3, 252, 136), lw), (float)j * gap, h, (float)j * gap, h - arr[j]);
                            System.Threading.Thread.Sleep(delay);
                            g.DrawLine(new Pen(Color.Black, lw), (float)j * gap, h, (float)j * gap, 0);
                            g.DrawLine(new Pen(Color.Turquoise, lw), (float)j * gap, h, (float)j * gap, h - arr[j]);
                            System.Threading.Thread.Sleep(delay);

                            if (arr[j]<arr[min_ind])
                            {
                                min_ind = j;                  
                            }
                        }

                        g.DrawLine(new Pen(Color.Black, lw), (float)i * gap, h, (float)i * gap, 0);
                        g.DrawLine(new Pen(Color.FromArgb(225, 235, 52), lw), (float)i * gap, h, (float)i * gap, h - arr[min_ind]);
                        System.Threading.Thread.Sleep(delay);


                        swap(i, min_ind);

                    }
                }
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            algo = listBox1.Items[listBox1.SelectedIndex].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                elements = Convert.ToInt32(textBox1.Text);

                if (elements < 1)
                    elements = 1;
                gap = w / elements;
                lw = gap - 1;
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Enter number of elements !!");
               
            }

          
        }


        private void generateElements()
        {
            h = panel2.Height;
           

            for (int i=0; i<elements; i++)
            {
                arr[i] = rand.Next(2, h);
               
            }

            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            generateElements();
            reset = true;
            panel2.Invalidate();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            start = true;
            reset = true;
            panel2.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text==null)
            {
                delay = 10;
                comboBox1.Text = "10";
            }
            else
            {
                delay = int.Parse(comboBox1.GetItemText(comboBox1.SelectedItem));
            }
        }


    }
}
