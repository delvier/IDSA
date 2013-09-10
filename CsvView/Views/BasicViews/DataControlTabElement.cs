using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDSA.Views.BasicViews
{
    interface IDataControlTabElement
    {
        //Label fieldName;
        //TextBox fieldValue;
    }

    public class DataControlTabElement : UserControl, IDataControlTabElement
    {
        private Label fieldName;
        private TextBox fieldValue;

        public DataControlTabElement(String fieldName)
        {
            InitializeComponent();
            this.fieldName.Text = fieldName;

            InitTextBoxSettings();
        }

        public void InitTextBoxSettings()
        {
            fieldValue.Width = 60;
        }

        private void InitializeComponent()
        {
            this.fieldName = new System.Windows.Forms.Label();
            this.fieldValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fieldName
            // 
            this.fieldName.AutoSize = true;
            this.fieldName.Location = new System.Drawing.Point(3, 6);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(66, 13);
            this.fieldName.TabIndex = 0;
            this.fieldName.Text = "longtextlabel";
            // 
            // fieldValue
            // 
            this.fieldValue.AcceptsReturn = true;
            this.fieldValue.AcceptsTab = true;
            this.fieldValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldValue.Location = new System.Drawing.Point(3, 22);
            this.fieldValue.Name = "fieldValue";
            this.fieldValue.Size = new System.Drawing.Size(171, 20);
            this.fieldValue.TabIndex = 1;
            // 
            // DataControlTabElement
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.fieldName);
            this.Controls.Add(this.fieldValue);
            this.Name = "DataControlTabElement";
            this.Size = new System.Drawing.Size(176, 46);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }

}
