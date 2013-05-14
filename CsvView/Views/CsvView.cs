using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using LumenWorks.Framework.IO.Csv;
using CsvReaderModule;
using DBModule;
using CsvReaderModule.Controllers;

namespace WindowsFormsApplication1
{
    public interface ICsvView
    {
        void SetControler(CsvViewController ctr);
        //void LoadCsvFile();
        void BoxMsg(string s);
        string OpenDialog();
        //OpenFileDialog dialog { get; set; }
    }

    public partial class CsvView : UserControl, ICsvView
    {
        CsvViewController _controller;
        public CsvView()
        {
            InitializeComponent();
        }

        private void loadCsv_Click(object sender, EventArgs e)
        {
            this._controller.LoadCsvFile();
        }

        public void SetControler(CsvViewController ctr)
        {
            _controller = ctr;
        }

        public void BoxMsg(string s)
        {
            MessageBox.Show(s);
        }

        public string OpenDialog()
        {
            using (var tmpDialog = new OpenFileDialog())
            {
                if (tmpDialog.ShowDialog() == DialogResult.OK)
                {
                    return tmpDialog.FileName;
                }
                else
                {
                    return "";
                }
            }
        }
        
        //public OpenFileDialog dialog
        //{
        //    get { return this.dialog; }
        //    set { this.dialog = (OpenFileDialog)value; }
        //}
  
    }
}
