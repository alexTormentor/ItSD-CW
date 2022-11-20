using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstIterationCW
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 25);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_MouseEnter(object sender, EventArgs e)
        {
            Close.ForeColor = Color.Red;
        }

        private void Close_MouseLeave(object sender, EventArgs e)
        {
            Close.ForeColor = Color.Black;
        }

        Point coord;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - coord.X;
                this.Top += e.Y - coord.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            coord = new Point(e.X, e.Y);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String login = loginField.Text;
            String pass = passField.Text;
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = pass;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0) MessageBox.Show("Готово!");
            else MessageBox.Show("Ошибка!");
        }
    }
}
