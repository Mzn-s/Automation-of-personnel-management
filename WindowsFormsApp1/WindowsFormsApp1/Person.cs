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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Person : Form
    {
    
        public Person()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.FormClosed += new FormClosedEventHandler(f_FormClosed);
            f.button4.Visible = false;
            f.ShowDialog();
       

        }
        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Form2.proverka == 1)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = Form2.a.ToString();
                dataGridView1.Rows[n].Cells[1].Value = Form2.b.ToString();
                dataGridView1.Rows[n].Cells[2].Value = Form2.c.ToString();

                dataGridView1.Rows[n].Cells[3].Value = Form2.d.ToString();
                dataGridView1.Rows[n].Cells[4].Value = Form2.e1.ToString();
                dataGridView1.Rows[n].Cells[5].Value = Form2.f.ToString();

                dataGridView1.Rows[n].Cells[6].Value = Form2.g.ToString();
                dataGridView1.Rows[n].Cells[7].Value = Form2.h.ToString();
                dataGridView1.Rows[n].Cells[8].Value = Form2.i.ToString();

                dataGridView1.Rows[n].Cells[9].Value = Form2.j.ToString();
                dataGridView1.Rows[n].Cells[10].Value = Form2.k.ToString();
                dataGridView1.Rows[n].Cells[11].Value = Form2.m.ToString();

                dataGridView1.Rows[n].Cells[12].Value = Form2.n.ToString();
                dataGridView1.Rows[n].Cells[13].Value = Form2.o.ToString();
                dataGridView1.Rows[n].Cells[14].Value = Form2.p.ToString();

                dataGridView1.Rows[n].Cells[15].Value = Form2.q.ToString();
                dataGridView1.Rows[n].Cells[16].Value = Form2.w.ToString();
                dataGridView1.Rows[n].Cells[17].Value = Form2.z.ToString();

                dataGridView1.Rows[n].Cells[18].Value = Form2.a1.ToString();
            }

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2();
            myForm.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            myForm.maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            myForm.comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            myForm.textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            myForm.maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            myForm.textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            myForm.textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            myForm.textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            myForm.maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            myForm.textBox5.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            myForm.textBox6.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            myForm.textBox8.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            myForm.textBox12.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            myForm.textBox9.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            myForm.textBox13.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();

            byte[] imageBytes = Convert.FromBase64String(dataGridView1.CurrentRow.Cells[18].Value.ToString());
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);
            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            myForm.pictureBox1.Image = image; 

            Form2.a1 = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            myForm.button5.Visible = false;
            myForm.button1.Visible = false;

            myForm.ShowDialog();

           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
        }
        private void Person_Load(object sender, EventArgs e)
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
                dataGridView1.Rows[n].Cells[2].Value = item["pol"]; // то же самое с третьим столбцом}

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
            Form2 myForm = new Form2();
            myForm.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            myForm.maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            myForm.comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            myForm.textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            myForm.maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            myForm.textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            myForm.textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            myForm.textBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            myForm.maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            myForm.textBox5.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            myForm.textBox6.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            myForm.textBox8.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            myForm.textBox12.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            myForm.textBox9.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            myForm.textBox13.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();

            myForm.textBox10.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            myForm.textBox11.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            myForm.textBox14.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();

            Form2.a1 = dataGridView1.CurrentRow.Cells[18].Value.ToString();

            myForm.button5.Visible = false;

            byte[] imageBytes = Convert.FromBase64String(dataGridView1.CurrentRow.Cells[18].Value.ToString());
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);
            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            myForm.pictureBox1.Image = image;


            myForm.FormClosed += new FormClosedEventHandler(f_FormClosed);
            myForm.ShowDialog();
            int a = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
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
                MessageBox.Show("Данные успешно сохранены.", "Выполнено.");
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            }
            Zarplata f1 = new Zarplata();
            f1.FormClosed += new FormClosedEventHandler(f1_FormClosed);
            f1.ShowDialog();
            Hide();
        }

        void f1_FormClosed(object sender, FormClosedEventArgs e)
        {
               if (File.Exists(Vxod.a12)) // если существует данный файл
                  {
            DataSet ds = new DataSet(); // создаем новый пустой кэш данных
            ds.ReadXml(Vxod.a12); // записываем в него XML-данные из файла

            dataGridView1.Rows.Clear();


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
        private void Person_FormClosing(object sender, FormClosingEventArgs e)
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
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            }
            }

        private void button4_Click(object sender, EventArgs e)
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
                MessageBox.Show("Данные успешно сохранены.", "Выполнено.");
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            }
            Vxod f1 = new Vxod();
            f1.FormClosed += new FormClosedEventHandler(f1_FormClosed);
            f1.ShowDialog();
            Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Selected = true;
            
        }
    }
    }








