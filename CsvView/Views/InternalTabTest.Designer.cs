﻿using System.Windows.Forms;
namespace IDSA.Views
{
    partial class InternalTabTest
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TabControl internalTabContainer;

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
            this.SuspendLayout();
            // 
            // InternalTabTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "InternalTabTest";
            this.Size = new System.Drawing.Size(334, 256);
            this.ResumeLayout(false);

            // internal tab 
            internalTabContainer = new TabControl();
            internalTabContainer.Dock = DockStyle.Fill;
            this.Controls.Add(internalTabContainer);
        }

        #endregion
    }
}
