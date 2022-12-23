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
    public class MainVM : ObservableObject
    {
        private string myImagePath;

        public MainVM()
        {
            myImagePath = "flower.jpg";
        }

        public string ImagePath
        {
            get { return myImagePath; }
            set
            {
                if (myImagePath == value) return;
                myImagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        RelayCommand myOpenWindowCommand;
        public RelayCommand OpenWindowCommand
        {
            get
            {
                if (myOpenWindowCommand == null)
                    myOpenWindowCommand = new RelayCommand(OpenWindowCommandAction);

                return myOpenWindowCommand;
            }
        }

        private void OpenWindowCommandAction()
        {
            NewWindowVM vm = new NewWindowVM();
            NewWindow view = new NewWindow(vm);
            vm.OnRequestClose += (s, e) => view.Close();

            view.ShowDialog();

            if(vm.DialogResult)
            {
                //Do stuffs
            }
        }
    }
}
