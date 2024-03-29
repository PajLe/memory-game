﻿using Game_data;
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
    public partial class MainForm : Form
    {
        private MemoryGrid grid;
        private Timer gameTimer;
        private int timePlayed;

        public MainForm()
        {
            InitializeComponent();
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
            int column, row, pair, diffPic;
            readFromConfig(out column, out row, out pair, out diffPic);
            grid = new MemoryGrid(row, column, pair, diffPic);
            grid.Location = new Point(0, labelTimer.Location.Y + labelTimer.Height);
            
            grid.firstOpened += new EventHandler(timerStart);
            grid.lastOpened += new EventHandler(timerStop);
            this.Controls.Add(grid);

            labelTimer.Text = "0";
            labelTimer.Location = new Point((grid.Width - labelTimer.Width) / 2, labelTimer.Location.Y);
            labelTimer.Visible = true;
        }

        private void readFromConfig(out int column, out int row, out int pair, out int diffPic)
        {
            try
            {
                using (StreamReader sr = new StreamReader(new FileStream("config.txt", FileMode.Open)))
                {
                    column = int.Parse(sr.ReadLine());
                    row = int.Parse(sr.ReadLine());
                    pair = int.Parse(sr.ReadLine());
                    diffPic = int.Parse(sr.ReadLine());
                }
            }
            catch (Exception e)
            {
                column = row = pair = diffPic = 0;
            }
        }

        private void timerStop(object sender, EventArgs e)
        {
            gameTimer.Stop();
            MessageBox.Show("pobedili ste za " + timePlayed + " sekundi uwu");
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

        private void configureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GridConfiguration form = new GridConfiguration();
            form.ShowDialog();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grid != null)
                grid.OpenAllFields();
        }
    }
}
