using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Presenters.PropertyPresenters;
using Microsoft.Practices.ServiceLocation;
using IDSA.Services;

namespace IDSA.Views.PropertyView
{
    public interface IBasicGridView
    {
        void Bind();
        IBasicGridPresenter GetPresenterHandler();
    }
    public partial class BasicGridView : UserControl, IBasicGridView
    {
        private IBasicGridPresenter _presenter;
        private IDisplayFormat _formatService;
        public BasicGridView(Type presenterType)
        {
            _presenter = (IBasicGridPresenter)ServiceLocator.Current.GetInstance(presenterType);
            _formatService = ServiceLocator.Current.GetInstance<IDisplayFormat>();

            InitializeComponent();
            /* View data bind */
            this.Bind();

            //bind data update to event
            _presenter.PresenterDataChanged += (o, eventArg) => Bind();
            //in futere this should be an option dynamicly set by a User.
            _presenter.PresenterDataChanged += (o, eventArg) =>
                _formatService.ApplayGridFormatStyle(_formatService.ThousandsFormat, baseViewGrid.Columns);
        }

        public void Bind()
        {
            titleLabel.Text = _presenter.Header;
            baseViewGrid.DataSource = _presenter.Data;
        }

        /* Handler for master presenter */
        public IBasicGridPresenter GetPresenterHandler()
        {
            return _presenter;
        }
    }
}
