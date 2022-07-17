using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labaraorka4
{
    public partial class Form1 : Form
    {
        public static string connectString = @"provider=Microsoft.Jet.OLEDB.4.0; data source= D:\c#\labaraorka4\laba4.mdb";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Номер отдела", "Номер отдела");
            dataGridView1.Columns.Add("ФИО", "ФИО");
            dataGridView1.Columns.Add("Кол. работников", "Кол. работников");
            dataGridView1.Columns.Add("% Заполнения", "% Заполнения");
            string sql = "SELECT number, Fuo, Kolrab,sapolnenie  FROM little WHERE sapolnenie < 80";
            OleDbCommand command = new OleDbCommand(sql, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
            }
            reader.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("ФИО", "ФИО");
            dataGridView1.Columns.Add("Должность", "Должность");
            dataGridView1.Columns.Add("Дата поступления", "Дата поступления");
            dataGridView1.Columns.Add("Зарплата", "Зарплата");
            dataGridView1.Columns.Add("Номер отдела", "Номер отдела");
            DateTime date1 = DateTime.Now;
            string query = "SELECT id, fuo, work, den, salary, number FROM big WHERE den > " + dateTimePicker1.Value.ToString("#yyyy-MM-dd#");
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader1 = command.ExecuteReader();

            while (reader1.Read())
            {
                dataGridView1.Rows.Add(reader1[0], reader1[1], reader1[2], reader1[3], reader1[4], reader1[5]);
            }
            reader1.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //чистим столбцы
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            //считываем номер отдела
            string a = textBox2.Text;

            //ищим людей в отделе
            string sql = "SELECT den FROM big WHERE number=" + Convert.ToInt32(a);
            OleDbCommand command1 = new OleDbCommand(sql, myConnection);
            OleDbDataReader reader = command1.ExecuteReader();

            int i = 0;//количество людей в отдела
            int sum = 0;

            //находим сегодняшний год
            DateTime date = DateTime.Now;//время сегодня
            string date1 = date.ToString("yyyy");//строка c годом
            int year = Convert.ToInt32(date1);// год
            DateTime dateValue = new DateTime();

            //выводим даты постепления людей на работу
            //dataGridView1.Columns.Add("Даты поступления людей", "Даты поступления людей");
            //dataGridView1.Columns.Add("Стаж работы сотрудника", "Стаж работы сотрудника");
            while (reader.Read())
            {
                //dataGridView1.Rows.Add(reader[0]);

                //выделяем года, когда люди начали работать
                dateValue = Convert.ToDateTime(reader[0]);
                string date2 = dateValue.ToString("yyyy");
                int year2 = Convert.ToInt32(date2);

                //находим стаж работы каждого сотрудника
                int x = year - year2;

                //dataGridView1[1, i].Value = Convert.ToString(x);

                sum = sum + x;//складываем стаж каждого сотрудника
                i++;//считаем количество сотрудников
            }
            reader.Close();

            //выводим сегодняшнее число
            //dataGridView1.Columns.Add("Сегодняшняя дата", "Сегодняшняя дата");
            //dataGridView1[2, 0].Value = date;

            //сумма стаж
            //dataGridView1.Columns.Add("Всего проработанных лет", "Всего проработанных лет");
            //dataGridView1[3, 0].Value = sum.ToString();

            //вывод количесвта людей в отделе
            //dataGridView1.Columns.Add("Кол. работников в отделе", "Кол. работников в отделе");
           // dataGridView1[4, 0].Value = i.ToString();

            //вывод стажа по отделу
            double y = (double)sum / (double)i;
            dataGridView1.Columns.Add("Сред. стаж работы сотрудников", "Сред. стаж работы сотрудников");
            dataGridView1.Rows.Add(Convert.ToString(y));

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Прошлая дата", "Прошлая дата");
            dataGridView1.Columns.Add("Новая дата", "Новая дата");
            string a = textBox1.Text;

            string query = "SELECT den FROM big WHERE id = " + Convert.ToInt32(a);
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0]);
            }
            reader.Close();


            string query1 = "UPDATE big SET den = " + dateTimePicker2.Value.ToString("#yyyy-MM-dd#") + " WHERE id = " + Convert.ToInt32(a);
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            command1.ExecuteNonQuery();

            string query3 = "SELECT den FROM big WHERE id = " + Convert.ToInt32(a);
            OleDbCommand command3 = new OleDbCommand(query3, myConnection);
            OleDbDataReader reader2 = command3.ExecuteReader();

            while (reader2.Read())
            {
                dataGridView1[1,0].Value=reader2[0];
            }
            reader2.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }
    }
}
