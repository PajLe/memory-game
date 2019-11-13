using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
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
        private int closedFields;
        private ClosableField previousOpenedField = null;

        // game parameters
        private int rowSize; // = 6;
        private int columnSize; // = 10;
        private int pairCount; // = 10;
        private int differentImageCount; // = 5;

        public event EventHandler firstOpened = null;
        public event EventHandler lastOpened = null;

        public new void Dispose()
        {
            base.Dispose();
            if (grid != null)
                grid = null;
        }

        #region Constructors

        public MemoryGrid() : this(6, 10, 10, 5) { }

        public MemoryGrid(int rowSize, int columnSize, int pairCount, int differentImageCount)
        {
            setSizes(rowSize, columnSize, pairCount, differentImageCount);
            allocateGrid();
            // Location = new System.Drawing.Point()
            this.ClientSize = new Size(columnSize * (fieldWidth + 3), rowSize * (fieldHeight + 3));
            initGame();
        }

        #region Constructor Methods

        private void setSizes(int rowSize, int columnSize, int pairCount, int differentImageCount)
        {
            this.rowSize = (rowSize < 6) ? 6 : rowSize;
            this.columnSize = (columnSize < 10) ? 10 : columnSize;
            this.pairCount = (pairCount < 10) ? 10 : pairCount;
            this.differentImageCount = (differentImageCount < 5) ? 5 : differentImageCount;
        }

        private void allocateGrid()
        {
            grid = new Field[rowSize][];
            for (int i = 0; i < rowSize; i++)
                grid[i] = new Field[columnSize];
            closedFields = rowSize * columnSize;
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
                        if (x % 2 == 0)
                        {
                            field.OpenImage = Properties.Resources._1;
                            field.ImageName = nameof(Properties.Resources._1);
                        }
                        else
                        {
                            field.OpenImage = Properties.Resources._2;
                            field.ImageName = nameof(Properties.Resources._2);
                        }
                        field.Click += new EventHandler(Field_Click);

                        grid[y][x] = field;
                        this.Controls.Add(grid[y][x]);
                    }
                }
            }
            differentImages();
        }
        #endregion Constructor Methods

        #endregion Constructors

        private List<Image> differentImages()
        {
            List<Image> images = new List<Image>();
            for(int i = 0; i < differentImageCount; i++)
            {
                ResourceManager resourceManager = new ResourceManager(typeof(Properties.Resources));
                ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                foreach (DictionaryEntry entry in resourceSet)
                {
                    string resourceKey = entry.Key.ToString();
                    MessageBox.Show(resourceKey);
                    object resource = entry.Value;
                }
            }
            return images;
        }

        #region Event Handlers

        private void Field_Click(object sender, EventArgs e)
        {
            Field fld = sender as Field;
            if (fld == null)
                return;
            if (!fld.Open())
                return;
            Application.DoEvents();
            closedFields--;
            StartAndEndHandle();
            if (previousOpenedField == null)
                previousOpenedField = fld as ClosableField;
            else
            {
                if (!previousOpenedField.ImageName.Equals(fld.ImageName) && fld as ClosableField != null)
                    CloseFieldsRoutine(fld as ClosableField);
                else
                    previousOpenedField = null;
            }
        }

        private void CloseFieldsRoutine(ClosableField currentOpenedField)
        {
            System.Threading.Thread.Sleep(1000);
            /**Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(closeEmUp);
            timer.Start();
            */
            previousOpenedField.Close();
            previousOpenedField = null;
            closedFields++;
            currentOpenedField.Close();
            closedFields++;
        }

        /*private void closeEmUp(object sender, EventArgs e)
        {
            (sender as Timer).Stop();
            previousOpenedField.Close();
            previousOpenedField = null;
            closedFields++;
            //currentOpenedField.Close();
            closedFields++;
        }*/

        private void StartAndEndHandle()
        {
            if (firstOpened != null)
            {
                firstOpened.Invoke(this, null);
                firstOpened = null;
            }
            if (firstOpened == null && lastOpened != null && closedFields == 0)
            {
                lastOpened.Invoke(this, null);
                lastOpened = null;
            }
        }

        #endregion Event Handlers
    }
}
