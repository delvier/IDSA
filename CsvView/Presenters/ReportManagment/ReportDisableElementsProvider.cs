using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Presenters.ReportManagment
{
    class ReportDisableElementsProvider
    {
        IList<String> elementsToDisableList;
        public ReportDisableElementsProvider()
        {
            elementsToDisableList = new List<String>();
        }

        public IList<String> GetDisableElementsList(ReportActionEnum userAction)
        {
            switch (userAction)
            {
                case ReportActionEnum.ADD:
                    elementsToDisableList = AddControlsToDisableEdit();
                    break;
                case ReportActionEnum.EDIT:
                    elementsToDisableList = EditControlsToDisableEdit();
                    break;
                case ReportActionEnum.DELETE:
                    elementsToDisableList = null;
                    break;
                case ReportActionEnum.UNDEFINED:
                    elementsToDisableList = null;
                    break;
                default:
                    break;
            }
            return elementsToDisableList;
        }

        private IList<string> AddControlsToDisableEdit()
        {
            var addElementsList = new List<String>();
            addElementsList.Add("CompanyId");
            addElementsList.Add("Id");
            return addElementsList;
        }

        private IList<string> EditControlsToDisableEdit()
        {
            var addElementsList = new List<String>();
            addElementsList.Add("Id");
            return addElementsList;
        }
    }
}
