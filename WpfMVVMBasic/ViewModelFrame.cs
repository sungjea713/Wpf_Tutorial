using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfMVVMBasic.MVVM;
using System.Windows.Input; //for ICommand
using System.Collections.ObjectModel; //for ObservableCollection
using System.Windows;
using System.Diagnostics;
using System.Threading;

namespace WpfMVVMBasic
{
    class ViewModelFrame : ObservableObject
    {
        #region member

        #endregion

        #region constructor
        public ViewModelFrame()
        {

        }
        #endregion

        #region command
        public ICommand Operation { get { return new RelayCommand(OperationExcute); } }
        void OperationExcute()
        {
            
        }
        #endregion

        #region method
        #endregion
    }
}
