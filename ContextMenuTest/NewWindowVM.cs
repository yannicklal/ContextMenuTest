using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContextMenuTest
{
    public class NewWindowVM : ObservableObject
    {
        public event EventHandler OnRequestClose;
        private string myText;

        public NewWindowVM()
        {
            myText = "The ContextMenu should be closed before I start my instanciation";
            DialogResult = false;
        }

        public string Text
        {
            get { return myText; }
            set
            {
                if (myText == value) return;
                myText = value;
                OnPropertyChanged(nameof(myText));
            }
        }

        public bool DialogResult { get; set; }

        RelayCommand myOkCommand;
        public RelayCommand OkCommand
        {
            get
            {
                if (myOkCommand == null)
                    myOkCommand = new RelayCommand(OkCommandAction);

                return myOkCommand;
            }
        }

        private void OkCommandAction()
        {
            DialogResult = true;
            OnRequestClose(this, new EventArgs());
        }
    }
}
