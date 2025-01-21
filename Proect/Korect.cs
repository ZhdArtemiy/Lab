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
    public partial class Korect : Form
    {
        private const string ConnectionString = "Data Source=mydb.db";
        public Korect()
        {
            InitializeComponent();
            FillCheckedListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e) // Остатки
        {
            listBox1.Items.Clear();
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // Запрос с использованием JOIN для получения информации о товаре и остатках
                var sql = @"SELECT t.name AS Name, t.kolichestvo - COALESCE(SUM(k.kolichestvo),0) AS Quantity
                            FROM Tovari t
                            LEFT JOIN Korect k ON t.id = k.TovarId
                            GROUP BY t.name;";

                var results = connection.Query<InventoryItem>(sql).ToArray();

                // Перебираем результаты и добавляем каждый объект в ListBox
                foreach (var item in results)
                {
                    listBox1.Items.Add(item); // Теперь каждое значение добавляется отдельно
                }

                connection.Close();
            }
        }
        private void FillCheckedListBox()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var sql = "SELECT name, kolichestvo FROM Tovari"; // Запрашиваем только необходимые поля

                var items = connection.Query<InventoryItem>(sql).ToArray();

                checkedListBox1.Items.Clear(); // Очистка CheckedListBox перед добавлением новых элементов
                checkedListBox1.Items.AddRange(items); // Добавление элементов в CheckedListBox

                connection.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e) // Обновление количества
        {
            // Получаем выбранный товар из checkedListBox
            if (checkedListBox1.CheckedItems.Count == 0 || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Не выбрано ни одного товара или не введено количество.");
                return;
            }

            var selectedItem = checkedListBox1.CheckedItems[0] as InventoryItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Ошибка при выборе товара.");
                return;
            }

            // Получаем новое количество из textBox1
            int newQuantity;
            if (!int.TryParse(textBox1.Text, out newQuantity))
            {
                MessageBox.Show("Неверный формат числа.");
                return;
            }

            // Обновляем количество в базе данных
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // Получаем id товара по имени
                var getTovarIdSql = "SELECT id FROM Tovari WHERE name = @name";
                var tovarId = connection.QuerySingle<int>(getTovarIdSql, new { name = selectedItem.Name });

                // Обновляем таблицу Korect
                var updateKorectSql = "UPDATE Korect SET kolichestvo = @newQuantity WHERE TovarId = @tovarId";
                connection.Execute(updateKorectSql, new { newQuantity, tovarId });

                connection.Close();
            }
            textBox1.Clear();
            MessageBox.Show("Количество товара успешно обновлено!");
            button2.PerformClick();
        }
    }

    internal class InventoryItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Quantity}";
        }
    }
}
   

