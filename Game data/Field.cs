using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_data
{
    abstract class Field : PictureBox
    {
        protected static readonly Image _closedImage = Properties.Resources.closed;
        private Image _openImage;
        private string _imageName;
        protected bool opened = false;

        public Image OpenImage { get => _openImage; set => _openImage = value; }
        public string ImageName { get => _imageName; set => _imageName = value; }

        public Field()
        {
            initializeField();
        }

        private void initializeField()
        {
            Image = _closedImage;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BorderStyle = BorderStyle.FixedSingle;
        }

        public bool Open()
        {
            if (OpenImage != null && !opened)
            {
                Image = OpenImage;
                opened = true;
            }
            return opened;
        }
    }
}
