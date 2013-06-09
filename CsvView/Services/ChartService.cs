﻿using IDSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace IDSA.Services
{
    public interface IChartService
    {
        void RecalcXValues(IList<Report> rep);
        void RecalcYValues(String headerName);
        IList<String> GetxValues();
        IList<Int64> GetyValues();
        //void Refresh();
        //void Clear(Chart chart);
    }

    public class ChartService : IChartService
    {
        private IList<String> xVals;
        private IList<Int64> yVals;
        private String headerName;
        private IList<Report> rep;
        //private System.Windows.Forms.DataVisualization.Charting.Chart chart;

        public ChartService()
        {
            xVals = new List<String>();
            yVals = new List<Int64>();
            //this.chart = chart;
        }

        public IList<String> GetxValues()
        {
            return xVals;
        }

        public IList<Int64> GetyValues()
        {
            return yVals;
        }

        public void RecalcXValues(IList<Report> rep)
        {
            xVals.Clear();
            for (int i = 0; i < rep.Count; i++)
            {
                xVals.Add(rep.ElementAt(i).Quarter.ToString() + " " + rep.ElementAt(i).Year.ToString().Remove(0, 2));
            }
            this.rep = rep;
        }

        public void RecalcYValues(String headerName = "")
        {
            yVals.Clear();
            
            switch (headerName)
            {
                case "Sales": yVals = rep.Select(r => r.Sales).ToList();
                    break;
                case "OwnSaleCosts": yVals = rep.Select(r => r.OwnSaleCosts).ToList();
                    break;
                case "EarningOnSales": yVals = rep.Select(r => r.EarningOnSales).ToList();
                    break;
                case "EarningBeforeTaxes": yVals = rep.Select(r => r.EarningBeforeTaxes).ToList();
                    break;
                case "EBIT": yVals = rep.Select(r => r.EBIT).ToList();
                    break;
                case "NetProfit": yVals = rep.Select(r => r.NetProfit).ToList();
                    break;
                default: yVals = rep.Select(r => r.Sales).ToList();
                    break;
            }
        }
    }

}
