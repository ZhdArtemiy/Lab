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
    public partial class Buh : Form
    {
        private const string ConnectionString = "Data Source=mydb.db";
        public Buh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e) // Price
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // Запрос с использованием JOIN для получения информации о цене товара, его количестве и наименовании
                var sql = @"SELECT b.PriceTovar, b.kolichestvoTovar, t.name AS TovarName, kolichestvoTovar * PriceTovar as SUM
                            FROM Buhgalter b
                            INNER JOIN Tovari t ON b.TovarId = t.id;";

                var results = connection.Query<BuhgalterInfo>(sql).ToArray();

                // Вывод результатов в ListBox
                listBox1.Items.Clear();
                foreach (var result in results)
                {
                    listBox1.Items.Add(result);
                }

                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e) // Информация о сотрудниках
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // Запрос с использованием JOIN для получения информации о сотруднике и дате оплаты
                var sql = @"SELECT b.SotrudnikId, b.PayDay, s.FIO
                            FROM Buhgalter b
                            INNER JOIN Sotrudnik s ON b.SotrudnikId = s.Id;";

                var results = connection.Query<SotrudnikInfo>(sql).ToArray();

                // Вывод результатов в ListBox
                listBox1.Items.Clear();
                foreach (var result in results)
                {
                    listBox1.Items.Add(result);
                }

                connection.Close();
            }
        }
    }
}
    internal class SotrudnikInfo
        {
        public int SotrudnikId { get; set; }
        public int PayDay { get; set; }
        public string FIO { get; set; }

        public override string ToString()
        {
            return $"Сотрудник: {FIO}, День выплаты: {PayDay}, Идентификатор сотрудника: {SotrudnikId}";
        }
    }
    internal class BuhgalterInfo
    {
        public int PriceTovar { get; set; }
        public int kolichestvoTovar { get; set; }
        public int SUM { get; set; }
        public string TovarName { get; set; }

        public override string ToString()
        {
            return $"Цена: {PriceTovar}, Количество: {kolichestvoTovar}, Наименование: {TovarName}, Общая сумма: {SUM}";
        }
    }

