using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace ties_sqlite
{
    public partial class MainWin : Form
    {
        //чекер регистрации
        public User currentUser = new User();
        //возможные поля в бд
        private string[] collars = new string[] { "Не важно", "Широкий", "Узкий", "Косой" };
        private string[] widths = new string[] { "Не важно", "Широкий", "Узкий", "Бабочка" };
        private string[] lengths = new string[] { "Не важно", "Длинный", "Средний", "Бабочка" };
        private string[] events = new string[] { "Не важно", "Повседневный", "Официальный" };
        private string[] cloths = new string[] { "Не важно", "Легкая", "Плотная", "Тяжелая" };

        private List<Knot> allKnots;

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

        public MainWin()
        {
            InitializeComponent();
        }


        private void MainWin_Load(object sender, EventArgs e)
        {
            //заполнение выпадающих списков
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
            currentUser.Nickname = "unknown";
            FillKnots();

        }

        //выборка всех узлов текущего пользователя из бд 
        private void FillKnots()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "SELECT k._id, k.name 'name', k.owner 'owner', " +
                "p.address_min 'a_min', p.address_max 'a_max', k.description 'des', " +
                "cth.name 'clh', cll.name 'cll', w.name 'width', l.name 'length', e.name 'event' " +
                "FROM knots k " +
                "INNER JOIN pics p ON k.id_pic = p._id " +
                "INNER JOIN knots_cloths kc ON k._id = kc.id_knot " +
                "INNER JOIN cloths cth ON kc.id_cloth = cth._id " +
                "INNER JOIN collars cll ON cll.id_knot = k._id " +
                "INNER JOIN widths w ON w.id_knot = k._id " +
                "INNER JOIN lengths l ON l.id_knot = k._id " +
                "INNER JOIN events e ON e.id_knot = k._id; ";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DSet.Reset();
            DB.Fill(DSet);
            DTab = DSet.Tables[0];
            allKnots = populateKnots(DTab);
            populateItems(allKnots);
            sql_con.Close();
        }

        //заполнение глобального массива узлов
        private List<Knot> populateKnots(DataTable allData)
        {
            List<Knot> neededKnots = new List<Knot>();
            for (int i = 0; i < allData.Rows.Count; i++)
            {
                //инициализация массива данных одного узла
                string[] data = new string[11];

                data[0] = allData.Rows[i][0].ToString();
                data[1] = allData.Rows[i][1].ToString();
                data[2] = allData.Rows[i][2].ToString();
                data[3] = allData.Rows[i][3].ToString();
                data[4] = allData.Rows[i][4].ToString();
                data[5] = allData.Rows[i][5].ToString();
                data[6] = allData.Rows[i][6].ToString();
                data[7] = allData.Rows[i][7].ToString();
                data[8] = allData.Rows[i][8].ToString();
                data[9] = allData.Rows[i][9].ToString();
                data[10] = allData.Rows[i][10].ToString();

                //если узел добавил не админ, выводятся только узлы текущего юзера
                if (data[2] != "admin")
                {
                    if (currentUser.Nickname == allData.Rows[i][2].ToString())
                    {
                        //добавление узла
                        neededKnots.Add(new Knot(data));
                    }
                }
                else
                {
                    neededKnots.Add(new Knot(data));
                }
            }
            // выборка данных из таблицы по юзеру ВСТАВИТЬ КОД
            return neededKnots;
        }

        //вывод списка узлов
        private void populateItems(List<Knot> knots)
        {
            flowLayoutPanel1.Controls.Clear();
            ListItem[] listItems = new ListItem[knots.Count];
            //заполнение каждого отдельно
            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem(knots[i], currentUser)
                {
                    Title = knots[i].Name,
                    Message = knots[i].Description,
                };
                listItems[i].pictureBox1.ImageLocation = knots[i].Url_pic;
                flowLayoutPanel1.Controls.Add(listItems[i]);
            }

        }

        private bool CheckField(string itemField, string field)
        {
            if (field == "Не важно" || itemField == field)
            {
                return true;
            }
            return false;
        }

        //проверка одного узла на условия из поиска
        private bool ChooseKnot(Knot item)
        {
            if (CheckField(item.Collar, collarBox.Text) && CheckField(item.Width, widthBox.Text)
                && CheckField(item.Lengh, lengthBox.Text) && CheckField(item.Toevent, eventBox.Text)
                && CheckField(item.Cloth, clothBox.Text))
            {
                return true;
            }
            return false;
        }

        //выборка по условиям
        private void find_Click(object sender, EventArgs e)
        {
            List<Knot> neededKnots = new List<Knot>();
            foreach (var item in allKnots)
            {
                if (ChooseKnot(item))
                {
                    neededKnots.Add(item);
                }
            }
            flowLayoutPanel1.Controls.Clear();
            populateItems(neededKnots);
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            //заполнение выпадающих списков
            collarBox.SelectedIndex = 0;
            widthBox.SelectedIndex = 0;
            lengthBox.SelectedIndex = 0;
            eventBox.SelectedIndex = 0;
            clothBox.SelectedIndex = 0;
            flowLayoutPanel1.Controls.Clear();
            populateItems(allKnots);


        }

        private void login_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Owner = this;
            form.ShowDialog();
            string f = form.currentUser;

            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "SELECT nickname, status FROM users WHERE nickname = '" + f + "'";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DSet.Reset();
            DB.Fill(DSet);
            try
            {
                DTab = DSet.Tables[0];
                currentUser.Nickname = DTab.Rows[0][0].ToString();
                currentUser.Status = DTab.Rows[0][1].ToString();
                sql_con.Close();
                FillKnots();
                login.Visible = false;
                registration.Visible = false;
                logOut.Visible = true;
                add.Visible = true;
                label1.Text = currentUser.Nickname.ToUpper();
            }
            catch
            {
                MessageBox.Show(
                "Ошибка при входе пользователя",
                "Что-то пошло не так",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentUser.Nickname = "unknown";
            currentUser.Status = "unknown";
            FillKnots();
            login.Visible = true;
            registration.Visible = true;
            logOut.Visible = false;
            add.Visible = false;
            label1.Text = "ГОСТЬ";
        }

        private void registration_Click(object sender, EventArgs e)
        {
            Registration form = new Registration();
            form.Owner = this;
            form.ShowDialog();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddKnot form = new AddKnot(currentUser);
            form.Owner = this;
            form.ShowDialog();
            FillKnots();
        }

        private void helpCloth_Click(object sender, EventArgs e)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select name, description from cloths";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DSet.Reset();
            DB.Fill(DSet);
            DTab = DSet.Tables[0];
            sql_con.Close();

            ClothInfo clothInfo = new ClothInfo();
            clothInfo.label1.Text = DTab.Rows[0][0].ToString();
            clothInfo.textBox1.Text = DTab.Rows[0][1].ToString();
            clothInfo.label2.Text = DTab.Rows[1][0].ToString();
            clothInfo.textBox2.Text = DTab.Rows[1][1].ToString();
            clothInfo.label3.Text = DTab.Rows[2][0].ToString();
            clothInfo.textBox3.Text = DTab.Rows[2][1].ToString();
            clothInfo.label4.Text = DTab.Rows[3][0].ToString();
            clothInfo.textBox4.Text = DTab.Rows[3][1].ToString();
            clothInfo.ShowDialog();

        }
    }
}
