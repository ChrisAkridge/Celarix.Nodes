using System;
using System.Collections.Generic;
using System.Text;

namespace Celarix.Nodes.Testing
{
    public class ConnectionViewModel
    {
        public ConnectorViewModel Source { get; set; }
        public ConnectorViewModel Target { get; set; }

        public ConnectionViewModel(ConnectorViewModel source, ConnectorViewModel target)
        {
            Source = source;
            Target = target;

            Source.IsConnected = true;
            Target.IsConnected = true;
        }
    }
}
