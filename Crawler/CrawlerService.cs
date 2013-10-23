using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive.Linq;
using IDSA.Modules.PapParser;

namespace Crawler
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
    /// Use the Reactive Extensions (Rx) = Observables + LINQ + Schedulers.
    /// http://msdn.microsoft.com/en-us/data/gg577609.aspx
    /// 
    /// TODO:
    /// * implement Observer pattern
    /// * crawling methods MUST use other TASK/THRED
    /// * use as more as possible from PAP Parser functionality
    /// * ...
    /// </summary>
    public class CrawlerService : ICrawlerService//, IObservable<T>
    {
        #region Fields
        private readonly IPapParser _papParser;
        private TimeSpan lastTime;
        #endregion

        #region Ctors
        public CrawlerService()
        {
            _papParser = new PapParser();
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
            TimeSpan lastReportTime = _papParser.getTimeOfLatestReport();
            //TODO: Triggerowac godzine i minute pojawienia sie ostatniego raportu. 
            //Jezeli sie nie zgadza, to parsowac dopoty, dopoki nie spotkamy 
            //poprzednio zapisanej ostatniej daty.   Po skonczonej robocie

        }

        public void endCrawler(bool forceExit = false)
        {
        }
        #endregion

        #region Private Methods
        
        #endregion
    }
}
