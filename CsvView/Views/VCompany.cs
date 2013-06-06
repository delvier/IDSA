using System.Windows.Forms;
using IDSA.Presenters;
using System;
using IDSA.Models;
using System.Drawing;
using System.Collections.Generic;
using System.Data;

namespace IDSA.Views
{
    public partial class VCompany : UserControl
    {
        VCompanyPresenter presenter;
        public VCompany()
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new VCompanyPresenter(this));
            presenter = ServiceLocator.Instance.Resolve<VCompanyPresenter>();

            ServiceLocator.Instance.Resolve<DbCreate>().DbCreateDone += RefreshView;
        }

        private void InitListBox()
        {
            CompanyBox.Sorted = true;
            CompanyBox.DataSource = presenter.GetDbCompanies();
            CompanyBox.DisplayMember = CsvEnums.company.Name.ToString();
        }

        private void InitGridOptions()
        {
            FinDataGrid.BackgroundColor = Color.White;
            FinDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DataGridViewRow row = this.FinDataGrid.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.White;
            row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            row.Height = 18;
            row.MinimumHeight = 18;
            //FinDataGrid.Height = 15 * 15; // 4*3 Quaters.
            HideFinDataColumns();
            SetFinDataDisplayStyle();
        }

        private void SetFinDataDisplayStyle()
        {
            DataGridViewCellStyle bigNumberCellStyle = new DataGridViewCellStyle();
            bigNumberCellStyle.Format = "#,##0, k";
            bigNumberCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //long numbers into thousands.
            if (this.FinDataGrid.RowCount != 0)
            {
                var propList = typeof(Report).GetProperties();
                int i = 0;
                //foreach (var ePro in propList)
                    //if (ePro.PropertyType == typeof(Int64))
                        //FinDataGrid.Rows[i++].DefaultCellStyle = bigNumberCellStyle;
                        //FinDataGrid.Rows[ePro.Name].DefaultCellStyle = bigNumberCellStyle;

                foreach (DataGridViewColumn cols in FinDataGrid.Columns)
                {
                    if (cols.ValueType == typeof(long))
                    cols.DefaultCellStyle = bigNumberCellStyle;
                }
            }
        }

        private void HideFinDataColumns()
        {
            // TO-OPT - i dont like this solution, pure data on view side.
            var hideList = new List<string>
            {
                "Id",
                "CompanyId",
                "Company"
            };
            foreach (DataGridViewColumn finColum in FinDataGrid.Columns)
            {
                if (hideList.Contains(finColum.Name))
                {
                    finColum.Visible = false;
                }
            }
        }

        private void InitDropBoxs()
        {
            CompanyTypes.DataSource = presenter.GetTestBindList();
            CompanyTypes.DisplayMember = CsvEnums.company.Name.ToString();

            MarketType.DataSource = presenter.GetTestBindList();
            MarketType.DisplayMember = CsvEnums.company.Name.ToString();
        }

        private void CompanyFilter_TextChanged(object sender, System.EventArgs e)
        {
            CompanyBox.BeginUpdate();
            CompanyBox.DataSource = presenter.GetFilterBox(CompanyFilter.Text);
            CompanyBox.EndUpdate();
        }

        public System.Windows.Forms.ListBox.ObjectCollection GetCmpBoxItems()
        {
            return CompanyBox.Items;
        }

        #region Delegates Implementation
        private void RefreshView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => RefreshView()));
            }
            else
            {
                this.InitListBox();
                this.InitDropBoxs();
                this.InitGridOptions();
                this.ChartPopulatingData();
            }
        }
        #endregion

        public void RefreshView_Panel2(ICompany cmp)
        {
            FinDataGrid.DataSource = presenter._cmpSelectedReportsObsList;
            //to avoid ArgumentOutOfRangeException, when company does not have reports
            if (FinDataGrid.RowCount > 0)
            {
                //this.TransposeFinDataGrid();
            }
            SharePriceLabel.Text = cmp.SharePrice.ToString();
            DateCmpLabel.Text = String.Format("{0}", ((System.DateTime)cmp.Date).ToShortDateString());
            CompanyTitle.Text = cmp.FullName.ToString();
        }

        public void TransposeFinDataGrid()
        {
            DataTable oldTable = VCompanyPresenter.DataGridView2DataTable(FinDataGrid, "oldTable");
            DataTable newTable = new DataTable();

            newTable.Columns.Add("Header");
            for (int i = 0; i < oldTable.Rows.Count; i++)
            { 
                newTable.Columns.Add();
                //here get year quater [i] from old table. and put into caption columns.
                //newTable.Columns[i].Caption = 
            }
              

            for (int i = 0; i < oldTable.Columns.Count; i++)
            {
                DataRow newRow = newTable.NewRow();

                newRow[0] = oldTable.Columns[i].Caption;

                for (int j = 0; j < FinDataGrid.Rows.Count; j++)
                    newRow[j + 1] = oldTable.Rows[j][i];
                newTable.Rows.Add(newRow);
            }

            // this should be seperate code... function... extension ?
            var lst = new List<string>(); //getHeaders from column 0
            for (int i = 0; i < newTable.Rows.Count; i++)
            {
                lst.Add(newTable.Rows[i][0].ToString());
            }

            newTable.Columns.Remove(newTable.Columns[0]); //removeTrashHeaderColumn
            
            FinDataGrid.DataSource = newTable;
            // row header by lst.
            foreach (var header in lst)
            {
                 FinDataGrid.Rows[lst.IndexOf(header)].HeaderCell.Value = header;
            }
            //FinDataGrid.Columns[0].Visible = false; // ?
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CompanyBox.SelectedItem != null)
            {
                presenter.SetCmpSelected((Company)CompanyBox.SelectedItem);
            }
        }

        public void BoxMsg(string s)
        {
            MessageBox.Show(s);
        }

        #region Chart usage methods

        private void ChartPopulatingData()
        {
            // TODO: 2 ways of drawing charts -> populate data from DB(slower in execution)
            //-> populate data from dataGridView(harder to done, I think)
            // WHICH TO MAKE?
            
            // I think more important is coneception about how to do it flexible, for all possible views,
            // that we will get into the futer. For now, is easy to get dataTable from data grid, presenter of view can provide this action, although
            // we must be flexible and be able to visualise the data that user want to see.
            // -> user choose the data on the view (Ebit, sales) -> advanced(multiselection EBIT,SALES at once).
            // -> user confirms he want the chart by (submenu (rightmouseclick)
            // -> presenter get the event action (eventagregator from prism ?)
            // -> presenter nows that the user select on view this data by the event,
            // -> presenter lunch the ChartServiceProvider (DataInput.)
            // -> chart service provider do all the data stuff
            // -> presenter informs view that chart is ready to display
            // -> view (shows) the chart.
            
            // -> evry database action make sense if we lunch thread on it and we do not slow down our app.
            // -> i have this problem during filterBox :) , although this is optimalization topic for me now.
            

            double[] yval = { 5, 6, 4, 3, 7 };
            string[] xval = { "A", "B", "C", "D", "E" };


            //TODO: return Year and quarter from DB to X axies
            var reports = presenter.GetSelectedCmpReports1();
            //chart1.Series["Sales"].Points.DataBindXY(xval, reports);

            for (int i = 0; i < reports.Count; i++)
            {
                // out of range expection on reports[i] // remember i transpose the tabless etc. i do comment it...
                // chart1.Series["Series1"].Points.AddXY(xval[i], reports[i]);
            }
            chart1.Series["Series1"].Name = "Sales";

            //var xxx = FinDataGrid.Rows[3].Cells[1].FormattedValue;
            ////chart1.Series["Series1"].Points.DataBindXY(xval, FinDataGrid.Rows[4].Cells.GetEnumerator());

            //for (int i = 1; i < FinDataGrid.ColumnCount; i++)
            //{
            //    chart1.Series["Series2"].Points.AddXY(xval[i], FinDataGrid.Rows[4].Cells[i].FormattedValue);
            //}
            //chart1.Series["Series2"].Name = FinDataGrid.Rows[3].Cells[0].FormattedValue.ToString();
        }

        #endregion

        #region FinDataGrid Menu Btns
        #endregion
        private void filterFinDataBtn_Click(object sender, EventArgs e)
        {
            presenter.SetLast4QReports(); ;
        }

        private void fullFinDataBtn_Click(object sender, EventArgs e)
        {
            presenter.SetFullReports();
        }
    }
}
