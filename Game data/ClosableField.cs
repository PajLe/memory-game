using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_data
{
    public abstract class ClosableField : Field
    {
        public bool Close() {
            if (_closedImage != null)
            {
                Image = _closedImage;
                return true;
            }
            return false;
        }
    }
}
