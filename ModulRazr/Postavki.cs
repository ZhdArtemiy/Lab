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
using Microsoft.VisualBasic;

namespace Proect
{
    public partial class Postavki : Form
    {
        private const string ConnectionString = "Data Source=mydb.db";

        // Добавляем поля для хранения значений из TextBox'ов
        private DateTime? deliveryDate;
        private string receivedBy;
        private int tovarId;
        private int kolichestvo;

        public Postavki()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Проверяем корректность введенных данных перед выполнением запроса
            if (!ValidateInput())
            {
                return;
            }

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var sql = "INSERT INTO Postavki (delivery_date, received_by, TovarId, kolichestvo)" +
                          "VALUES (@delivery_date, @received_by, @tovarId, @kolichestvo)";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@delivery_date", deliveryDate);
                    command.Parameters.AddWithValue("@received_by", receivedBy);
                    command.Parameters.AddWithValue("@tovarId", tovarId);
                    command.Parameters.AddWithValue("@kolichestvo", kolichestvo);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            MessageBox.Show("Новая поставка была успешно сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            button3.PerformClick();
        }

        private bool ValidateInput()
        {
            // Проверим, все ли данные введены правильно
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Пожалуйста, введите дату поставки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, введите получателя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Пожалуйста, введите ID товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Пожалуйста, введите количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                deliveryDate = Convert.ToDateTime(textBox1.Text);
                receivedBy = textBox2.Text.Trim();
                tovarId = Convert.ToInt32(textBox3.Text);
                kolichestvo = Convert.ToInt32(textBox4.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Некорректный формат данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); // Очищаем ListBox перед добавлением новых элементов

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var sql = "SELECT * FROM Postavki";
                var users = connection.Query<User>(sql);

                foreach (var user in users)
                {
                    listBox1.Items.Add(user);
                }

                connection.Close();
            }
        }
        internal class User
        {
            public int id { get; set; }
            public DateTime delivery_date { get; set; }
            public int received_by { get; set; }
            public int TovarId { get; set; }
            public int kolichestvo { get; set; }

            public override string ToString()
            {
                return $"ID: {id}, Дата: {delivery_date}, Принят: {received_by}, TovarID: {TovarId}, Количество:{kolichestvo}";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
