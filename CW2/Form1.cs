using Lists;
using Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CW2
{
    public partial class Form1 : Form
    {
        List x;
        public Form1()
        {
            InitializeComponent();
            x = new ArrayList(1);
            button5.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // เพิ่มข้อมูล
        {
            if (textBox1.Text != "")
            {
                x.add(textBox1.Text);
                MessageBox.Show("เพิ่มสำเร็จ");

                textBox1.ResetText();
                label1.Text = "Size : " + x.size();
            }
        }

        private void button2_Click(object sender, EventArgs e)// ค้นหาชื่อ
        {
            if (textBox2.Text != "")
            {
                if (x.contains(textBox2.Text) == true)
                {
                    MessageBox.Show("ค้นพบข้อมูล");
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูล");
                }

                textBox1.ResetText();
                label1.Text = "Size :  " + x.size();
            }
        }

        private void button3_Click(object sender, EventArgs e) // ลบ
        {
            if (textBox1.Text != "")
            {
                x.remove(textBox1.Text);
                MessageBox.Show("ลบสำเร็จ");

                textBox1.ResetText();
                label1.Text = "Size : " + x.size();
            }
        }
    }
}
