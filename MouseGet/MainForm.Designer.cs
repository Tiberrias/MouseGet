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
            this.labelFirstReference = new System.Windows.Forms.Label();
            this.labelSecondReference = new System.Windows.Forms.Label();
            this.labelInfo2 = new System.Windows.Forms.Label();
            this.textBoxFirstReferenceScreenX = new System.Windows.Forms.TextBox();
            this.textBoxFirstReferenceScreenY = new System.Windows.Forms.TextBox();
            this.textBoxSecondReferenceScreenX = new System.Windows.Forms.TextBox();
            this.textBoxSecondReferenceScreenY = new System.Windows.Forms.TextBox();
            this.textBoxFirstReferenceMapX = new System.Windows.Forms.TextBox();
            this.textBoxFirstReferenceMapY = new System.Windows.Forms.TextBox();
            this.textBoxSecondReferenceMapX = new System.Windows.Forms.TextBox();
            this.textBoxSecondReferenceMapY = new System.Windows.Forms.TextBox();
            this.labelForward1 = new System.Windows.Forms.Label();
            this.labelForward2 = new System.Windows.Forms.Label();
            this.buttonFirstReferenceClear = new System.Windows.Forms.Button();
            this.buttonSecondReferenceClear = new System.Windows.Forms.Button();
            this.buttonToggleOnTop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZValue)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(13, 13);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(280, 13);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Użyj CTRL + E aby włączyć/wyłączyć przechwytywanie. ";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatus.ForeColor = System.Drawing.Color.Crimson;
            this.labelStatus.Location = new System.Drawing.Point(12, 142);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(218, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Zapisywanie koordynatów wyłączone";
            // 
            // labelZValue
            // 
            this.labelZValue.AutoSize = true;
            this.labelZValue.Location = new System.Drawing.Point(12, 161);
            this.labelZValue.Name = "labelZValue";
            this.labelZValue.Size = new System.Drawing.Size(102, 13);
            this.labelZValue.TabIndex = 2;
            this.labelZValue.Text = "Aktualna wartość Z:";
            // 
            // numericUpDownZValue
            // 
            this.numericUpDownZValue.DecimalPlaces = 2;
            this.numericUpDownZValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownZValue.Location = new System.Drawing.Point(120, 159);
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
            this.buttonSave.Location = new System.Drawing.Point(15, 213);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(148, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Przetwórz i zapisz do pliku...";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(169, 213);
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
            this.labelSavedNumber.Location = new System.Drawing.Point(12, 187);
            this.labelSavedNumber.Name = "labelSavedNumber";
            this.labelSavedNumber.Size = new System.Drawing.Size(109, 13);
            this.labelSavedNumber.TabIndex = 6;
            this.labelSavedNumber.Text = "Zapisane koordynaty:";
            // 
            // textBoxSavedNumber
            // 
            this.textBoxSavedNumber.Location = new System.Drawing.Point(120, 185);
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
            // labelFirstReference
            // 
            this.labelFirstReference.AutoSize = true;
            this.labelFirstReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFirstReference.ForeColor = System.Drawing.Color.Crimson;
            this.labelFirstReference.Location = new System.Drawing.Point(13, 60);
            this.labelFirstReference.Name = "labelFirstReference";
            this.labelFirstReference.Size = new System.Drawing.Size(156, 13);
            this.labelFirstReference.TabIndex = 8;
            this.labelFirstReference.Text = "Odczyt pierwszego punktu";
            // 
            // labelSecondReference
            // 
            this.labelSecondReference.AutoSize = true;
            this.labelSecondReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSecondReference.ForeColor = System.Drawing.Color.Crimson;
            this.labelSecondReference.Location = new System.Drawing.Point(12, 101);
            this.labelSecondReference.Name = "labelSecondReference";
            this.labelSecondReference.Size = new System.Drawing.Size(135, 13);
            this.labelSecondReference.TabIndex = 9;
            this.labelSecondReference.Text = "Odczyt druiego punktu";
            // 
            // labelInfo2
            // 
            this.labelInfo2.AutoSize = true;
            this.labelInfo2.Location = new System.Drawing.Point(13, 36);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new System.Drawing.Size(309, 13);
            this.labelInfo2.TabIndex = 10;
            this.labelInfo2.Text = "Użyj CRTL + 1, CTRL + 2 aby przechwycić punkty referencyjne.";
            // 
            // textBoxFirstReferenceScreenX
            // 
            this.textBoxFirstReferenceScreenX.Location = new System.Drawing.Point(16, 78);
            this.textBoxFirstReferenceScreenX.Name = "textBoxFirstReferenceScreenX";
            this.textBoxFirstReferenceScreenX.ReadOnly = true;
            this.textBoxFirstReferenceScreenX.Size = new System.Drawing.Size(36, 20);
            this.textBoxFirstReferenceScreenX.TabIndex = 11;
            this.textBoxFirstReferenceScreenX.Text = "X";
            // 
            // textBoxFirstReferenceScreenY
            // 
            this.textBoxFirstReferenceScreenY.Location = new System.Drawing.Point(58, 78);
            this.textBoxFirstReferenceScreenY.Name = "textBoxFirstReferenceScreenY";
            this.textBoxFirstReferenceScreenY.ReadOnly = true;
            this.textBoxFirstReferenceScreenY.Size = new System.Drawing.Size(36, 20);
            this.textBoxFirstReferenceScreenY.TabIndex = 12;
            this.textBoxFirstReferenceScreenY.Text = "Y";
            // 
            // textBoxSecondReferenceScreenX
            // 
            this.textBoxSecondReferenceScreenX.Location = new System.Drawing.Point(16, 119);
            this.textBoxSecondReferenceScreenX.Name = "textBoxSecondReferenceScreenX";
            this.textBoxSecondReferenceScreenX.ReadOnly = true;
            this.textBoxSecondReferenceScreenX.Size = new System.Drawing.Size(36, 20);
            this.textBoxSecondReferenceScreenX.TabIndex = 13;
            this.textBoxSecondReferenceScreenX.Text = "X";
            // 
            // textBoxSecondReferenceScreenY
            // 
            this.textBoxSecondReferenceScreenY.Location = new System.Drawing.Point(58, 119);
            this.textBoxSecondReferenceScreenY.Name = "textBoxSecondReferenceScreenY";
            this.textBoxSecondReferenceScreenY.ReadOnly = true;
            this.textBoxSecondReferenceScreenY.Size = new System.Drawing.Size(36, 20);
            this.textBoxSecondReferenceScreenY.TabIndex = 14;
            this.textBoxSecondReferenceScreenY.Text = "Y";
            // 
            // textBoxFirstReferenceMapX
            // 
            this.textBoxFirstReferenceMapX.Location = new System.Drawing.Point(121, 78);
            this.textBoxFirstReferenceMapX.Name = "textBoxFirstReferenceMapX";
            this.textBoxFirstReferenceMapX.Size = new System.Drawing.Size(55, 20);
            this.textBoxFirstReferenceMapX.TabIndex = 15;
            this.textBoxFirstReferenceMapX.Text = "X";
            // 
            // textBoxFirstReferenceMapY
            // 
            this.textBoxFirstReferenceMapY.Location = new System.Drawing.Point(182, 78);
            this.textBoxFirstReferenceMapY.Name = "textBoxFirstReferenceMapY";
            this.textBoxFirstReferenceMapY.Size = new System.Drawing.Size(56, 20);
            this.textBoxFirstReferenceMapY.TabIndex = 16;
            this.textBoxFirstReferenceMapY.Text = "Y";
            // 
            // textBoxSecondReferenceMapX
            // 
            this.textBoxSecondReferenceMapX.Location = new System.Drawing.Point(120, 119);
            this.textBoxSecondReferenceMapX.Name = "textBoxSecondReferenceMapX";
            this.textBoxSecondReferenceMapX.Size = new System.Drawing.Size(56, 20);
            this.textBoxSecondReferenceMapX.TabIndex = 17;
            this.textBoxSecondReferenceMapX.Text = "X";
            // 
            // textBoxSecondReferenceMapY
            // 
            this.textBoxSecondReferenceMapY.Location = new System.Drawing.Point(182, 119);
            this.textBoxSecondReferenceMapY.Name = "textBoxSecondReferenceMapY";
            this.textBoxSecondReferenceMapY.Size = new System.Drawing.Size(56, 20);
            this.textBoxSecondReferenceMapY.TabIndex = 18;
            this.textBoxSecondReferenceMapY.Text = "Y";
            // 
            // labelForward1
            // 
            this.labelForward1.AutoSize = true;
            this.labelForward1.Location = new System.Drawing.Point(100, 81);
            this.labelForward1.Name = "labelForward1";
            this.labelForward1.Size = new System.Drawing.Size(19, 13);
            this.labelForward1.TabIndex = 19;
            this.labelForward1.Text = "=>";
            // 
            // labelForward2
            // 
            this.labelForward2.AutoSize = true;
            this.labelForward2.Location = new System.Drawing.Point(100, 122);
            this.labelForward2.Name = "labelForward2";
            this.labelForward2.Size = new System.Drawing.Size(19, 13);
            this.labelForward2.TabIndex = 20;
            this.labelForward2.Text = "=>";
            // 
            // buttonFirstReferenceClear
            // 
            this.buttonFirstReferenceClear.Location = new System.Drawing.Point(244, 76);
            this.buttonFirstReferenceClear.Name = "buttonFirstReferenceClear";
            this.buttonFirstReferenceClear.Size = new System.Drawing.Size(84, 23);
            this.buttonFirstReferenceClear.TabIndex = 21;
            this.buttonFirstReferenceClear.Text = "Wyczyść";
            this.buttonFirstReferenceClear.UseVisualStyleBackColor = true;
            this.buttonFirstReferenceClear.Click += new System.EventHandler(this.OnFirstReferenceClearClick);
            // 
            // buttonSecondReferenceClear
            // 
            this.buttonSecondReferenceClear.Location = new System.Drawing.Point(244, 117);
            this.buttonSecondReferenceClear.Name = "buttonSecondReferenceClear";
            this.buttonSecondReferenceClear.Size = new System.Drawing.Size(84, 23);
            this.buttonSecondReferenceClear.TabIndex = 22;
            this.buttonSecondReferenceClear.Text = "Wyczyść";
            this.buttonSecondReferenceClear.UseVisualStyleBackColor = true;
            this.buttonSecondReferenceClear.Click += new System.EventHandler(this.OnSecondReferenceClearClick);
            // 
            // buttonToggleOnTop
            // 
            this.buttonToggleOnTop.Location = new System.Drawing.Point(182, 182);
            this.buttonToggleOnTop.Name = "buttonToggleOnTop";
            this.buttonToggleOnTop.Size = new System.Drawing.Size(146, 23);
            this.buttonToggleOnTop.TabIndex = 23;
            this.buttonToggleOnTop.Text = "Przełącz na wierzch";
            this.buttonToggleOnTop.UseVisualStyleBackColor = true;
            this.buttonToggleOnTop.Click += new System.EventHandler(this.OnToggleOnTopClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 243);
            this.Controls.Add(this.buttonToggleOnTop);
            this.Controls.Add(this.buttonSecondReferenceClear);
            this.Controls.Add(this.buttonFirstReferenceClear);
            this.Controls.Add(this.labelForward2);
            this.Controls.Add(this.labelForward1);
            this.Controls.Add(this.textBoxSecondReferenceMapY);
            this.Controls.Add(this.textBoxSecondReferenceMapX);
            this.Controls.Add(this.textBoxFirstReferenceMapY);
            this.Controls.Add(this.textBoxFirstReferenceMapX);
            this.Controls.Add(this.textBoxSecondReferenceScreenY);
            this.Controls.Add(this.textBoxSecondReferenceScreenX);
            this.Controls.Add(this.textBoxFirstReferenceScreenY);
            this.Controls.Add(this.textBoxFirstReferenceScreenX);
            this.Controls.Add(this.labelInfo2);
            this.Controls.Add(this.labelSecondReference);
            this.Controls.Add(this.labelFirstReference);
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
            this.Text = "MouseGet 1.1";
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
        private System.Windows.Forms.Label labelFirstReference;
        private System.Windows.Forms.Label labelSecondReference;
        private System.Windows.Forms.Label labelInfo2;
        private System.Windows.Forms.TextBox textBoxFirstReferenceScreenX;
        private System.Windows.Forms.TextBox textBoxFirstReferenceScreenY;
        private System.Windows.Forms.TextBox textBoxSecondReferenceScreenX;
        private System.Windows.Forms.TextBox textBoxSecondReferenceScreenY;
        private System.Windows.Forms.TextBox textBoxFirstReferenceMapX;
        private System.Windows.Forms.TextBox textBoxFirstReferenceMapY;
        private System.Windows.Forms.TextBox textBoxSecondReferenceMapX;
        private System.Windows.Forms.TextBox textBoxSecondReferenceMapY;
        private System.Windows.Forms.Label labelForward1;
        private System.Windows.Forms.Label labelForward2;
        private System.Windows.Forms.Button buttonFirstReferenceClear;
        private System.Windows.Forms.Button buttonSecondReferenceClear;
        private System.Windows.Forms.Button buttonToggleOnTop;
    }
}

