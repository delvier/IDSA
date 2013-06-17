using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views;
using IDSA.Models.Repository;

namespace IDSA.Presenters
{
    public interface IDataScannerPresenter
    {
        
    }
    public class DataScannerPresenter : IDataScannerPresenter
    {
        DataScanner view;
        private readonly IUnitOfWork uow;
        //cached data , easy to handle created once treat as db
        public DataScannerPresenter(DataScanner view, IUnitOfWork  uow)
        {
            this.view = view;
            this.uow = uow;
        }
    }
}
