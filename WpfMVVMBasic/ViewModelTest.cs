using System.Collections.Generic;
using WpfMVVMBasic.MVVM;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;
using System.Windows;

namespace WpfMVVMBasic
{
    public class ViewModelTest : ObservableObject
    {
        #region member
        Model model = new Model();
        Thread thread;
        int count = 0;
        #endregion

        #region Properties
        public string LabelString { get { return model.BindingMessage; } set { model.BindingMessage = value; RaisePropertyChanged("LabelString"); } }
        public string ButtonString { get { return model.CommandBindingMessage; } set { model.CommandBindingMessage = value; RaisePropertyChanged("ButtonString"); } }
        public List<string> ListMessageRaiseMethod { get { return model.ListMessage; } set { model.ListMessage = value; RaisePropertyChanged("ListMessageRaiseMethod"); } }
        public ObservableCollection<string> ListMessagNonRaise { get; set; } = new ObservableCollection<string>();
        #endregion

        #region Constructor
        public ViewModelTest()
        {
            foreach(string str in ListMessageRaiseMethod) ListMessagNonRaise.Add(str);
   
            thread = new Thread(new ThreadStart(ThreadMethod));
            thread.Start();
            thread.IsBackground = true;
        }
        #endregion

        #region Command
        void ClickExcute()
        {
            MessageBox.Show("Button is clicked !");   
        }

        bool CanClickExcute()
        {
            return true;
        }

        public ICommand Click { get { return new RelayCommand(ClickExcute, CanClickExcute); } }
        #endregion

        #region Method
        private void ThreadMethod()
        {
            while(true)
            {
                LabelString = string.Format("[{0}] binding", count);
                count++;
                Thread.Sleep(1000);
            }
        }
        #endregion
    }
}
