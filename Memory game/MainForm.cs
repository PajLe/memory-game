using Game_data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_game
{
    public partial class MainForm : Form
    {
        private MemoryGrid grid;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void gameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (grid != null)
            {
                this.Controls.Remove(grid);
                grid.Dispose();
            }
            grid = new MemoryGrid();
            grid.Location = new Point(0, labelTimer.Location.Y + labelTimer.Height);
            this.Controls.Add(grid);

            labelTimer.Text = "00:00";
            labelTimer.Location = new Point((grid.Width - labelTimer.Width) / 2, labelTimer.Location.Y);
            labelTimer.Visible = true;
        }

        
    }
}
