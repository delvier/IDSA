namespace IDSA.Views.PropertyView
{
    partial class BasicGridView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.baseViewGrid = new System.Windows.Forms.DataGridView();
            this.titleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.baseViewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // baseViewGrid
            // 
            this.baseViewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.baseViewGrid.BackgroundColor = System.Drawing.Color.Honeydew;
            this.baseViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.baseViewGrid.Location = new System.Drawing.Point(3, 52);
            this.baseViewGrid.Name = "baseViewGrid";
            this.baseViewGrid.Size = new System.Drawing.Size(438, 246);
            this.baseViewGrid.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleLabel.Location = new System.Drawing.Point(3, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(52, 26);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Title";
            // 
            // BasicGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.baseViewGrid);
            this.Name = "BasicGridView";
            this.Size = new System.Drawing.Size(441, 301);
            ((System.ComponentModel.ISupportInitialize)(this.baseViewGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView baseViewGrid;
        private System.Windows.Forms.Label titleLabel;
    }
}
