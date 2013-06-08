using System.Windows.Forms;
using IDSA.Presenters;
using System;
using IDSA.Models;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Linq;

namespace IDSA.Views
{
    public interface IVCompany
    {
        void SelectedCmpReportsChanged(object sender, SelectedCmpReportsChangedEventArgs e);
    }

    public partial class VCompany : UserControl, IVCompany
    {
        VCompanyPresenter presenter;
        public VCompany()
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new VCompanyPresenter(this));
            presenter = ServiceLocator.Instance.Resolve<VCompanyPresenter>();

            ServiceLocator.Instance.Resolve<EventDbCreate>().DbCreateDone += RefreshView;
        }

        #region Init & Display Options
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
                foreach (DataGridViewColumn cols in FinDataGrid.Columns)
                {
                    if (cols.ValueType == typeof(long))
                        cols.DefaultCellStyle = bigNumberCellStyle;
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

        public System.Windows.Forms.ListBox.ObjectCollection GetCmpBoxItems()
        {
            return CompanyBox.Items;
        }
        #endregion
        

        #region View Refresh Update / Init
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
                //this.ChartPopulatingData();
            }
        }

        public void RefreshView_Panel2(ICompany cmp)
        {
            FinDataGrid.DataSource = presenter._cmpSelectedReportsList;
            //to avoid ArgumentOutOfRangeException, when company does not have reports
            if (FinDataGrid.RowCount > 0)
            {
                //this.TransposeFinDataGrid();
            }
            SharePriceLabel.Text = cmp.SharePrice.ToString();
            DateCmpLabel.Text = String.Format("{0}", ((System.DateTime)cmp.Date).ToShortDateString());
            CompanyTitle.Text = cmp.FullName.ToString();
        }
        #endregion

      
        #region  Block of Utils

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



        public void BoxMsg(string s)
        {
            MessageBox.Show(s);
        }		 
	#endregion

        #region Chart usage methods

        private void ChartPopulatingData()
        {
            // TODO: populate data from CompanyBox.SelectedItem ;)
            
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
            
            //THANKS, NOW I HAVE VISION(SOLUTION) :) TIME TO IMPLEMENT THIS
            double[] yval = { 5, 6, 4, 3, 7 };
            string[] xval = { "A", "B", "C", "D", "E" };


            //TODO: return Year and quarter from DB to X axies
            IList<Report> reports = presenter.GetSelectedCmpReports1();
            //chart1.Series["Sales"].Points.DataBindXY(xval, reports);

            for (int i = 0; i < reports.Count; i++)
            {
                // out of range expection on reports[i] // remember i transpose the tabless etc. i do comment it...
                //chart1.Series["Series1"].Points.AddXY(xval[i], reports[i]);
            }
            //chart1.Series["Series1"].Name = "Sales";

            //var xxx = FinDataGrid.Rows[3].Cells[1].FormattedValue;
            ////chart1.Series["Series1"].Points.DataBindXY(xval, FinDataGrid.Rows[4].Cells.GetEnumerator());

            //for (int i = 1; i < FinDataGrid.ColumnCount; i++)
            //{
            //    chart1.Series["Series2"].Points.AddXY(xval[i], FinDataGrid.Rows[4].Cells[i].FormattedValue);
            //}
            //chart1.Series["Series2"].Name = FinDataGrid.Rows[3].Cells[0].FormattedValue.ToString();
        }

        private void ChartDataRefresh()
        {
            var rep = ((Company)CompanyBox.SelectedItem).Reports;
            //chart1.Series["Sales"].Points.DataBindXY(rep.)
        }

        internal void ChartDataRefresh(IEnumerable xvalues, string name1, IEnumerable[] yvalues)
        {
            chart1.Series["Series1"].Points.DataBindXY(xvalues, yvalues);
            chart1.Series["Series1"].Name = name1;
        }

        internal void ChartDataRefresh(object[] xvalue, string name1, object[] yvalues)
        {
            for (int i = 0; i < yvalues.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(xvalue[i], yvalues[i]);
            }
            chart1.Series["Series1"].Name = name1;
        }

        #endregion

        #region Events Handlers Block.
        public void SelectedCmpReportsChanged(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            presenter.UpdatePanel2();
        }

        private void filterFinDataBtn_Click(object sender, EventArgs e)
        {
            presenter.RaiseSelectedCmpChange(this, new SelectedCmpReportsChangedEventArgs(4));
            //presenter.SetLast4QReports(); ;
        }

        private void fullFinDataBtn_Click(object sender, EventArgs e)
        {
            presenter.RaiseSelectedCmpChange(this, new SelectedCmpReportsChangedEventArgs());
            //presenter.SetFullReports();
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CompanyBox.SelectedItem != null)
            {
                presenter.SetCmpSelected((Company)CompanyBox.SelectedItem);
                presenter.RaiseSelectedCmpChange(this, new SelectedCmpReportsChangedEventArgs());
            }
        }

        private void CompanyFilter_TextChanged(object sender, System.EventArgs e)
        {
            CompanyBox.BeginUpdate();
            CompanyBox.DataSource = presenter.GetFilterBox(CompanyFilter.Text);
            CompanyBox.EndUpdate();
        }
        #endregion

        private void FinDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //ChartDataRefresh();
            //var selectedReport = this.FinDataGrid.Rows[e.RowIndex].Cells;
            
            ////selectedReport.HeaderCell[]
            ////selectedReport.Cells.Take(3);
            //IEnumerable<DataGridViewRow> selectedRows = 
            //                                    this.FinDataGrid.SelectedCells
            //                                   .Select(cell => cell.OwningRow)
            //                                   .Distinct();
        }

        private int oldColumnIndex = 0;

        private void FinDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var header = this.FinDataGrid.Columns[e.ColumnIndex].HeaderText;
            
            //Column Year or Quarter = no changes on chart
            if (e.ColumnIndex < 2 || e.ColumnIndex == oldColumnIndex)
            {
                //TODO: (empty chart only with xValues)
                chart1.Series.Clear();
                chart1.Series.Add(header);
                chart1.Series[header].Points.DataBindXY(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 });
                return;
            }
            oldColumnIndex = e.ColumnIndex;
            var headerIdx = this.FinDataGrid.CurrentCell.ColumnIndex;

            //TODO: If selected company does not change, not execute below line of code!!!!
            // ALSO: xValues are the same!!!! do not recalculate it again!!!
            //TODO: Do not working with 4Q button yet :(
            IList<Report> rep = presenter.GetSelectedCmpReports1();
            // it is for doing it in view
            //IList<Report> rep = ((Company)CompanyBox.SelectedItem).Reports.ToList();

            var xValues = new List<string>();
            var yValues = new List<Int64>();

            // Get x and y values
            for (int i = 0; i < rep.Count; i++)
            {
                xValues.Add(rep.ElementAt(i).Quarter.ToString() + " " + rep.ElementAt(i).Year.ToString());
                yValues.Add(Int64.Parse(this.FinDataGrid.Rows[i].Cells[headerIdx].Value.ToString()));
                //chart1.Series[header].Points.AddXY(xValues.ElementAt(i), yValues.ElementAt(i));
            }
            chart1.Series.Clear();
            chart1.Series.Add(header);
            chart1.Series[header].Points.DataBindXY(xValues, yValues);
        }
    }
}
