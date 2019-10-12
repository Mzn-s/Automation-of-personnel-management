using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Vxod : Form
    {
       public static string a12;
        public Vxod()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не выбрали информационную базу!!!");
            }
            else
            {
                Person f1 = new Person();
            f1.Show();
            Hide();
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не выбрали информационную базу!!!");
            }
            else
            {
                Zarplata f2 = new Zarplata();
                f2.Show();
                Hide();
            }
        }

        private void Vxod_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
      "Вас приветствует программа, предназначенная для автоматизации управления персоналом. Для начала работы выберите информационную базу и нажмите одну из кнопок, перейдя на рабоую форму. " +
      "Удачи!",
      "Справка", MessageBoxButtons.OK, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();           
            openFileDialog1.Filter = "Для данных (*.xml)|*.xml";         
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            textBox1.Text = (openFileDialog1.FileName);
                            a12 = (openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

    }
}



