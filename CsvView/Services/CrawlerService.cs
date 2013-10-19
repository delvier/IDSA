using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Services
{
    public interface ICrawlerService
    {
        void startCrawler(TimeSpan refreshTime);
        void endCrawler(bool forceExit = false);

        bool Subscribe();
        bool Unsubscribe();

    }

    /// <summary>
    /// Crawler Service used for monitoring PAP site and acting, when new info appers.
    /// Based on Observer Design Pattern.
    /// 
    /// TODO:
    /// * implement Observer pattern
    /// * crawling methods MUST use other TASK/THRED
    /// * use as more as possible from PAP Parser functionality
    /// * ...
    /// </summary>
    public class CrawlerService : ICrawlerService
    {
        #region Fields
        private HtmlWeb hw;
        private HtmlDocument page;
        private TimeSpan lastTime;
        #endregion

        #region Ctors
        public CrawlerService()
        {
            hw = new HtmlWeb();
            lastTime = new TimeSpan(0, 1, 0);
            startCrawler(lastTime);
        }
        #endregion

        #region Public Methods
        public bool Subscribe()
        {
            return false;
        }

        public bool Unsubscribe()
        {
            return false;
        }

        public void startCrawler(TimeSpan refreshTime)
        {
            TimeSpan lastReportTime = getLatestReportDate();
            //TODO: Triggerowac godzine i minute pojawienia sie ostatniego raportu. 
            //Jezeli sie nie zgadza, to parsowac dopoty, dopoki nie spotkamy 
            //poprzednio zapisanej ostatniej daty.   Po skonczonej robocie

        }

        public void endCrawler(bool forceExit = false)
        {
        }
        #endregion

        #region Private Methods
        private TimeSpan getLatestReportDate()
        {
            page = hw.Load(@"http://biznes.pap.pl/pl/reports/espi/term,0,0,0,1");

            //godzina z tabeli raportow	
            var hour = page.DocumentNode.SelectSingleNode("//table [@class=\"espi\"]/tr[3]/td[1]").InnerText.Split(':');
            return new TimeSpan(Convert.ToInt32(hour[0]), Convert.ToInt32(hour[1]), 0);
        }
        #endregion
    }
}
