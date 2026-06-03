using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Celarix.Nodes.Testing
{
    public class EditorViewModel
    {
        public ObservableCollection<NodeViewModel> Nodes { get; } = new ObservableCollection<NodeViewModel>();
        public ObservableCollection<ConnectionViewModel> Connections { get; } = new ObservableCollection<ConnectionViewModel>();
        public PendingConnectionViewModel PendingConnection { get; }
        public ICommand DisconnectConnectorCommand { get; }

        public EditorViewModel()
        {
            PendingConnection = new PendingConnectionViewModel(this);

            NodeViewModel welcome = new()
            {
                Title = "Welcome",
                Location = new System.Windows.Point(100, 100),
                Input =
                [
                    new ConnectorViewModel
                    {
                        Title = "In"
                    },
                ],
                Output =
                [
                    new ConnectorViewModel
                    {
                        Title = "Out"
                    },
                ]
            };

            var nodify = new NodeViewModel
            {
                Title = "To Nodify",
                Location = new System.Windows.Point(300, 100),
                Input =
                [
                    new ConnectorViewModel
                    {
                        Title = "In"
                    }
                ]
            };

            Nodes.Add(welcome);
            Nodes.Add(nodify);

            Connections.Add(new ConnectionViewModel(welcome.Output[0], nodify.Input[0]));

            DisconnectConnectorCommand = new DelegateCommand<ConnectorViewModel>(connector =>
            {
                var connection = Connections.First(x => x.Source == connector || x.Target == connector);
                connection.Source.IsConnected = false; // warning: in the future we will need to check for multiple inbound connections
                connection.Target.IsConnected = false;
                Connections.Remove(connection);
            });
        }

        public void Connect(ConnectorViewModel source, ConnectorViewModel target)
        {
            Connections.Add(new ConnectionViewModel(source, target));
        }
    }
}
