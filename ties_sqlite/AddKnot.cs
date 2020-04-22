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
    public partial class AddKnot : Form
    {
        //private Knot currentKnot;
        private User currentUser;
        private string pathMin;
        private string pathMax;


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
        public AddKnot(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void InitData()
        {
            collarBox.Items.AddRange(collars);
            collarBox.SelectedIndex = 0;
            widthBox.Items.AddRange(widths);
            widthBox.SelectedIndex = 0;
            lengthBox.Items.AddRange(lengths);
            lengthBox.SelectedIndex = 0;
            eventBox.Items.AddRange(events);
            eventBox.SelectedIndex = 0;
            clothBox.Items.AddRange(cloths);
            clothBox.SelectedIndex = 0;
            nameBox.Text = "";
            descrBox.Text = "";
        }

        private void errClear(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void AddKnot_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text) ||
                string.IsNullOrWhiteSpace(descrBox.Text)||
                loadMin.Visible == false||
                loadMax.Visible == false)
            {
                label1.Visible = true;
            }
            else
            {
                try
                {
                    string curName = currentUser.Nickname;
                    if (currentUser.Status == "admin")
                    {
                        curName = "admin";
                    }

                    string txtQuery = "insert into pics (address_min, address_max)values('" + pathMin + "', '" + pathMax + "')";
                    ExecuteQuery(txtQuery);

                    SetConnection();
                    sql_con.Open();
                    sql_cmd = sql_con.CreateCommand();
                    string CommandText = "select _id from pics where address_min = '" + pathMin + "' and address_max ='" +
                        pathMax + "'";
                    DB = new SQLiteDataAdapter(CommandText, sql_con);
                    DSet.Reset();
                    DB.Fill(DSet);
                    DTab = DSet.Tables[0];
                    string id_pic = DTab.Rows[DTab.Rows.Count - 1][0].ToString();
                    sql_con.Close();
                    
                    txtQuery = "insert into knots (name, id_pic, description, owner)values('" +
                        nameBox.Text + "','" + id_pic + "','" + descrBox.Text + "','" + curName + "')";
                    ExecuteQuery(txtQuery);

                    SetConnection();
                    sql_con.Open();
                    sql_cmd = sql_con.CreateCommand();
                    CommandText = "select _id from knots where name = '" + nameBox.Text + "' and description ='" +
                        descrBox.Text + "' and owner ='" + curName + "'";
                    DB = new SQLiteDataAdapter(CommandText, sql_con);
                    DSet.Reset();
                    DB.Fill(DSet);
                    DTab = DSet.Tables[0];
                    string ID = DTab.Rows[DTab.Rows.Count - 1][0].ToString();
                    sql_con.Close();

                    txtQuery = "insert into collars (name, id_knot)values('" + collarBox.Text + "', '" + ID + "')";
                    ExecuteQuery(txtQuery);
                    txtQuery = "insert into widths (name, id_knot)values('" + widthBox.Text + "', '" + ID + "')";
                    ExecuteQuery(txtQuery);
                    txtQuery = "insert into lengths (name, id_knot)values('" + lengthBox.Text + "', '" + ID + "')";
                    ExecuteQuery(txtQuery);
                    txtQuery = "insert into events (name, id_knot)values('" + eventBox.Text + "', '" + ID + "')";
                    ExecuteQuery(txtQuery);
                    txtQuery = "insert into knots_cloths (id_knot, id_cloth) values ('" + ID +
                        "',(select _id from cloths where name = '" + clothBox.Text + "'))";
                    ExecuteQuery(txtQuery);
                    
                    this.Close();                    
                    MessageBox.Show(
                   "Добавлено",
                   "Успешно",
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

        private string UploadImage()
        {
            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    return open_dialog.FileName;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pathMin = UploadImage();
            loadMin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pathMax = UploadImage();
            loadMax.Visible = true;
        }
    }
}
