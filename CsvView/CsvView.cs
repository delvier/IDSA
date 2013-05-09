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
                            List<Company> headerList = new List<Company>();
                            headerList.Add(
                                new Company() { name = null, id = null, link = null, undefined = null }
                                );
                            //Use dictionary ? enums ?
                            //Create Header class ?

                            //DataGridViewColumnCollection testColection;

                            csvDataGrid.DataSource = _csvReader;
                            
                            foreach (var col in csvDataGrid.Columns)
                            {
                                //
                            }
                                
                            //csvDataGrid.Columns[0].HeaderText = "testName1";
                            
                            // rozkodowanie kolumn.csv
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
