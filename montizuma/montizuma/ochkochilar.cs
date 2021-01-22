using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace montizuma
{
    public partial class ochkochilar : Form
    {
        private int[] ochko = new int[10];
        private string[] ism = new string[10];
        private string[] vaqt= new string[10];


        int max;
        int ind = -1;
        public ochkochilar()
        {
            InitializeComponent();
        }
        public ochkochilar(int a)
        {
            this.max = a;
           // MessageBox.Show(max.ToString());
            
            
            InitializeComponent();
        }

        private void ochkochilar_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            dateTimePicker1.Visible = false;
            listBox1.Visible = false ;
            button1.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            StreamReader uqish = new StreamReader(Application.StartupPath + "\\ochkolar.txt");
            int i1 = 0;
            while(uqish.Peek()>0)
            {
                ochko[i1] = Convert.ToInt16(uqish.ReadLine());
                i1++;
            }
            uqish.Close();
            StreamReader uqish1 = new StreamReader(Application.StartupPath + "\\ism.txt");

            i1 = 0;
            while (uqish1.Peek() > 0)
            {
                ism[i1] = Convert.ToString(uqish1.ReadLine());
                i1++;
            }
            uqish1.Close();
            // MessageBox.Show(dt.ToShortDateString());
            i1 = 0;
            StreamReader uqish2 = new StreamReader(Application.StartupPath + "\\vaqt.txt");
           while(uqish2.Peek()>0)
           {
               vaqt[i1] = uqish2.ReadLine();
               i1++;

           }
            uqish2.Close();


                if (max >= ochko[ochko.Length - 1])
                {


                    textBox1.Visible = true;
                    button1.Visible = true;
                    label1.Visible = true;
                    // bntniki();
                }
                else {
                    label2.Visible = true;
                    label2.Text = "ochkongiz  " + max.ToString();
                    bntniki(); }
            
        }
        public void bntniki()
        {
            

           
            listBox1.Visible = true;

            for (int i = 0; i < ochko.Length; i++)
            {
                listBox1.Items.Add(ochko[i].ToString()+"       "+ism[i]+"    "+vaqt[i]);
            }
            if (ind != -1)
            {
                listBox1.SetSelected(ind, true);

            }
            StreamWriter yozish = new StreamWriter(Application.StartupPath + "\\ochkolar.txt");
            for (int i = 0; i < ochko.Length; i++)
            {
                yozish.WriteLine(ochko[i].ToString());
            }
            yozish.Close();
            StreamWriter yozish1 = new StreamWriter(Application.StartupPath + "\\ism.txt");
            for (int i = 0; i < ism.Length; i++)
            {
                yozish1.WriteLine(ism[i].ToString());
            }
            yozish1.Close();
            StreamWriter yozish2 = new StreamWriter(Application.StartupPath + "\\vaqt.txt");
            for (int i = 0; i < vaqt.Length; i++)
            {
                yozish2.WriteLine(vaqt[i].ToString());
            }
            yozish2.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DateTime dt;
                dt = dateTimePicker1.Value;
          
                
                if (max >= ochko[ochko.Length - 1])
                {


                    for (int i = 0; i < ochko.Length; i++)
                    {
                        if (ochko[i] < max)
                        {
                            ind = i;
                          
                            for (int j = ochko.Length - 1; j > i; j--)
                            {
                                ochko[j] = ochko[j - 1];
                                ism[j] = ism[j - 1];
                                vaqt[j] = vaqt[j - 1];
                            }
                            ochko[i] = max;
                            ism[i] = textBox1.Text;
                            vaqt[i] = dt.ToString();
                            break;
                        }
                    }
                   
                }
                bntniki();
                button1.Visible = false;
                textBox1.Visible = false;
                label1.Visible = false;
            
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
