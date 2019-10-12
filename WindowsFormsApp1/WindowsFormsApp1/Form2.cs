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
using System.Resources;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        static public string a; static public string b; static public string c; static public string d; static public string e1; static public string f;
        static public string g; static public string h; static public string i; static public string j; static public string k; static public string m;
        static public string n; static public string o; static public string p; static public string q; static public string w; static public string z;
        static public string a1; public static string base64String; static public int proverka; 
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
         this.ControlBox = false;

  

        }
        private void button1_Click(object sender, EventArgs e)
        {
            {
                Bitmap image; //Bitmap для открываемого изображения

                OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
                open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
                {
                    try
                    {
                        image = new Bitmap(open_dialog.FileName);
                        //     a1 = (open_dialog.FileName);
                        Bitmap bitmap = new Bitmap(open_dialog.FileName);
                        IResourceWriter writer = new ResourceWriter("my.resources");
                        writer.AddResource("myImage", bitmap);
                        writer.Close();
                        //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                        this.pictureBox1.Size = new System.Drawing.Size(171, 159);
                        pictureBox1.Image = image;
                        pictureBox1.Invalidate();                 
                    }
                    catch
                    {
                        DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string path = (open_dialog.FileName);
                    using (System.Drawing.Image image1 = System.Drawing.Image.FromFile(path))
                    {
                        using (MemoryStream m = new MemoryStream())
                        {
                            image1.Save(m, image1.RawFormat);
                            byte[] imageBytes = m.ToArray();
                            base64String = Convert.ToBase64String(imageBytes);
                            a1 = base64String;
                        }
                    }
                }
            }
        } 
            private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        public void button2_Click_1(object sender, EventArgs e)
        {
            a = textBox1.Text;
            b = maskedTextBox3.Text;
            c = comboBox1.Text;

            d = textBox2.Text;
            e1 = maskedTextBox1.Text;
            f = textBox3.Text;

            g = textBox7.Text;
            h = textBox4.Text;
            i = maskedTextBox2.Text;

            j = textBox5.Text;
            k = textBox6.Text;
            m = textBox8.Text;

            n = textBox12.Text;
            o = textBox9.Text;
            p = textBox13.Text;

            q = textBox10.Text;
            w = textBox11.Text;
            z = textBox14.Text;

            proverka = 1;

            if (comboBox1.Text == "" || maskedTextBox3.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "" || textBox2.Text == "" || textBox3.Text == ""
                || textBox7.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox8.Text == "" || textBox12.Text == "" || textBox9.Text == "" || textBox13.Text == ""  )
                {
                    MessageBox.Show("Вы не заполнили необходимые поля или не выбрали изображение.");
                    
                }

                else
                {
                        Close();
                    }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(a1))
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали изображение!!!");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Image newImage = bmp;
                e.Graphics.DrawImage(newImage, 525, 75, 225, 225);   
           
            e.Graphics.DrawString("Карточка сотрудника", new Font("Arial", 20, FontStyle.Italic), Brushes.Black, new Point(270, 15));

            e.Graphics.DrawString("ФИО сотрудника:  ", new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 75));
            e.Graphics.DrawString(textBox1.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 105));
            e.Graphics.DrawString("Должность сотрудника:  " + textBox2.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 135));

            e.Graphics.DrawString("Дата рождения сотрудника:  " + maskedTextBox3.Text , new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 165));
            e.Graphics.DrawString("Пол сотрудника:  " + comboBox1.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 195));

            e.Graphics.DrawString("Дата устройства сотрудника:  " + maskedTextBox1.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 225));
            e.Graphics.DrawString("Контактный номер телефона:  " + textBox3.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 255));

            e.Graphics.DrawString("Место жительства сотрудника:  ", new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 285));
            e.Graphics.DrawString(textBox7.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 315));
            e.Graphics.DrawString(textBox15.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 345));

            e.Graphics.DrawString(groupBox1.Text, new Font("Arial", 14, FontStyle.Italic), Brushes.Black, new Point(330, 375));
            e.Graphics.DrawString("Выдан:  " + textBox4.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 405));

            e.Graphics.DrawString("Дата выдачи:  " + maskedTextBox2.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 435));
            e.Graphics.DrawString("Серия:  " + textBox5.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(355, 435));
            e.Graphics.DrawString("Номер:  " + textBox6.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(555, 435));

            e.Graphics.DrawString("Семейное положение:  " + textBox8.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 465));
            e.Graphics.DrawString(textBox15.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 495));

            e.Graphics.DrawString("ИНН:  " + textBox12.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 535));
            e.Graphics.DrawString("Номер пенсионного страхования:  " + textBox9.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 565));
            e.Graphics.DrawString("Номер медецинского полюса:  " + textBox13.Text, new Font("Times new roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 595));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            proverka = 228;
            Close();
        }
    }
        }
    


