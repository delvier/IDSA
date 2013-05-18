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
        //void SetControler(CsvViewController ctr);
        //void LoadCsvFile();
        void BoxMsg(string s);
        string OpenDialog();
        void RefreshView();
        //OpenFileDialog dialog { get; set; }
    }

    public partial class CsvView : UserControl, ICsvView
    {
        private CsvViewController presenter;
        
        public CsvView()
        {
            InitializeComponent();

            presenter = ServiceLocator.Instance.Resolve<CsvViewController>(); 
            //presenter = new CsvViewController(this);
        }

        private void loadCsv_Click(object sender, EventArgs e)
        {
            var csv = presenter.LoadCsvFile(OpenDialog());
            if (csv != null)
            {
                csvDataGrid.DataSource = csv;
                csv.Dispose();

                var collection = presenter.getHeaders<CsvEnums._company>(csvDataGrid.Columns.Count);
                foreach (var element in collection)
                {
                    csvDataGrid.Columns[collection.IndexOf(element)].HeaderText = element.ToString();
                }
            }
            // TODO: resolve problem using vs controller. crash of null stream obj. assertion occurs.
            // TODO: Przeniesc dane z OpenDialog() tutaj????
            // chyba, ze OpenDIalog() bedzie wykorzystywany w tym view w wielu miejscach
        }

        //public void SetControler(CsvViewController ctr)
        //{
        //    presenter = ctr;
        //}

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
            //presenter.selectColumns();
        }
        
        //public OpenFileDialog dialog
        //{
        //    get { return this.dialog; }
        //    set { this.dialog = (OpenFileDialog)value; }
        //}

        public void RefreshView()
        {
            //presenter.
        }
    }
}
