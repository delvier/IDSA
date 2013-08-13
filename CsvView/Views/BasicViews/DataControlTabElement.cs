using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDSA.Views.BasicViews
{
    interface IDataControlTabElement
    {
        Label fieldName { get; set; }
        TextBox fieldValue { get; set; }
    }

    public class DataControlTabElement : UserControl, IDataControlTabElement
    {
        public Label fieldName { get; set; }
        public TextBox fieldValue { get; set; }

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
            this.fieldName.Location = new System.Drawing.Point(4, 6);
            this.fieldName.Width = 122;
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(125, 13);
            this.fieldName.TabIndex = 0;
            this.fieldName.Text = "fieldName";
            // 
            // fieldValue
            // 
            this.fieldValue.Location = new System.Drawing.Point(45, 3);
            this.fieldValue.Name = "fieldValue";
            this.fieldValue.Size = new System.Drawing.Size(100, 20);
            this.fieldValue.TabIndex = 1;
            // 
            // DataControlTabElement
            // 
            this.Controls.Add(this.fieldValue);
            this.Controls.Add(this.fieldName);
            this.Name = "DataControlTabElement";
            this.Size = new System.Drawing.Size(156, 27);
            this.ResumeLayout(false);
            this.PerformLayout();
        }


    }

}
