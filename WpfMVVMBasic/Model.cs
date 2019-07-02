using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WpfMVVMBasic.MVVM;

namespace WpfMVVMBasic
{
    class Model : ObservableObject
    {
        private string bindingMessage;

        public string BindingMessage { get { return bindingMessage; } set { bindingMessage = value; RaisePropertyChanged("BindingMessage"); } }
        public string CommandBindingMessage { get; set; }
        public List<string> ListMessage { get; set; } = new List<string>();

        public Model()
        {
            BindingMessage = "Binding is done";
            CommandBindingMessage = "Command binding is done";
            for(int i = 0; i < 10; i++)
            {
                ListMessage.Add(string.Format("[{0}] List binding is done", i));
            }
        }
    }
}
