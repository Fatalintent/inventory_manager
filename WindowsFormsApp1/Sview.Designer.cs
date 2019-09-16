namespace WindowsFormsApp1
{
    partial class Sview
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
            this.dataOUTPUT = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataOUTPUT)).BeginInit();
            this.SuspendLayout();
            // 
            // dataOUTPUT
            // 
            this.dataOUTPUT.AllowUserToAddRows = false;
            this.dataOUTPUT.AllowUserToDeleteRows = false;
            this.dataOUTPUT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataOUTPUT.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataOUTPUT.Location = new System.Drawing.Point(15, 14);
            this.dataOUTPUT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataOUTPUT.Name = "dataOUTPUT";
            this.dataOUTPUT.ReadOnly = true;
            this.dataOUTPUT.Size = new System.Drawing.Size(1488, 759);
            this.dataOUTPUT.TabIndex = 56;
            // 
            // Sview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 786);
            this.Controls.Add(this.dataOUTPUT);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Sview";
            this.Text = "Sview";
            this.Load += new System.EventHandler(this.Sview_Load);
            this.Resize += new System.EventHandler(this.Sview_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataOUTPUT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataOUTPUT;
    }
}