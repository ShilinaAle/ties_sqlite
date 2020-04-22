using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ties_sqlite
{
    /// <summary>
    /// contain all info about knot
    /// </summary>
    public class Knot
    {
        private string id;
        private string name;
        private string nickname;
        private string url_pic;
        private string url_guide;
        private string description;
        private string cloth;
        private string collar;
        private string width;
        private string lengh;
        private string toevent;

        public Knot(User user)
        {
            //тиюзер = юзер
        }

        public Knot(string[] data)
        {
            FillKnot(data);
        }

        public void FillKnot(string[] data)
        {
            id = data[0];
            name = data[1];
            nickname = data[2];
            url_pic = data[3];
            url_guide = data[4];
            description = data[5];
            cloth = data[6];
            collar = data[7];
            width = data[8];
            lengh = data[9];
            toevent = data[10];
        }

        public List<string> GetKnot()
        {
            List<string> data = new List<string>
            {
                [0] = id,
                [1] = name,
                [2] = nickname,
                [3] = url_pic,
                [4] = url_guide,
                [5] = description,
                [6] = cloth,
                [7] = collar,
                [8] = width,
                [9] = lengh,
                [10] = toevent
            };

            return data;
        }

        //0
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        //1
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //2
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        //3
        public string Url_pic
        {
            get { return url_pic; }
            set { url_pic = value; }
        }
        //4
        public string Url_guide
        {
            get { return url_guide; }
            set { url_guide = value; }
        }
        //5
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        //6
        public string Cloth
        {
            get { return cloth; }
            set { cloth = value; }
        }
        //7
        public string Collar
        {
            get { return collar; }
            set { collar = value; }
        }
        //8
        public string Width
        {
            get { return width; }
            set { width = value; }
        }
        //9
        public string Lengh
        {
            get { return lengh; }
            set { lengh = value; }
        }
        //10
        public string Toevent
        {
            get { return toevent; }
            set { toevent = value; }
        }
    }
}
