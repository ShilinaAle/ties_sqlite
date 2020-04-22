using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ties_sqlite
{
    public partial class ListItem : UserControl
    {
        private Knot currentKnot;
        private User currentUser;

        public ListItem(Knot currentK, User currentU)
        {
            InitializeComponent();
            currentKnot = currentK;
            currentUser = currentU;
        }

        #region Properties
        private string _title;
        private string _message;
        private Image _icon;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; lblTitle.Text = value; }
        }

        [Category("Custom Props")]
        public string Message
        {
            get { return _message; }
            set { _message = value; label2.Text = value; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; }
        }

        #endregion

        private void Click_info(object sender, EventArgs e)
        {
            EditKnot f = new EditKnot(currentKnot, currentUser);
            f.ShowDialog();
        }

        private void Hover_info(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
        }

        private void Hover_none(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

    }
}
