using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDSA.Services
{
    interface IMessageBoxService
	{
		void ErrorNotify (String error);
        void Message(String msg);
	} 
    class MessageBoxService : IMessageBoxService
    {
        public void ErrorNotify(string error)
        {
            MessageBox.Show(error, "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Message(string msg)
        {
            MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
