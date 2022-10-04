using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Collections;

namespace CW1
{
    public partial class Form1 : Form
    {
        Collection ax ;
        private int num = 3   ;
        public Form1()
        {
            InitializeComponent();
            switch (num)
            {
                case 1 : ax = new ArrayCollection(1);
                    label2.Text = "ArayCollection";break;
                case 2 : ax = new LinkedCollection();
                    label2.Text = "LinkedCollection";break;
                case 3 : ax = new LinkedHeaderCollection();
                    label2.Text = "LinkedHeaderCollection"; break;
                default: ax = new ArrayCollection(1);
                    label2.Text = "ArayCollection"; break;                      
            }
            label1.Text = "Size : " + ax.size();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") 
            {
                ax.add(textBox1.Text);
                MessageBox.Show("เพิ่มสำเร็จ");

                textBox1.ResetText();
                label1.Text = "Size : " + ax.size();
            }           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if(ax.contains(textBox2.Text) == true)
                {
                    MessageBox.Show("ค้นพบข้อมูล");
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูล");
                }

                textBox2.ResetText();
                label1.Text = "Size :  " + ax.size();
            }
                        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                ax.remove(textBox3.Text);
                MessageBox.Show("ลบสำเร็จ");

                textBox3.ResetText();
                label1.Text = "Size : " + ax.size() ;
            }            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
