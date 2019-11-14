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
            initClosableFields();
            for (int y = 0; y < rowSize; y++)
            {
                for (int x = 0; x < columnSize; x++)
                {
                    if (grid[y][x] == null)
                    {
                        Field field = new EmptyField(x * (fieldWidth + 3),
                            y * (fieldHeight + 3),
                            fieldWidth,
                            fieldHeight);
                        field.Click += new EventHandler(Field_Click);

                        grid[y][x] = field;
                    }
                    this.Controls.Add(grid[y][x]);
                }
            }
        }

        private void initClosableFields()
        {
            Queue<Point> differentPoints = differentFieldPoints();
            List<Image> images = differentImages();
            while (differentPoints.Count > 0)
            {
                foreach (Image image in images)
                {
                    Point p1 = differentPoints.Dequeue();
                    createMemoryField(p1.X, p1.Y, image);

                    Point p2 = differentPoints.Dequeue();
                    createMemoryField(p2.X, p2.Y, image);
                    if (differentPoints.Count == 0) break;
                }
            }
        }

        private void createMemoryField(int x, int y, Image image)
        {
            Field field = new MemoryField(x * (fieldWidth + 3),
                            y * (fieldHeight + 3),
                            fieldWidth,
                            fieldHeight);
            field.OpenImage = image;
            field.OpenImage.Tag = image.Tag;
            field.Click += new EventHandler(Field_Click);
            grid[y][x] = field;
        }

        private Queue<Point> differentFieldPoints()
        {
            Random r = new Random();
            Queue<Point> points = new Queue<Point>();

            for (int i = 0; i < pairCount * 2; i++)
            {
                Point p;
                do
                {
                    int x = r.Next(0, columnSize);
                    int y = r.Next(0, rowSize);
                    p = new Point(x, y);
                } while (points.Contains(p));
                points.Enqueue(p);
            }

            return points;
        }

        private List<Image> differentImages()
        {
            ResourceManager resourceManager = new ResourceManager(typeof(Properties.Resources));
            ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            List<string> imageResourceKeys = new List<string>();
            foreach (DictionaryEntry entry in resourceSet)
            {
                string resourceKey = entry.Key.ToString();
                if (!resourceKey.Equals("closed") && !resourceKey.Equals("empty"))
                    imageResourceKeys.Add(resourceKey);
            }

            List<int> randomies = new List<int>();
            Random r = new Random();
            for (int i = 0; i < differentImageCount; i++)
            {
                int num;
                while (randomies.Contains(num = r.Next(0, imageResourceKeys.Count))) ;
                randomies.Add(num);
            }

            List<Image> images = new List<Image>();
            foreach (int c in randomies)
            {
                Image toAdd = resourceSet.GetObject(imageResourceKeys[c]) as Image;
                if (toAdd != null)
                    toAdd.Tag = imageResourceKeys[c];
                images.Add(toAdd);
            }
            return images;
        }
        #endregion Constructor Methods

        #endregion Constructors

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
            this.Parent.Text = closedFields.ToString();
            BeginAndEndHandle();
            if (previousOpenedField == null)
                previousOpenedField = fld as ClosableField;
            else
            {
                if (!previousOpenedField.OpenImage.Tag.Equals(fld.OpenImage.Tag))
                    CloseFieldsRoutine(fld as ClosableField);
                else
                    previousOpenedField = null;
            }
        }

        private void CloseFieldsRoutine(ClosableField currentOpenedField)
        {
            if (currentOpenedField == null)
                return;
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
            this.Parent.Text = closedFields.ToString();
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

        private void BeginAndEndHandle()
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
