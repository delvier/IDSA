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
        void RefreshView();
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
            var csv = _controller.LoadCsvFile(OpenDialog());
            if (csv != null)
            {
                csvDataGrid.DataSource = csv;
                csv.Dispose();

                var collection = _controller.getHeaders<CsvEnums._company>(csvDataGrid.Columns.Count);
                foreach (var element in collection)
                {
                    csvDataGrid.Columns[collection.IndexOf(element)].HeaderText = element.ToString();
                }
            }
            // TODO: resolve problem using vs controller. crash of null stream obj. assertion occurs.
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
                    return null;
                }
            }
        }

        private void baseView_Click(object sender, EventArgs e)
        {
            //_controller.selectColumns();
        }
        
        //public OpenFileDialog dialog
        //{
        //    get { return this.dialog; }
        //    set { this.dialog = (OpenFileDialog)value; }
        //}

        public void RefreshView()
        {
         //_controller.
        }
    }
}
