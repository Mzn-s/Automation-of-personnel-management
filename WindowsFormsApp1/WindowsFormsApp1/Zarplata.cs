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
    public partial class Zarplata : Form
    {
        public int l, n;
        public static string a1;


        public Zarplata()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox2.Enabled = true;
                groupBox3.Enabled = false;
            }
        }

        private void textBox18_TextChanged_1(object sender, EventArgs e)
        {
            n = textBox18.Text.IndexOf(",");

            if (n > 0 && textBox18.Text.Length > n + 3)
            {
                textBox18.Text = textBox18.Text.Substring(0, n + 3);
                l = textBox18.Text.Length;
            }
            else if (n > 0 && textBox18.Text.Length == l + 1)
                textBox18.Text = textBox1.Text.Substring(1, l);
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            n = textBox19.Text.IndexOf(",");

            if (n > 0 && textBox19.Text.Length > n + 3)
            {
                textBox19.Text = textBox19.Text.Substring(0, n + 3);
                l = textBox19.Text.Length;
            }
            else if (n > 0 && textBox19.Text.Length == l + 1)
                textBox19.Text = textBox1.Text.Substring(1, l);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
            }
        }

        private void Zarplata_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            
            if (File.Exists(Vxod.a12)) // если существует данный файл
            {
                DataSet ds = new DataSet(); // создаем новый пустой кэш данных
                ds.ReadXml(Vxod.a12); // записываем в него XML-данные из файла

                foreach (DataRow item in ds.Tables["Employee"].Rows)
                {
                    int n = dataGridView1.Rows.Add(); // добавляем новую сроку в dataGridView1
                    dataGridView1.Rows[n].Cells[0].Value = item["Name"]; // заносим в первый столбец созданной строки данные из первого столбца таблицы ds.
                    dataGridView1.Rows[n].Cells[1].Value = item["DR"]; // то же самое со вторым столбцом
                    dataGridView1.Rows[n].Cells[2].Value = item["pol"]; // то же самое с третьим столбцом

                    dataGridView1.Rows[n].Cells[3].Value = item["Dolznost"];
                    dataGridView1.Rows[n].Cells[4].Value = item["DU"];
                    dataGridView1.Rows[n].Cells[5].Value = item["Tel"];

                    dataGridView1.Rows[n].Cells[6].Value = item["PMJ"];
                    dataGridView1.Rows[n].Cells[7].Value = item["Vidan"];
                    dataGridView1.Rows[n].Cells[8].Value = item["DV"];

                    dataGridView1.Rows[n].Cells[9].Value = item["Seria"];
                    dataGridView1.Rows[n].Cells[10].Value = item["Nomer"];
                    dataGridView1.Rows[n].Cells[11].Value = item["SP"];

                    dataGridView1.Rows[n].Cells[12].Value = item["INN"];
                    dataGridView1.Rows[n].Cells[13].Value = item["NomerPS"];
                    dataGridView1.Rows[n].Cells[14].Value = item["NomerMP"];

                    dataGridView1.Rows[n].Cells[15].Value = item["Z"];
                    dataGridView1.Rows[n].Cells[16].Value = item["Z2"];
                    dataGridView1.Rows[n].Cells[17].Value = item["TV"];

                   dataGridView1.Rows[n].Cells[18].Value = item["Picture"];

                }
            }
            else
            {
                MessageBox.Show("XML файл не найден.", "Ошибка.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
            Person f12 = new Person();
            f12.Show();
        }

        private void Zarplata_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных
                dt.TableName = "Employee"; // название таблицы
                dt.Columns.Add("Name"); // название колонок
                dt.Columns.Add("DR");
                dt.Columns.Add("pol");

                dt.Columns.Add("Dolznost"); // название колонок
                dt.Columns.Add("DU");
                dt.Columns.Add("Tel");

                dt.Columns.Add("PMJ"); // название колонок
                dt.Columns.Add("Vidan");
                dt.Columns.Add("DV");

                dt.Columns.Add("Seria"); // название колонок
                dt.Columns.Add("Nomer");
                dt.Columns.Add("SP");

                dt.Columns.Add("INN"); // название колонок
                dt.Columns.Add("NomerPS");
                dt.Columns.Add("NomerMP");

                dt.Columns.Add("Z"); // название колонок
                dt.Columns.Add("Z2");
                dt.Columns.Add("TV");

                dt.Columns.Add("Picture");

                ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

                foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
                {
                    DataRow row = ds.Tables["Employee"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                    row["Name"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                    row["DR"] = r.Cells[1].Value; // то же самое со вторыми столбцами
                    row["pol"] = r.Cells[2].Value; //то же самое с третьими столбцами

                    row["Dolznost"] = r.Cells[3].Value; // название колонок
                    row["DU"] = r.Cells[4].Value;
                    row["Tel"] = r.Cells[5].Value;

                    row["PMJ"] = r.Cells[6].Value;
                    row["Vidan"] = r.Cells[7].Value;
                    row["DV"] = r.Cells[8].Value;

                    row["Seria"] = r.Cells[9].Value;
                    row["Nomer"] = r.Cells[10].Value;
                    row["SP"] = r.Cells[11].Value;

                    row["INN"] = r.Cells[12].Value;
                    row["NomerPS"] = r.Cells[13].Value;
                    row["NomerMP"] = r.Cells[14].Value;

                    row["Z"] = r.Cells[15].Value;
                    row["Z2"] = r.Cells[16].Value;
                    row["TV"] = r.Cells[17].Value;

                    row["Picture"] = r.Cells[18].Value;

                    ds.Tables["Employee"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
                }
                ds.WriteXml(Vxod.a12);
               
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Selected = true;
            dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Silver;

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            textBox5.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            textBox12.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();

            textBox19.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            textBox18.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            a1 = dataGridView1.CurrentRow.Cells[18].Value.ToString();

            byte[] imageBytes = Convert.FromBase64String(dataGridView1.CurrentRow.Cells[18].Value.ToString());
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);
            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            pictureBox1.Image = image;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
     "Расчет заработной платы по системе оклада рассчитывается по формуле:" +
"\n" + "((Сумма оклада + Премия) / Количество рабочих дней в месяце * Количество отработанных дней в месяце)." +
"\n" + 
"\n" + "Расчет заработной платы по системе почасовой оплаты рассчитывается по формуле:" +
"\n" + "(Ставка в час * Количество отработанных часов + Премия).",
     "Справка", MessageBoxButtons.OK, MessageBoxIcon.Question,
   MessageBoxDefaultButton.Button1);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
      
            if (groupBox2.Enabled == true)
            {
                if (textBox10.Text == "" || textBox11.Text == "" || textBox20.Text == "" || textBox14.Text == "")
                {
                    MessageBox.Show("Вы ввели не все значения!!!");
                }
                else
                {
                    int n = dataGridView1.Rows.Add();
                    int a11 = Int32.Parse(textBox10.Text); double b1 = double.Parse(textBox11.Text); double c1 = double.Parse(textBox14.Text); double в1 = double.Parse(textBox20.Text);
                    textBox18.Text = ((a11 + b1) / в1 * c1).ToString();
                    double d1 = double.Parse(textBox18.Text);
                    textBox19.Text = (d1 - d1 * 0.13).ToString();
                    dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                    dataGridView1.Rows[n].Cells[1].Value = maskedTextBox3.Text;
                    dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;

                    dataGridView1.Rows[n].Cells[3].Value = textBox2.Text;
                    dataGridView1.Rows[n].Cells[4].Value = maskedTextBox1.Text;
                    dataGridView1.Rows[n].Cells[5].Value = textBox3.Text;

                    dataGridView1.Rows[n].Cells[6].Value = textBox7.Text;
                    dataGridView1.Rows[n].Cells[7].Value = textBox4.Text;
                    dataGridView1.Rows[n].Cells[8].Value = maskedTextBox2.Text;

                    dataGridView1.Rows[n].Cells[9].Value = textBox5.Text;
                    dataGridView1.Rows[n].Cells[10].Value = textBox6.Text;
                    dataGridView1.Rows[n].Cells[11].Value = textBox8.Text;

                    dataGridView1.Rows[n].Cells[12].Value = textBox12.Text;
                    dataGridView1.Rows[n].Cells[13].Value = textBox9.Text;
                    dataGridView1.Rows[n].Cells[14].Value = textBox13.Text;

                    dataGridView1.Rows[n].Cells[15].Value = textBox19.Text;
                    dataGridView1.Rows[n].Cells[16].Value = textBox18.Text;
                    dataGridView1.Rows[n].Cells[18].Value = a1;

                    if (radioButton1.Checked)
                    {
                        dataGridView1.Rows[n].Cells[17].Value = "Оклад";
                    }
                    else
                    {
                        dataGridView1.Rows[n].Cells[17].Value = "Почасовая оплата";
                    }
                    int a = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                }
                }
                else
                {
                    if (textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "")
                    MessageBox.Show("Вы ввели не все значения!!!");
                else
                    {
                    int n = dataGridView1.Rows.Add();
                    int z1 = Int32.Parse(textBox15.Text); double x1 = double.Parse(textBox16.Text); double v1 = double.Parse(textBox17.Text);
                        textBox18.Text = (z1 * v1 + x1).ToString();
                        double d2 = double.Parse(textBox18.Text);
                        textBox19.Text = (d2 - d2 * 0.13).ToString();
                    dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                    dataGridView1.Rows[n].Cells[1].Value = maskedTextBox3.Text;
                    dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;

                    dataGridView1.Rows[n].Cells[3].Value = textBox2.Text;
                    dataGridView1.Rows[n].Cells[4].Value = maskedTextBox1.Text;
                    dataGridView1.Rows[n].Cells[5].Value = textBox3.Text;

                    dataGridView1.Rows[n].Cells[6].Value = textBox7.Text;
                    dataGridView1.Rows[n].Cells[7].Value = textBox4.Text;
                    dataGridView1.Rows[n].Cells[8].Value = maskedTextBox2.Text;

                    dataGridView1.Rows[n].Cells[9].Value = textBox5.Text;
                    dataGridView1.Rows[n].Cells[10].Value = textBox6.Text;
                    dataGridView1.Rows[n].Cells[11].Value = textBox8.Text;

                    dataGridView1.Rows[n].Cells[12].Value = textBox12.Text;
                    dataGridView1.Rows[n].Cells[13].Value = textBox9.Text;
                    dataGridView1.Rows[n].Cells[14].Value = textBox13.Text;

                    dataGridView1.Rows[n].Cells[15].Value = textBox19.Text;
                    dataGridView1.Rows[n].Cells[16].Value = textBox18.Text;
                    dataGridView1.Rows[n].Cells[18].Value = a1;

                    if (radioButton1.Checked)
                    {
                        dataGridView1.Rows[n].Cells[17].Value = "Оклад";
                    }
                    else
                    {
                        dataGridView1.Rows[n].Cells[17].Value = "Почасовая оплата";
                    }
                    int a = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                }
                }                         
 

                textBox10.Text = ""; textBox11.Text = ""; textBox14.Text = ""; textBox20.Text = ""; textBox15.Text = ""; textBox16.Text = ""; textBox17.Text = "";
            }
        }
    }


    

