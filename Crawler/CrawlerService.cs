using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive.Linq;
using IDSA.Modules.PapParser;

namespace Crawler
{
    public class DataStruct
    {
        public string CmpName { get; set; }
        public string CmpLink { get; set; }
        public List<MsgStruct> Message { get; set; }
        public List<Subscriber> Subscribers { get; set; }
    }

    public class MsgStruct
    {
        public string Title { get; set; }
        public DateTime Time { get; set; }
    }

    public class Subscriber
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Time { get; set; }
    }

    public interface ICrawlerService
    {
        void startCrawler(TimeSpan refreshTime);
        void endCrawler(bool forceExit = false);

    }

    public class Client : IObserver<string>, IDisposable
    {
        public Client()
        {

        }

        public void OnCompleted() {}
        //
        // Summary:
        //     Notifies the observer that the provider has experienced an error condition.
        //
        // Parameters:
        //   error:
        //     An object that provides additional information about the error.
        public void OnError(Exception error) {}
        //
        // Summary:
        //     Provides the observer with new data.
        //
        // Parameters:
        //   value:
        //     The current notification information.
        public void OnNext(string value) {}

        public void Dispose()
        {
            //
        }
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
    public class CrawlerService : ICrawlerService, IObservable<string>
    {
        #region Fields
        private readonly IPapParser _papParser;
        private TimeSpan lastTime;
        private List<DataStruct> _data;
        #endregion

        #region Ctors
        public CrawlerService()
        {
            _data = new List<DataStruct>();
            _papParser = new PapParser();

            if (_data.Count == 0)
            {
                foreach (var item in _papParser.GetCompanyNames())
                {
                    _data.Add(new DataStruct { CmpName = item });
                }
            }

            lastTime = new TimeSpan(0, 1, 0);
            startCrawler(lastTime);
        }
        #endregion

        #region Public Methods
        public IDisposable Subscribe(IObserver<string> observer)
        {
            IDisposable obj = new Client();
            return obj;
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
