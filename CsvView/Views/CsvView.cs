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
            csvDataGrid.DataSource = _controller.LoadCsvFile();

            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var _csvReader = new CachedCsvReader(new StreamReader(ofd.FileName), false))
                        {
                            csvDataGrid.DataSource = _csvReader;
                            // using use streamreader in object _csvReader.
                            // exiting brackets destroys the obj streamreader. if returned crashes occurs.
                        }
                    }
                    finally
                    {

                    }
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
