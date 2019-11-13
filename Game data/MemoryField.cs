using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_data
{
    class MemoryField : ClosableField
    {

        public MemoryField(int xPos, int yPos, int xSize, int ySize)
        {
            ClientSize = new Size(xSize, ySize);
            Location = new Point(xPos, yPos);
        }

        
    }
}
