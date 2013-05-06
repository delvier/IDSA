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
                            csvDataGrid.Columns[0].HeaderText = "testName1";
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
