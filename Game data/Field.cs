using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_data
{
    public abstract class Field : PictureBox
    {
        protected static readonly Image _closedImage = Properties.Resources.closed;
        private Image _openImage;

        public Image OpenImage { get => _openImage; set => _openImage = value; }

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
            if (OpenImage != null)
            {
                Image = OpenImage;
                return true;
            }
            return false;
        }
    }
}
