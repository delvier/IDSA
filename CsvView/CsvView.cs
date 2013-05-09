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

namespace WindowsFormsApplication1
{
    public partial class CsvView : UserControl
    {
        public CsvView()
        {
            InitializeComponent();
        }

        private void loadCsv_Click(object sender, EventArgs e)
        {
            using ( var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var _csvReader = new CachedCsvReader(new StreamReader(ofd.FileName), false))
                        {
                            csvDataGrid.DataSource = _csvReader;
                            //set enums on collumns view.
                            if (Enum.GetNames(typeof(CsvEnums._company)).Length < csvDataGrid.Columns.Count)
                            {
                                MessageBox.Show("Mismatch enum.length != columns.count");
                            }
                            // rozkodowanie kolumn.csv - > ENUM (V)
                            foreach (CsvEnums._company cmp in Enum.GetValues(typeof(CsvEnums._company)))
                            {
                                csvDataGrid.Columns[(int) cmp].HeaderText = cmp.ToString();
                            }

                            //foreach (DataGridViewColumn col in csvDataGrid.Columns)
                            //{
                            //    col.HeaderText = "test";
                            //    //csvDataGrid.Columns[0].HeaderText = "testName1";
                            //}
                                
                            
                            // select columns ? - > transfer to data base.
                            // zarzadzanie wyswietlaniem kolumn.
                            // filtracja po wybranych kolumnach
                        }
                    }
                    catch (IOException ex)
                    {
                        //show error message.
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
