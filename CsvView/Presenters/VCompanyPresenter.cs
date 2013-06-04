using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using IDSA.Models;
using IDSA.Models.Repository;
using IDSA.Services;
using IDSA.Views;
using System.Data;
using System.Windows.Forms;

namespace IDSA.Presenters
{
    class VCompanyPresenter
    {
        VCompany view;
        private IUnitOfWork dbModel;

        private readonly IDataService<Company> _companyDataService;
        private IEnumerable<Company> _cmpData;
        private Company _cmpSelected { get; set; }

        public VCompanyPresenter(VCompany view)
        {
            this._companyDataService = (IDataService<Company>)(new CompanyDataService());
            this.view = view;
        }

        public IBindingList GetDbCompanies()
        {
            var cmpBindList = new BindingList<Company>();
            if (dbModel == null)
                dbModel = ServiceLocator.Instance.Resolve<IUnitOfWork>();
            cmpBindList = dbModel.Companies.GetAll();
            return cmpBindList;
        }

        public IBindingList GetFilterBox(string lookForCompany)
        {
            var cmpBoxElements = view.GetCmpBoxItems();
            var showList = new BindingList<Company>();

            if (!string.IsNullOrEmpty(lookForCompany))
            {
                foreach (Company ele in cmpBoxElements)
                {
                    if (ele.Name.Contains(lookForCompany) || ele.Shortcut.Contains(lookForCompany))
                    {
                        showList.Add(ele);
                    }
                }
                return showList;
            }
            else
                return dbModel.Companies.GetAll(); ;
        }

        //Unused method - wrong conception, view should change the display number type
        //                no calculation on data need to be done.
        //                if need should be somehow defend from unwanted over-writen.
        public void FinDataDivide()
        {
            try
            {
                var propList = typeof(Report).GetProperties();
                foreach (Report rep in _cmpSelected.Reports)
                {
                    foreach (var propElement in propList)
                    {
                        if (propElement.PropertyType == typeof(Int64))
                        {
                            var val = rep.GetType().GetProperty(propElement.Name).GetValue(rep, null);
                            rep.GetType().GetProperty(propElement.Name).SetValue(rep, (Int64)val / 1000000, null);
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                view.BoxMsg(e.Message);
            }
        }

        public void SetCmpSelected(Company company)
        {
            _cmpSelected = company;
            //FinDataDivide(); obj.data should be somehow protected from data manipulation.
            UpdatePanel2();
        }

        private void UpdatePanel2()
        {
            view.RefreshView_Panel2(_cmpSelected);
        }

        #region DataModel Queries
        public IList GetSelectedCmpReports()
        {
            if (dbModel != null)
                return dbModel.Reports.Query()
                     .Where(r => r.CompanyId == _cmpSelected.Id)
                     .OrderByDescending(r => r.Year) // orderBy  Year-Quarter. - best overView.
                     .ThenByDescending(r => r.Quarter)
                     .ToList();
            else
                return (new List<Report>());
        }
        public IList GetSelectedCmpReports1()
        {
            if (dbModel != null)
                return dbModel.Reports.Query()
                     .Where(r => r.CompanyId == _cmpSelected.Id)
                     .OrderByDescending(r => r.Year) // orderBy  Year-Quarter. - best overView.
                     .ThenByDescending(r => r.Quarter).Select(x => x.Sales)
                     .ToList();
            else
                return (new List<Report>());
        }
        #endregion


        #region Reports Other View Required Procedures.
        public IList GetSelectedCmpReports(FinDataRequestViewType viewType)
        {
            if (viewType == FinDataRequestViewType.BASE)
                return GetSelectedCmpReports();
            else
                return null;
        }
        #endregion

        public enum FinDataRequestViewType
        {
            BASE,
            EXTEND,
            NULL

        }

        //Converts the DataGridView to DataTable
        public static DataTable DataGridView2DataTable(DataGridView dgv, String tblName, int minRow = 0)
        {

            DataTable dt = new DataTable(tblName);

            // Header columns
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dc.DataType = column.ValueType;
                dt.Columns.Add(dc);
            }

            // Data cells
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow row = dgv.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    //Type theType = row.Cells[j].Value.GetType();
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value; // this is evil we lost our type ! which we figth for.
                }
                dt.Rows.Add(dr);
            }

            // Related to the bug arround min size when using ExcelLibrary for export
            for (int i = dgv.Rows.Count; i < minRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = "  ";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #region Test Data Generation
        public IEnumerable GetTestCompanies()
        {
            _cmpData = _companyDataService.GetData().Take(100).ToList();
            return _cmpData;
        }

        public IBindingList GetTestBindList()
        {
            var rnd = new Random();
            var testData = new BindingList<Company>();
            for (int i = 0; i < rnd.Next(5, 15); i++)
            {
                testData.Add(
                    new Company
                    {
                        Name = "Types" + i
                    });
            }
            return testData;
        }

        #endregion



    }
}
