using System;
using System.Collections.Generic;
using System.Text;

namespace Celarix.Nodes
{
    public abstract class Node
    {
        protected internal string? _nodeId;
        public abstract string Name { get; }

        public abstract ValueTask Evaluate();
    }
}
