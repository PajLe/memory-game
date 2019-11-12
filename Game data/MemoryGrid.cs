using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_data
{
    public class MemoryGrid : UserControl, IDisposable
    {
        private static readonly int fieldWidth = 100;
        private static readonly int fieldHeight = 100;
        private Field[][] grid;

        // game parameters
        private int rowSize; // = 6;
        private int columnSize; // = 10;
        private int pairCount; // = 10;
        private int pictureCount; // = 5;

        public new void Dispose()
        {
            base.Dispose();
            if (grid != null)
                grid = null;
        }

        public MemoryGrid() : this(6, 10, 10, 5) { }

        public MemoryGrid(int rowSize, int columnSize, int pairCount, int pictureCount)
        {
            this.rowSize = rowSize;
            this.columnSize = columnSize;
            this.pairCount = pairCount;
            this.pictureCount = pictureCount;
            allocateGrid();
            // Location = new System.Drawing.Point()
            ClientSize = new Size(columnSize * (fieldWidth + 3), rowSize * (fieldHeight + 3));
            initGame();
        }

        private void allocateGrid()
        {
            grid = new Field[rowSize][];
            for (int i = 0; i < rowSize; i++)
                grid[i] = new Field[columnSize];
        }

        private void initGame()
        {
            for (int y = 0; y < rowSize; y++)
            {
                for (int x = 0; x < columnSize; x++)
                {
                    if (grid[y][x] == null)
                    {
                        Field field = new MemoryField(x * (fieldWidth + 3),
                            y * (fieldHeight + 3),
                            fieldWidth,
                            fieldHeight);
                        field.OpenImage = Properties.Resources._1;
                        field.Click += new EventHandler(Field_Click);

                        grid[y][x] = field;
                        this.Controls.Add(grid[y][x]);
                    }
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
