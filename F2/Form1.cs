using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lists;
using Collections;

namespace F2
{
    public partial class Form1 : Form
    {
        List S ;
        private int index;
        public Form1()
        {
           
            S = new ArrayList(1);
            InitializeComponent();
            button5.Enabled = false;
        }
        public void setIndex(int index)
        {
            this.index = index;
        }
        public int getIndex()
        {
            return this.index;
        }
        private void button1_Click(object sender, EventArgs e)
        {//เพิ่มข้อมูล
            if (textBox1.Text != "")
            {
                S.add(textBox1.Text);
                textBox1.ResetText();
                label3.Text =     ""+S.size();
                MessageBox.Show("เพิ่มชื่อสำเร็จ");
                button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {//ค้นหาชื่อ
            if (textBox1.Text != "")
            {
                if (S.contains(textBox1.Text) == true)
                {

                    MessageBox.Show("ค้นพบข้อมูล");
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูล");
                    button2.Enabled = false;
                }

                textBox1.ResetText();
                label3.Text = "" + S.size();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {//ลบชื่อ
            if (textBox1.Text != "")
            {
                S.remove(textBox1.Text);
                MessageBox.Show("ลบสำเร็จ");
                label3.Text = "" + S.size();
                textBox1.ResetText();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {//หาจากลำดับ
            if (textBox2.Text != "")
            {
                int a = int.Parse(textBox2.Text);
                setIndex(a);
                textBox3.Text = "" + S.get(a);
                button5.Enabled = true;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {//แก้ไข
         //(textBox3.Text)
            if (textBox3.Text != "")
            {
                S.Set(getIndex(), textBox3.Text);
                textBox2.ResetText();
                textBox3.ResetText();
            }
            MessageBox.Show("แก้ไขชื่อสำเร็จ");
        }
        private void button6_Click(object sender, EventArgs e)
        {///แสดงรายชื่อ
            listView1.Items.Clear();
            for (int i = 0; i < S.size();i++)
            {
                ListViewItem T = new ListViewItem(i.ToString());
                T.SubItems.Add(S.get(i).ToString()) ;
                listView1.Items.Add(T);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
