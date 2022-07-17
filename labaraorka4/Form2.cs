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
    public partial class Form2 : Form
    {
        public static string connectString = @"provider=Microsoft.Jet.OLEDB.4.0; data source= D:\c#\labaraorka4\laba4.mdb";
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM big";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
            }
            reader.Close();

            query = "SELECT * FROM little";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView2.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
            }
            reader.Close();
           /* // TODO: данная строка кода позволяет загрузить данные в таблицу "laba4DataSet4.big". При необходимости она может быть перемещена или удалена.
            this.bigTableAdapter5.Fill(this.laba4DataSet4.big);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab41DataSet.big". При необходимости она может быть перемещена или удалена.
            this.bigTableAdapter4.Fill(this.lab41DataSet.big);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "laba4DataSet3.big". При необходимости она может быть перемещена или удалена.
            this.bigTableAdapter3.Fill(this.laba4DataSet3.big);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "laba4DataSet2.big". При необходимости она может быть перемещена или удалена.
            this.bigTableAdapter2.Fill(this.laba4DataSet2.big);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "laba4DataSet1.little". При необходимости она может быть перемещена или удалена.
            this.littleTableAdapter2.Fill(this.laba4DataSet1.little);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "laba4DataSet.big". При необходимости она может быть перемещена или удалена.
            this.bigTableAdapter1.Fill(this.laba4DataSet.big);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab4DataSet2.little". При необходимости она может быть перемещена или удалена.
            this.littleTableAdapter1.Fill(this.lab4DataSet2.little);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab4DataSet1.little". При необходимости она может быть перемещена или удалена.
            this.littleTableAdapter.Fill(this.lab4DataSet1.little);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab4DataSet.big". При необходимости она может быть перемещена или удалена.
            this.bigTableAdapter.Fill(this.lab4DataSet.big);
            */
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
