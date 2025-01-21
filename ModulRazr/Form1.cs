namespace Proect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tovari Tovari = new Tovari();
            Tovari.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Postavki Postavki = new Postavki();
            Postavki.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Korect Korect = new Korect();
            Korect.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Buh Buh = new Buh();
            Buh.Show();
        }
    }
}
