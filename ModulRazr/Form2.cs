using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using Dapper;
using System.Windows.Forms.VisualStyles;

namespace Proect
{
    public partial class Form2 : Form
    {
        private const string ConnectionString = "Data Source=mydb.db";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); // Очищаем ListBox перед добавлением новых элементов

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var sql = "SELECT * FROM Sotrudnik";
                var users = connection.Query<User>(sql);

                foreach (var user in users)
                {
                    listBox1.Items.Add(user);
                    //($"ID: {user.Id}, Name: {user.FIO}, Age: {user.Age}, Stage: {user.Stage}");
                }

                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e) // DELETE
        {
            // Проверка, что выбран хотя бы один сотрудник
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Сначала выберите сотрудника!");
                return;
            }

            // Получаем информацию о выбранном сотруднике
            var selectedUser = listBox1.SelectedItem as User;

            if (selectedUser != null)
            {
                // Подтверждение удаления
                DialogResult result = MessageBox.Show(
                    $"Вы уверены, что хотите уволить сотрудника {selectedUser.FIO}?",
                    "Подтвердите увольнение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // Удаление сотрудника из базы данных
                    using (var connection = new SqliteConnection(ConnectionString))
                    {
                        connection.Open();

                        var sql = "DELETE FROM Sotrudnik WHERE Id = @Id";
                        connection.Execute(sql, new { Id = selectedUser.Id });

                        connection.Close();
                    }

                    // Удаление сотрудника из ListBox
                    listBox1.Items.Remove(selectedUser);

                    MessageBox.Show("Сотрудник уволен!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) // ADD USER
        {
            // Получаем значения из текстовых полей
            string fio = textBox1.Text.Trim(); // Поле для ввода ФИО
            string ageStr = textBox2.Text.Trim(); // Поле для ввода возраста
            string stage = textBox3.Text.Trim(); // Поле для ввода должности

            // Проверяем, что все обязательные поля заполнены
            if (string.IsNullOrWhiteSpace(fio) || string.IsNullOrWhiteSpace(stage) || string.IsNullOrWhiteSpace(ageStr))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            // Проверяем, что возраст введен корректно
            if (!int.TryParse(ageStr, out int age))
            {
                MessageBox.Show("Возраст должен быть числом.");
                return;
            }

            // Создаем новый объект класса User
            var newUser = new User
            {
                FIO = fio,
                Age = age,
                Stage = stage
            };

            // Открываем соединение с базой данных и добавляем нового сотрудника
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var sql = "INSERT INTO Sotrudnik (FIO, Age, Stage) VALUES (@FIO, @Age, @Stage)";
                connection.Execute(sql, newUser);

                connection.Close();
            }

            // Обновляем список сотрудников в ListBox
            button2.PerformClick();

            // Сообщаем пользователю об успешном добавлении
            MessageBox.Show("Новый сотрудник успешно добавлен!");

            // Очищаем текстовые поля
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
    internal class User
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public string Stage { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {FIO}, Age: {Age}, Stage: {Stage}";
        }
    }
}
