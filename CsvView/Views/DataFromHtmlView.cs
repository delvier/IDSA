﻿using System;
using System.Windows.Forms;
using IDSA.Presenters;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;

namespace IDSA.Views
{
    public partial class DataFromHtmlView : UserControl
    {
        DataFromHtmlPresenter presenter;

        public DataFromHtmlView()
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new DataFromHtmlPresenter(this));
            presenter = ServiceLocator.Instance.Resolve<DataFromHtmlPresenter>();
        }

        private void searchExchangeBtn_Click(object sender, EventArgs e)
        {
            string exchange = GetExchangeFromHtmlAddress(compIDTextBox.Text);
            exchangeLabel.Text = exchange;
        }

        private string GetExchangeFromHtmlAddress(string companyId)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument page = hw.Load(@"http://stooq.pl/q/?s=" + companyId.ToLower());
            string exchange;
            try
            {
                exchange = page.DocumentNode.SelectSingleNode("//span[@id='aq_" + companyId.ToLower() + "_c2|3']").InnerText;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("ID not found");
                return "";
            }
            return exchange;
        }
    }
}