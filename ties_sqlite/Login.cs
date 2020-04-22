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
    public partial class Login : Form
    {
        public string currentUser = "unknown";
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
        public Login()
        {
            InitializeComponent();
        }

        private void erClear(object sender, EventArgs e)
        {
            labelEmp.Visible = false;
            labelLogin.Visible = false;
            labelPass.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erClear(sender, e);
            if (string.IsNullOrWhiteSpace(textBox1.Text)||
                string.IsNullOrWhiteSpace(textBox2.Text))
            {
                labelEmp.Visible = true;
            }
            else
            {
                if (!userLogins.Contains(textBox1.Text))
                {
                    labelLogin.Visible = true;
                }
                else
                {
                    SetConnection();
                    sql_con.Open();
                    sql_cmd = sql_con.CreateCommand();
                    string CommandText = "SELECT password FROM users WHERE nickname = '" +
                        textBox1.Text + "'";
                    DB = new SQLiteDataAdapter(CommandText, sql_con);
                    DSet.Reset();
                    DB.Fill(DSet);
                    try
                    {
                        DTab = DSet.Tables[0];
                        if (DTab.Rows[0][0].ToString() != textBox2.Text)
                        {
                            labelPass.Visible = true;
                        }
                        else
                        {
                            sql_con.Close();
                            currentUser = textBox1.Text;
                            this.Close();
                        }
                    }
                    catch
                    {
                        labelPass.Visible = true;
                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
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
        }
    }
}
