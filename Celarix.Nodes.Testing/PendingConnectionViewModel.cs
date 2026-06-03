using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Celarix.Nodes.Testing
{
    public class PendingConnectionViewModel
    {
        private readonly EditorViewModel _editor;
        private ConnectorViewModel _source;

        public ICommand StartCommand { get; }
        public ICommand FinishCommand { get; }

        public PendingConnectionViewModel(EditorViewModel editor)
        {
            _editor = editor;
            StartCommand = new DelegateCommand<ConnectorViewModel>(source => _source = source);
            FinishCommand = new DelegateCommand<ConnectorViewModel>(target =>
            {
                if (target != null)
                {
                    _editor.Connect(_source, target);
                }
            });
        }
    }
}
