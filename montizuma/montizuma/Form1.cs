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
    public partial class Form1 : Form
    {
        private int[,] s;
        Random ra = new Random();

        Color[] rang = { Color.Red, Color.Green, Color.Yellow, Color.Blue };
        private int ulcham = 25;
        private string[] joyi;
        private int n,max1=0;
        private int ochko = 0,max=50,lev=1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        public void yacheyka()
        {
            s=new int[10,10];
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            Pen p = new Pen(Color.Black, 3);

            int a = 0, b = 0;
            for(int i=0;i<10;i++)
            {
                b = 0;
                for(int j=0;j<10;j++)
                {
                   // b += 10;
                    Point n1 = new Point(b, a);
                    Point n2 = new Point(b, a+ulcham);
                    Point n3 = new Point(b+ulcham, a+ulcham);
                    Point n4 = new Point(b+ulcham, a);
                    b += ulcham;
                    int q = ra.Next(0, 4);
                    Point[] nuqta = { n1, n2, n3, n4 };
                    Point[] nuqta1 = { n1, n2, n3, n4,n1 };

                    SolidBrush br=new SolidBrush(rang[q]);
                    g.FillPolygon(br, nuqta);
                    g.DrawLines(p, nuqta1);
                    s[i, j] = q;


                }
                a += ulcham;
            }
            SolidBrush qizil = new SolidBrush(Color.Red);
            System.Drawing.Font font1 = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            g.DrawString("level "+lev.ToString(), font1, qizil, 10, 260);

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
           // yacheyka();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           // MessageBox.Show(e.X.ToString() + "  " + e.Y.ToString());
            if (timer2.Enabled == true)
            {
                if (e.X <= 250 && e.Y <= 250)
                {
                    uchirish(e.Y / ulcham, e.X / ulcham);

                }
            }

        }
        public void uchirish(int x,int y)
        {
            try
            {
                n = 1;
                int n1 = n;
                string ss = "";
                ss= (x * 10 + y).ToString();
                joyi = new string[n];
                int d = s[x, y];
                int k = 0;
                joyi[k] = ss;
            nishon:
                int a = Convert.ToInt16(ss) / 10;
            int b = Convert.ToInt16(ss) % 10;

                rangolish(d, a, b);
                qisqartirish();
                if(k<n)
                {
                    ss = joyi[k]; k++; goto nishon;    
                }
               
                //for (int i = 0; i < n; i++)
                //{
                //    MessageBox.Show(joyi[i]);
                //}
                if (n > 2)
                {
                    ochko += 2*n;
                    oqqabuyash();
                    ochkosi();
                    surish();
                    
                }
            }
            catch(Exception ex) { MessageBox.Show("yacheykadan chiqib ketti"+ex.ToString()); }
        }
        public void ochkosi()
        {
            Graphics g = this.CreateGraphics();

            SolidBrush oq = new SolidBrush(Color.White);
            SolidBrush kuk = new SolidBrush(Color.Blue);
            


            Point p1 = new Point(60, 280);
            Point p2 = new Point(60, 320);
            Point p3 = new Point(250, 320);
            Point p4 = new Point(250, 280);
            Point[] pp = { p1, p2, p3, p4 };
            System.Drawing.Font font = new System.Drawing.Font("Arial", 30, System.Drawing.FontStyle.Bold);


            System.Drawing.Font font1 = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

            g.DrawString("ochko:", font1, kuk, 10, 290);
           // if (ochko > max)
            { max += 25;
            max1 += ochko;
           // ochko = 0;
            
            Point p11 = new Point(10, 260);
            Point p21 = new Point(10,280 );
            Point p31 = new Point(120, 280);
            Point p41 = new Point(120, 260);
            Point[] pp1 = { p11, p21, p31, p41 };
            g.FillPolygon(oq, pp1);
           
         //   progressBar1.Maximum += 10;
           // lev++;
           // SolidBrush qizil = new SolidBrush(Color.Red);

           // g.DrawString("level " + lev.ToString(), font1, qizil, 10, 260);
         //   progressBar1.Value = 0;
            //timer2.Enabled = false;
            //timer2.Enabled = true;

           // timer2_Tick(sender, e);
            
            }
            g.FillPolygon(oq, pp);
            g.DrawString(ochko.ToString(), font, kuk, 60, 280);



        }
        public void rangolish(int d,int x,int y)
        {
            int j = 1, k = 0,g=0 ;
            //o'nga
            nishon:
            k = y + j;
            if (k < 10)
            {
                if (s[x, k] == d)
                {
                    g = 1;
                    joyigajoylash(x, k);

                }
            }
                if (g == 1) { g = 0; j++; goto nishon; }
                j = 1; g = 0;
            //chapga
            nishon1:
                k = y - j;
            if (k >= 0)
            {
                if (s[x, k] == d)
                {
                    g = 1;
                    joyigajoylash(x, k);

                }
            }
                if (g == 1 ) { g = 0; j++; goto nishon1; }
            //tepaga
                j = 1; g = 0;

            nishon2:
                k = x + j;
                if (k < 10)
                {
                    if (s[k, y] == d)
                    {
                        g = 1;
                        joyigajoylash(k, y);

                    }
                }
            if (g == 1) { g = 0; j++; goto nishon2; }

            j = 1; g = 0;
        //pastga
        nishon3:
            k = x - j;
            if (k >= 0)
            {
                if (s[k, y] == d)
                {
                    g = 1;
                    joyigajoylash(k, y);

                }
            }
            if (g == 1) { g = 0; j++; goto nishon3; }
            


          
        }
        public void joyigajoylash(int x,int k)
        {
           
            string[] b = new string[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = joyi[i];
            }
            n++;
            joyi = new string[n];
            for (int i = 0; i < n - 1; i++)
            {
                joyi[i] = b[i];
            }
            joyi[n - 1] = (x * 10 + k).ToString();
        }
        public void qisqartirish()
        {
            string[] b = new string[n];
            int k=0;
            for(int i=0;i<n;i++)
            {
                int g = 0;
                for(int j=0;j<i;j++)
                {
                    if (joyi[i] == b[j]) { g = 1; break; }
                }
                if(g==0)
                {
                    b[k] = joyi[i]; k++;
                }
            }
            n = k;
            joyi = new string[n];
                for(int i=0;i<n;i++)
                {
                    joyi[i] = b[i];
                }
           

        }
        public void oqqabuyash()
        {
           // int[,] vek = new int[n,n];
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 3);

            for(int i=0;i<n;i++)
            {
                int a = Convert.ToInt16(joyi[i]) / 10;
                int b = Convert.ToInt16(joyi[i]) % 10;
                s[a, b] =-1;
               // vek[a, b] = 0;
                Point n1 = new Point(b*ulcham, a*ulcham);
                Point n2 = new Point(b*ulcham, a*ulcham + ulcham);
                Point n3 = new Point(b*ulcham + ulcham, a*ulcham + ulcham);
                Point n4 = new Point(b*ulcham + ulcham, a*ulcham);
              //  b += ulcham;
                //int q = ra.Next(0, 4);
                Point[] nuqta = { n1, n2, n3, n4 };
                Point[] nuqta1 = { n1, n2, n3, n4, n1 };

                SolidBrush br = new SolidBrush(Color.White);
                g.FillPolygon(br, nuqta);
               g.DrawLines(p, nuqta1);
                    
 
            }
        }
        public void surish()
        {
            timer1.Interval = 100;
            

            for (int f = 0; f < 10;f++ )
            {
               
           
                timer1.Enabled = true;
              //  timer1.Tick += EventHandler(timer1_Tick);
             //  this.timer1_Tick(sender, e);

                }
           
        }
        public void buyash(int a,int b,int c)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 3);
            Color buy;
           // int ttt = 0;
            if (c == -1)
            {  buy = Color.White; }
            else {  buy = rang[c]; }
               
                // vek[a, b] = 0;
                Point n1 = new Point(b * ulcham, a * ulcham);
                Point n2 = new Point(b * ulcham, a * ulcham + ulcham);
                Point n3 = new Point(b * ulcham + ulcham, a * ulcham + ulcham);
                Point n4 = new Point(b * ulcham + ulcham, a * ulcham);
                //  b += ulcham;
                //int q = ra.Next(0, 4);
                Point[] nuqta = { n1, n2, n3, n4 };
                Point[] nuqta1 = { n1, n2, n3, n4, n1 };

                SolidBrush br = new SolidBrush(buy);
                g.FillPolygon(br, nuqta);
                g.DrawLines(p, nuqta1);


            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 9; i > 0; i--)
            {
                for (int i1 = 0; i1 < 10; i1++)
                {
                    if (s[0, i1] == -1)
                    { s[0, i1] = ra.Next(0, 4); buyash(0, i1, s[0, i1]); }
                    // MessageBox.Show(s[0, i].ToString());
                }
                
                for (int j = 0; j < 10; j++)
                {
                    if (s[i, j] == -1)
                    {
                        if (s[i - 1, j] != -1)
                        {
                           // MessageBox.Show("");
                            int t = s[i, j]; s[i, j] = s[i - 1, j]; s[i - 1, j] = t;
                            buyash(i, j, s[i, j]);
                            buyash(i - 1, j, s[i - 1, j]);


                        }
                    }
                    

                }
               
            }
            //timer1.Enabled = false;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 1600;
            max1 = 0;
            ochko = 0;
            progressBar1.Visible = true;
            lev = 1; max = 50;

            progressBar1.Value = 0;
            timer2.Enabled = true;
            yacheyka();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value += 1;
            }
            catch { timer2.Enabled = false;
            progressBar1.Visible = false;
            over();            
            }
        }
        public void over()
        {
            Graphics g = this.CreateGraphics();
           // g.Clear(Color.Yellow);
            SolidBrush qizil = new SolidBrush(Color.Black);
            System.Drawing.Font font1 = new System.Drawing.Font("Arial", 50, System.Drawing.FontStyle.Bold);

            g.DrawString("game over", font1, qizil, 0, 120);
            ochkochilar och = new ochkochilar(ochko);
            this.Hide();
            och.ShowDialog();
            this.Show();
           
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }





    }
}
