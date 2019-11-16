using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_data
{
    abstract class ClosableField : Field
    {
        public bool Close() {
            if (_closedImage != null && opened)
            {
                Image = _closedImage;
                opened = false;
                return true;
            }
            return false;
        }
    }
}
