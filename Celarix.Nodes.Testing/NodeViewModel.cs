using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Text;

namespace Celarix.Nodes.Testing
{
    public class NodeViewModel : INotifyPropertyChanged
    {
        private Point _location;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Title { get; set; }

        public ObservableCollection<ConnectorViewModel> Input { get; set; } = new();
        public ObservableCollection<ConnectorViewModel> Output { get; set; } = new();
        public Point Location
        {
            get => _location;
            set
            {
                _location = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Location)));
            }
        }

    }
}
