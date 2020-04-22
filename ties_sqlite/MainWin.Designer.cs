namespace ties_sqlite
{
    partial class MainWin
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.panel2 = new System.Windows.Forms.Panel();
            this.add = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.registration = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.collarBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.helpCloth = new System.Windows.Forms.Button();
            this.widthBox = new System.Windows.Forms.ComboBox();
            this.lengthBox = new System.Windows.Forms.ComboBox();
            this.eventBox = new System.Windows.Forms.ComboBox();
            this.clothBox = new System.Windows.Forms.ComboBox();
            this.find = new System.Windows.Forms.Button();
            this.showAll = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.add);
            this.panel2.Controls.Add(this.logOut);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.registration);
            this.panel2.Controls.Add(this.login);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 154);
            this.panel2.TabIndex = 1;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(163, 14);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(112, 28);
            this.add.TabIndex = 4;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Visible = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // logOut
            // 
            this.logOut.Location = new System.Drawing.Point(27, 12);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(112, 29);
            this.logOut.TabIndex = 3;
            this.logOut.Text = "Выйти";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Visible = false;
            this.logOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(79, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 72);
            this.label1.TabIndex = 2;
            this.label1.Text = "ГОСТЬ";
            // 
            // registration
            // 
            this.registration.Location = new System.Drawing.Point(163, 12);
            this.registration.Name = "registration";
            this.registration.Size = new System.Drawing.Size(112, 30);
            this.registration.TabIndex = 1;
            this.registration.Text = "Регистрация";
            this.registration.UseVisualStyleBackColor = true;
            this.registration.Click += new System.EventHandler(this.registration_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(27, 12);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(112, 30);
            this.login.TabIndex = 0;
            this.login.Text = "Войти";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(307, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(727, 518);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // collarBox
            // 
            this.collarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.collarBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.collarBox.FormattingEnabled = true;
            this.collarBox.Location = new System.Drawing.Point(136, 219);
            this.collarBox.Name = "collarBox";
            this.collarBox.Size = new System.Drawing.Size(121, 24);
            this.collarBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Воротник";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ширина";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Длина";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Мероприятие";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ткань";
            // 
            // helpCloth
            // 
            this.helpCloth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpCloth.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helpCloth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.helpCloth.Location = new System.Drawing.Point(88, 401);
            this.helpCloth.Name = "helpCloth";
            this.helpCloth.Size = new System.Drawing.Size(26, 29);
            this.helpCloth.TabIndex = 9;
            this.helpCloth.Text = "?";
            this.helpCloth.UseVisualStyleBackColor = true;
            this.helpCloth.Click += new System.EventHandler(this.helpCloth_Click);
            // 
            // widthBox
            // 
            this.widthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.widthBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.widthBox.FormattingEnabled = true;
            this.widthBox.Location = new System.Drawing.Point(136, 264);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(121, 24);
            this.widthBox.TabIndex = 10;
            // 
            // lengthBox
            // 
            this.lengthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lengthBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lengthBox.FormattingEnabled = true;
            this.lengthBox.Location = new System.Drawing.Point(136, 310);
            this.lengthBox.Name = "lengthBox";
            this.lengthBox.Size = new System.Drawing.Size(121, 24);
            this.lengthBox.TabIndex = 11;
            // 
            // eventBox
            // 
            this.eventBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventBox.FormattingEnabled = true;
            this.eventBox.Location = new System.Drawing.Point(136, 357);
            this.eventBox.Name = "eventBox";
            this.eventBox.Size = new System.Drawing.Size(121, 24);
            this.eventBox.TabIndex = 12;
            // 
            // clothBox
            // 
            this.clothBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clothBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clothBox.FormattingEnabled = true;
            this.clothBox.Location = new System.Drawing.Point(136, 405);
            this.clothBox.Name = "clothBox";
            this.clothBox.Size = new System.Drawing.Size(121, 24);
            this.clothBox.TabIndex = 13;
            // 
            // find
            // 
            this.find.Location = new System.Drawing.Point(173, 456);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(75, 27);
            this.find.TabIndex = 14;
            this.find.Text = "Найти";
            this.find.UseVisualStyleBackColor = true;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // showAll
            // 
            this.showAll.Location = new System.Drawing.Point(47, 456);
            this.showAll.Name = "showAll";
            this.showAll.Size = new System.Drawing.Size(75, 27);
            this.showAll.TabIndex = 16;
            this.showAll.Text = "Сброс";
            this.showAll.UseVisualStyleBackColor = true;
            this.showAll.Click += new System.EventHandler(this.showAll_Click);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 518);
            this.Controls.Add(this.showAll);
            this.Controls.Add(this.find);
            this.Controls.Add(this.clothBox);
            this.Controls.Add(this.eventBox);
            this.Controls.Add(this.lengthBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.helpCloth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.collarBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasyTie";
            this.Load += new System.EventHandler(this.MainWin_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registration;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.ComboBox collarBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button helpCloth;
        private System.Windows.Forms.ComboBox widthBox;
        private System.Windows.Forms.ComboBox lengthBox;
        private System.Windows.Forms.ComboBox eventBox;
        private System.Windows.Forms.ComboBox clothBox;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.Button showAll;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button logOut;
    }
}

