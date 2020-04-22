using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ties_sqlite
{
    public partial class Registration : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DSet = new DataSet();
        private DataTable DTab = new DataTable();

        private List<string> userLogins = new List<string>();

        //установка соединения
        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=tiesBD.db;Version=3;New=False;Compress=True;");
        }

        //выполнение команды 
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        public Registration()
        {
            InitializeComponent();
        }

        private void erClear(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erClear(sender, e);
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                label5.Text = "Заполните все поля";
                label5.Visible = true;
            }
            else
            {
                //выборка всех логинов из бд
                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                string CommandText = "SELECT nickname FROM users ";
                DB = new SQLiteDataAdapter(CommandText, sql_con);
                DSet.Reset();
                DB.Fill(DSet);
                DTab = DSet.Tables[0];
                for (int i = 0; i < DTab.Rows.Count; i++)
                {
                    userLogins.Add(DTab.Rows[i][0].ToString());
                }
                sql_con.Close();

                if (userLogins.Contains(textBox2.Text))
                {
                    label5.Text = "Такой логин уже существует";
                    label5.Visible = true;
                }
                else
                {
                    if (textBox3.Text != textBox4.Text)
                    {
                        label5.Text = "Пароли не совпадают";
                        label5.Visible = true;
                    }
                    else
                    {
                        try
                        {
                            string txtQuery = "insert into users (email, nickname, password) values('" + 
                                textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text+"')";
                            ExecuteQuery(txtQuery);
                            this.Close();
                            MessageBox.Show(
                           "Добро пожаловать",
                           "Выполнено",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly
                           );
                        }
                        catch
                        {
                            MessageBox.Show(
                            "Добавление не реализовано",
                            "Что-то пошло не так",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly
                            );
                        }
                    }
                }
            }
        }


    }
}
