using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Celarix.Nodes.Testing
{
    public class ConnectorViewModel : INotifyPropertyChanged
    {
        private Point _anchor;
        private bool _isConnected;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Title { get; set; }
        public Point Anchor
        {
            get => _anchor;
            set
            {
                _anchor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Anchor)));
            }
        }

        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsConnected)));
            }
        }
    }
}
