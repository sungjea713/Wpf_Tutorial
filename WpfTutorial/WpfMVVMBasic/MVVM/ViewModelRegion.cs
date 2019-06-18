using System.Windows.Input; //For ICommand
using System.Collections.ObjectModel; //For ObservableObject
using WpfMVVMBasic.MVVM;

namespace WpfMVVMBasic.MVVM
{
    class ViewModelRegio : ObservableObject
    {
        #region member

        #endregion



        #region constructor

        #endregion



        #region properties

        #endregion



        #region commands
        void TestExcute()
        {

        }
        public ICommand Test { get { return new RelayCommand(TestExcute); } }
        #endregion



        #region methods

        #endregion
    }
}
