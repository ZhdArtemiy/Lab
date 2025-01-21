using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Proect
{
    public partial class Tovari : Form
    {
        private const string ConnectionString = "Data Source=mydb.db";
        public Tovari()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //Name
        {
            listBox1.Items.Clear(); // Очищаем ListBox перед добавлением новых элементов

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var sql = "SELECT name FROM Tovari";
                var users = connection.Query<Names>(sql);
                listBox1.Items.Add("Наименоваени фруктов в наличии:");
                foreach (var user in users)
                {
                    listBox1.Items.Add(user.name);
                }

                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e) //Count
        {
            listBox1.Items.Clear(); // Очищаем ListBox перед добавлением новых элементов

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var sql = "SELECT name,kolichestvo FROM Tovari";
                var users = connection.Query<Count>(sql);
                listBox1.Items.Add("Количество фруктов в наличии:");
                foreach (var user in users)
                {
                    listBox1.Items.Add(user);
                }

                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e) //CountALL
        {
            listBox1.Items.Clear(); // Очищаем ListBox перед добавлением новых элементов

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var sql = "SELECT sum(kolichestvo) AS SumKolichestvo FROM Tovari";
                var users = connection.Query<CountAll>(sql);
                listBox1.Items.Add("Общий остаток товаров:");
                foreach (var user in users)
                {
                    listBox1.Items.Add(user);

                }

                connection.Close();
            }
        }
    }
    internal class Names
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
    internal class Count
    {
        public int id { get; set; }
        public string name { get; set; }
        public int kolichestvo { get; set; }


        public override string ToString()
        {
            return $"{name},: {kolichestvo}";
        }
    }
    internal class CountAll
    {
        public int SumKolichestvo { get; set; }

        public override string ToString()
        {
            return $"{SumKolichestvo}";
        }
    }
}


