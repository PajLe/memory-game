namespace Memory_game
{
    partial class GridConfiguration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownColumn = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRow = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownPair = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownPictures = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSaveConfiguration = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPictures)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj kolona";
            // 
            // numericUpDownColumn
            // 
            this.numericUpDownColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownColumn.Location = new System.Drawing.Point(208, 63);
            this.numericUpDownColumn.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownColumn.Name = "numericUpDownColumn";
            this.numericUpDownColumn.Size = new System.Drawing.Size(120, 29);
            this.numericUpDownColumn.TabIndex = 1;
            this.numericUpDownColumn.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownRow
            // 
            this.numericUpDownRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownRow.Location = new System.Drawing.Point(208, 98);
            this.numericUpDownRow.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownRow.Name = "numericUpDownRow";
            this.numericUpDownRow.Size = new System.Drawing.Size(120, 29);
            this.numericUpDownRow.TabIndex = 3;
            this.numericUpDownRow.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Broj redova";
            // 
            // numericUpDownPair
            // 
            this.numericUpDownPair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPair.Location = new System.Drawing.Point(208, 160);
            this.numericUpDownPair.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPair.Name = "numericUpDownPair";
            this.numericUpDownPair.Size = new System.Drawing.Size(120, 29);
            this.numericUpDownPair.TabIndex = 5;
            this.numericUpDownPair.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPair.ValueChanged += new System.EventHandler(this.numericUpDownPair_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Broj parova";
            // 
            // numericUpDownPictures
            // 
            this.numericUpDownPictures.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPictures.Location = new System.Drawing.Point(208, 195);
            this.numericUpDownPictures.Maximum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.numericUpDownPictures.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownPictures.Name = "numericUpDownPictures";
            this.numericUpDownPictures.Size = new System.Drawing.Size(120, 29);
            this.numericUpDownPictures.TabIndex = 7;
            this.numericUpDownPictures.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownPictures.ValueChanged += new System.EventHandler(this.numericUpDownPictures_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Broj različitih slika";
            // 
            // buttonSaveConfiguration
            // 
            this.buttonSaveConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveConfiguration.Location = new System.Drawing.Point(121, 281);
            this.buttonSaveConfiguration.Name = "buttonSaveConfiguration";
            this.buttonSaveConfiguration.Size = new System.Drawing.Size(116, 55);
            this.buttonSaveConfiguration.TabIndex = 8;
            this.buttonSaveConfiguration.Text = "Sačuvaj";
            this.buttonSaveConfiguration.UseVisualStyleBackColor = true;
            this.buttonSaveConfiguration.Click += new System.EventHandler(this.buttonSaveConfiguration_Click);
            // 
            // GridConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 366);
            this.Controls.Add(this.buttonSaveConfiguration);
            this.Controls.Add(this.numericUpDownPictures);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownPair);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownRow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownColumn);
            this.Controls.Add(this.label1);
            this.Name = "GridConfiguration";
            this.Text = "Grid Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPictures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownColumn;
        private System.Windows.Forms.NumericUpDown numericUpDownRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownPair;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownPictures;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSaveConfiguration;
    }
}