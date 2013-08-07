using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Presenters.PropertyPresenters;
using IDSA.Models.DataStruct;
using System.ComponentModel; 

namespace IDSA.Presenters.Financial_InternalTabs
{
    public class BalancePresenter : BasicGridPresenter
    {

        public BalancePresenter() : base()
        {

        }
        public override void DataUpdate(Models.Company company)
        {
            Data = new BindingList<PresenterBalance>(company.Reports
                            .Select(r => new PresenterBalance
                            {
                                Year_Quarter = String.Format("{0} : [{1}]", r.Year, r.Quarter),
                                ReportDate = r.FinancialReportReleaseDate,
                                AssetsForSale = r.Balance.AssetsForSale,
                                AssetsPrimary = r.Balance.AssetsPrimary,
                                CapitalMasterFund = r.Balance.CapitalMasterFund,
                                CapitalreserveFund = r.Balance.CapitalreserveFund,
                                Cash = r.Balance.Cash,
                                CurrentAssets = r.Balance.OtherCurentAssets,
                                Equity = r.Balance.Equity,
                                FixedAssets = r.Balance.FixedAssets,
                                IntangibleAssets = r.Balance.IntangibleAssets,
                                Inventory = r.Balance.Inventory,
                                LiabilitiesPrimary = r.Balance.LiabilitiesPrimary,
                                LoansAndAdvancesLT = r.Balance.LoansAndAdvancesLT,
                                LoansAndAdvancesST = r.Balance.LoansAndAdvancesST,
                                LongTermInvestmentCurA = r.Balance.LongTermInvestmentCurA,
                                LongTermInvestmentFixA = r.Balance.LongTermInvestmentFixA,
                                LongTermLiabilities = r.Balance.LongTermLiabilities,
                                LongTermReceivablesCurA = r.Balance.LongTermReceivablesCurA,
                                LongTermReceivablesFixA = r.Balance.LongTermReceivablesFixA,
                                NonControllingInterests = r.Balance.NonControllingInterests,
                                OtherCurentAssets = r.Balance.OtherCurentAssets,
                                OtherFinancialLT = r.Balance.OtherFinancialLT,
                                OtherFinancialST = r.Balance.OtherFinancialST,
                                OtherFixedAssets = r.Balance.OtherFixedAssets,
                                OtherLT = r.Balance.OtherLT,
                                OtherST = r.Balance.OtherST,
                                ShareOfTreasuryStock = r.Balance.ShareOfTreasuryStock,
                                ShortTermLiabilities = r.Balance.ShortTermLiabilities,
                                SuppliesAndServicesLT = r.Balance.SuppliesAndServicesLT,
                                SuppliesAndServicesST = r.Balance.SuppliesAndServicesST,
                                TangibleFixedAssets = r.Balance.TangibleFixedAssets
                            })
                            .ToList<PresenterBalance>()
                     );
            this.Header = company.FullName;
        }
        private class PresenterBalance : BalanceData
        {
            public string Year_Quarter { get; set; }
            public DateTime ReportDate { get; set; }
        }
    }
}
