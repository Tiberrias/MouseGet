namespace MouseGet
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelZValue = new System.Windows.Forms.Label();
            this.numericUpDownZValue = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelSavedNumber = new System.Windows.Forms.Label();
            this.textBoxSavedNumber = new System.Windows.Forms.TextBox();
            this.saveFileDialogCoordinates = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZValue)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(13, 13);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(277, 13);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Użyj CTRL + E aby włączyć/wyłączyć przechwytywanie.";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatus.ForeColor = System.Drawing.Color.Crimson;
            this.labelStatus.Location = new System.Drawing.Point(13, 30);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(218, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Zapisywanie koordynatów wyłączone";
            // 
            // labelZValue
            // 
            this.labelZValue.AutoSize = true;
            this.labelZValue.Location = new System.Drawing.Point(13, 49);
            this.labelZValue.Name = "labelZValue";
            this.labelZValue.Size = new System.Drawing.Size(102, 13);
            this.labelZValue.TabIndex = 2;
            this.labelZValue.Text = "Aktualna wartość Z:";
            // 
            // numericUpDownZValue
            // 
            this.numericUpDownZValue.Location = new System.Drawing.Point(121, 47);
            this.numericUpDownZValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownZValue.Name = "numericUpDownZValue";
            this.numericUpDownZValue.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownZValue.TabIndex = 3;
            this.numericUpDownZValue.ValueChanged += new System.EventHandler(this.OnZValueChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(16, 101);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(99, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Zapisz do pliku...";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(121, 101);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(159, 23);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Wyczyść zapisane koordynaty";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.OnClearClick);
            // 
            // labelSavedNumber
            // 
            this.labelSavedNumber.AutoSize = true;
            this.labelSavedNumber.Location = new System.Drawing.Point(13, 75);
            this.labelSavedNumber.Name = "labelSavedNumber";
            this.labelSavedNumber.Size = new System.Drawing.Size(109, 13);
            this.labelSavedNumber.TabIndex = 6;
            this.labelSavedNumber.Text = "Zapisane koordynaty:";
            // 
            // textBoxSavedNumber
            // 
            this.textBoxSavedNumber.Location = new System.Drawing.Point(121, 73);
            this.textBoxSavedNumber.Name = "textBoxSavedNumber";
            this.textBoxSavedNumber.ReadOnly = true;
            this.textBoxSavedNumber.Size = new System.Drawing.Size(54, 20);
            this.textBoxSavedNumber.TabIndex = 7;
            this.textBoxSavedNumber.Text = "0";
            // 
            // saveFileDialogCoordinates
            // 
            this.saveFileDialogCoordinates.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveToFile);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 132);
            this.Controls.Add(this.textBoxSavedNumber);
            this.Controls.Add(this.labelSavedNumber);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.numericUpDownZValue);
            this.Controls.Add(this.labelZValue);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MouseGet 1.0";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelZValue;
        private System.Windows.Forms.NumericUpDown numericUpDownZValue;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelSavedNumber;
        private System.Windows.Forms.TextBox textBoxSavedNumber;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCoordinates;
    }
}

