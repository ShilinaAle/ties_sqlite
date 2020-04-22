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
    public partial class EditKnot : Form
    {
        private Knot currentKnot;
        private User currentUser;

        //возможные поля в бд
        private string[] collars = new string[] { "Не важно", "Широкий", "Узкий", "Косой" };
        private string[] widths = new string[] { "Не важно", "Широкий", "Узкий", "Бабочка" };
        private string[] lengths = new string[] { "Не важно", "Длинный", "Средний", "Бабочка" };
        private string[] events = new string[] { "Не важно", "Повседневный", "Официальный" };
        private string[] cloths = new string[] { "Не важно", "Легкая", "Плотная", "Тяжелая" };

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DSet = new DataSet();
        private DataTable DTab = new DataTable();

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

        public EditKnot(Knot item, User user)
        {
            InitializeComponent();
            currentKnot = item;
            currentUser = user;
        }

        private void EditKnot_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[0].Text = currentKnot.Name;

            label6.Text = currentKnot.Collar;
            label7.Text = currentKnot.Cloth;
            label8.Text = currentKnot.Toevent;
            label9.Text = currentKnot.Width;
            label10.Text = currentKnot.Lengh;
            textBox1.Text = currentKnot.Description;
            pictureBox1.ImageLocation = currentKnot.Url_pic;
            pictureBox2.ImageLocation = currentKnot.Url_guide;

            if ((currentKnot.Nickname == "admin" && currentUser.Status == "admin") ||
                (currentKnot.Nickname != "admin" && currentUser.Nickname == currentKnot.Nickname))
            {
                InitData();
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage3);
            }

        }

        private void InitData()
        {
            collarBox.Items.AddRange(collars);
            collarBox.SelectedItem = currentKnot.Collar;
            clothBox.Items.AddRange(cloths);
            clothBox.SelectedItem = currentKnot.Cloth;
            widthBox.Items.AddRange(widths);
            widthBox.SelectedItem = currentKnot.Width;
            lengthBox.Items.AddRange(lengths);
            lengthBox.SelectedItem = currentKnot.Lengh;
            eventBox.Items.AddRange(events);
            eventBox.SelectedItem = currentKnot.Toevent;
            nameBox.Text = currentKnot.Name;
            descrBox.Text = currentKnot.Description;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool change = false;
            try
            {
                string txtQuery;
                if (collarBox.Text != currentKnot.Collar)
                {
                    txtQuery = "update collars set name='" + collarBox.Text + "' where id_knot='" + currentKnot.Id + "'";
                    ExecuteQuery(txtQuery);
                    currentKnot.Collar = collarBox.Text;
                    change = true;
                }

                if (clothBox.Text != currentKnot.Cloth)
                {
                    txtQuery = "update knots_cloths set id_cloth = (select _id from cloths where name = '" +
                        clothBox.Text + "') where id_knot = '" + currentKnot.Id + "'";
                    ExecuteQuery(txtQuery);
                    currentKnot.Cloth = clothBox.Text;
                    change = true;
                }

                if (widthBox.Text != currentKnot.Width)
                {
                    txtQuery = "update widths set name='" + widthBox.Text + "' where id_knot='" + currentKnot.Id + "'";
                    ExecuteQuery(txtQuery);
                    currentKnot.Width = widthBox.Text;
                    change = true;
                }

                if (lengthBox.Text != currentKnot.Lengh)
                {
                    txtQuery = "update lengths set name='" + lengthBox.Text + "' where id_knot='" + currentKnot.Id + "'";
                    ExecuteQuery(txtQuery);
                    currentKnot.Lengh = lengthBox.Text;
                    change = true;
                }
                if (eventBox.Text != currentKnot.Toevent)
                {
                    txtQuery = "update events set name='" + eventBox.Text + "' where id_knot='" + currentKnot.Id + "'";
                    ExecuteQuery(txtQuery);
                    currentKnot.Toevent = eventBox.Text;
                    change = true;
                }
                if (nameBox.Text != currentKnot.Name)
                {
                    txtQuery = "update knots set name='" + nameBox.Text + "' where _id='" + currentKnot.Id + "'";
                    ExecuteQuery(txtQuery);
                    currentKnot.Name = nameBox.Text;
                    change = true;

                }
                if (descrBox.Text != currentKnot.Description)
                {
                    txtQuery = "update knots set description='" + nameBox.Text + "' where _id='" + currentKnot.Id + "'";
                    ExecuteQuery(txtQuery);
                    currentKnot.Description = descrBox.Text;
                    change = true;

                }
                if (change)
                {
                    MessageBox.Show(
                   "Изменено",
                   "Успешно",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly
                   );
                }
            }
            catch
            {
                MessageBox.Show(
                "Изменение не реализовано",
                "Что-то пошло не так",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
                );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string txtQuery = "delete from collars where id_knot='" + currentKnot.Id + "'";
                ExecuteQuery(txtQuery);
                txtQuery = "delete from widths where id_knot='" + currentKnot.Id + "'";
                ExecuteQuery(txtQuery);
                txtQuery = "delete from lengths where id_knot='" + currentKnot.Id + "'";
                ExecuteQuery(txtQuery);
                txtQuery = "delete from events where id_knot='" + currentKnot.Id + "'";
                ExecuteQuery(txtQuery);
                txtQuery = "delete from knots_cloths where id_knot='" + currentKnot.Id + "'";
                ExecuteQuery(txtQuery);
                txtQuery = "delete from knots where _id='" + currentKnot.Id + "'";
                ExecuteQuery(txtQuery);
                this.Close();
                MessageBox.Show(
                       "Удалено",
                       "Успешно",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1,
                       MessageBoxOptions.DefaultDesktopOnly
                       );
                InitData();
            }
            catch
            {
                MessageBox.Show(
            "Удаление не реализовано",
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

