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
        private Timer gameTimer;
        private int timePlayed;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void gameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timePlayed = 0;
            if (grid != null)
            {
                this.Controls.Remove(grid);
                grid.Dispose();
                gameTimer.Stop();
            }
            grid = new MemoryGrid();
            grid.Location = new Point(0, labelTimer.Location.Y + labelTimer.Height);
            
            grid.firstOpened += new EventHandler(timerStart);
            grid.lastOpened += new EventHandler(timerStop);
            this.Controls.Add(grid);

            labelTimer.Text = "0";
            labelTimer.Location = new Point((grid.Width - labelTimer.Width) / 2, labelTimer.Location.Y);
            labelTimer.Visible = true;
        }

        private void timerStop(object sender, EventArgs e)
        {
            gameTimer.Stop();
            MessageBox.Show("pobedili ste uwu");
        }

        private void timerStart(object sender, EventArgs e)
        {
            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += new EventHandler(timerTick);
            gameTimer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            labelTimer.Text = (++timePlayed).ToString();
            labelTimer.Location = new Point((grid.Width - labelTimer.Width) / 2, labelTimer.Location.Y);
        }
    }
}
