using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_game
{
    public partial class GridConfiguration : Form
    {
        public GridConfiguration()
        {
            InitializeComponent();
        }

        private void numericUpDownPair_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownColumn.Value * numericUpDownRow.Value < numericUpDownPair.Value * 2)
                numericUpDownPair.Value = numericUpDownColumn.Value * numericUpDownRow.Value;
        }

        private void numericUpDownPictures_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownPictures.Value > numericUpDownPair.Value)
                numericUpDownPictures.Value = numericUpDownPair.Value;
        }

        private void buttonSaveConfiguration_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream("config.txt",FileMode.Create)))
            {
                sw.WriteLine(numericUpDownColumn.Value);
                sw.WriteLine(numericUpDownRow.Value);
                sw.WriteLine(numericUpDownPair.Value);
                sw.WriteLine(numericUpDownPictures.Value);
            }
            this.Close();
        }
    }
}
