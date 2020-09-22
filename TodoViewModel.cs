using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Todo
{
    class ToDoViewModel
    {
        public ObservableCollection<string> Todoz { get;}
        public string Todo { get; set; }
        public string SelectedTodo { get; set; }

        public ToDoViewModel()
        {
            Todoz = new ObservableCollection<string>();
            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand(Remove);
        }

        private void Remove()
        {
            Todoz.Remove(SelectedTodo);
        }

        private void Add()
        {
            Todoz.Add(Todo);
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
    }
}
