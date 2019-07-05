using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfTime.MVVM; // for ObservableObject
using System.Windows.Input; //for ICommand
using System.Collections.ObjectModel; //for ObservableCollection
using System.Windows;
using System.Diagnostics;
using System.Threading;

namespace WpfTime.ViewModel
{
    class ViewModelElapsed : ObservableObject
    {
        #region member
        Thread thClock;
        string time;
        TimeSpan currentTime;
        TimeSpan startTime;
        #endregion

        #region properties
        public string Time
        {
            get { return time; }
            set { time = value; RaisePropertyChanged("Time"); }
        }
        #endregion
        #region constructor
        public ViewModelElapsed()
        {
            Time = "00:00:00";
            startTime = DateTime.Now.TimeOfDay;
            thClock = new Thread(new ThreadStart(ThreadClock));
            thClock.IsBackground = true;
            thClock.Start();
        }
        #endregion

        #region command

        #endregion

        #region method
        private void ThreadClock()
        {
            while(true)
            {
                currentTime = DateTime.Now.TimeOfDay;
                TimeSpan elapsedTime = currentTime - startTime;
                Time = elapsedTime.ToString(@"mm\:ss\:ff");
                Thread.Sleep(20);
            }
        }
        #endregion

    }
}
