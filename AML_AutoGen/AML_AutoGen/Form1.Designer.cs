namespace AML_AutoGen
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._CTV = new System.Windows.Forms.TreeView();
            //this._CaexListBox = new System.Windows.Forms.ListBox();
            this._BopenCAEX = new System.Windows.Forms.Button();
            this._openFile = new System.Windows.Forms.OpenFileDialog();
            this._FileName = new System.Windows.Forms.Label();
            this._generatePLC = new System.Windows.Forms.Button();
            this._PB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._PB)).BeginInit();
            this.SuspendLayout();
            // 
            // _CTV CAEX TreeView
            // 
            this._CTV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._CTV.BackColor = System.Drawing.Color.GhostWhite;
            this._CTV.Location = new System.Drawing.Point(12, 97);
            this._CTV.Name = "_CTV";
            this._CTV.Size = new System.Drawing.Size(629, 215);
            this._CTV.TabIndex = 1;
            // 
            // _BopenCAEX
            // 
            this._BopenCAEX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._BopenCAEX.BackColor = System.Drawing.Color.Azure;
            this._BopenCAEX.Location = new System.Drawing.Point(12, 55);
            this._BopenCAEX.Name = "_BopenCAEX";
            this._BopenCAEX.Size = new System.Drawing.Size(629, 36);
            this._BopenCAEX.TabIndex = 0;
            this._BopenCAEX.Text = "Open AutomationML file";
            this._BopenCAEX.UseVisualStyleBackColor = false;
            this._BopenCAEX.Click += new System.EventHandler(this._BopenCAEX_Click);
            // 
            // _openFile
            // 
            this._openFile.FileName = "*.aml";
            // 
            // _FileName
            // 
            this._FileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._FileName.AutoSize = true;
            this._FileName.Location = new System.Drawing.Point(15, 350);
            this._FileName.Name = "_FileName";
            this._FileName.Size = new System.Drawing.Size(16, 13);
            this._FileName.TabIndex = 2;
            this._FileName.Text = "...";
            // 
            // _generatePLC
            // 
            this._generatePLC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._generatePLC.BackColor = System.Drawing.Color.Azure;
            this._generatePLC.Location = new System.Drawing.Point(12, 318);
            this._generatePLC.Name = "_generatePLC";
            this._generatePLC.Size = new System.Drawing.Size(629, 36);
            this._generatePLC.TabIndex = 3;
            this._generatePLC.Text = "Generate";
            this._generatePLC.UseVisualStyleBackColor = false;
            this._generatePLC.Click += new System.EventHandler(this._BgeneratePLC_Click);
            // 
            // _PB PictureBox
            // 
            this._PB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._PB.Image = ((System.Drawing.Image)(resources.GetObject("_PB.Image")));
            this._PB.Location = new System.Drawing.Point(243, 12);
            this._PB.Name = "_PB";
            this._PB.Size = new System.Drawing.Size(160, 37);
            this._PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._PB.TabIndex = 4;
            this._PB.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 365);
            this.Controls.Add(this._CTV);
            //this.Controls.Add(this._CaexListBox);
            this.Controls.Add(this._BopenCAEX);
            this.Controls.Add(this._generatePLC);
            this._generatePLC.Enabled = false;
            this.Controls.Add(this._PB);
            this.Name = "Form1";
            this.Text = "Code generation AutomationML ";
            ((System.ComponentModel.ISupportInitialize)(this._PB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // declaration of the necessary variables to create a GUI with a single button to open an AutomationML file.
        private System.Windows.Forms.TreeView _CTV;
        //private System.Windows.Forms.ListBox _CaexListBox;        
        private System.Windows.Forms.Button _BopenCAEX;
        private System.Windows.Forms.OpenFileDialog _openFile;
        private System.Windows.Forms.Label _FileName;
        private System.Windows.Forms.Button _generatePLC;
        private System.Windows.Forms.PictureBox _PB;        
    }
}

