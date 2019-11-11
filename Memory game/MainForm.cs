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
        private static readonly int fieldWidth = 100;
        private static readonly int fieldHeight = 100;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Field field = new MemoryField( x * (fieldWidth + 3), 
                        labelTimer.Location.Y + labelTimer.Height + y * (fieldHeight + 3), 
                        fieldWidth, 
                        fieldHeight);
                    field.OpenImage = Properties.Resources._1;
                    field.Click += new EventHandler(Field_Click);
                    this.Controls.Add(field);
                }
                
            }
            
        }

        private void Field_Click(object sender, EventArgs e)
        {
            Field fld = sender as Field;
            if (fld != null)
                fld.Open();
        }
        
    }
}
