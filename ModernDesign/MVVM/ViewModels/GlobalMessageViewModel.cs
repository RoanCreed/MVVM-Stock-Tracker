using ModernDesign.Stores;
using MVVMSettings.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.MVVM.ViewModels
{
    public class GlobalMessageViewModel : ViewModelBase
    {
        private readonly MessageStore _messageStore;
        public string Message => _messageStore.CurrentMessage;
        public MessageType MessageType => _messageStore.CurrentMessageType;

        public bool HasMessage => _messageStore.HasCurrentMessage;

        public GlobalMessageViewModel(MessageStore messageStore)
        {
            _messageStore = messageStore;
            _messageStore.CurrentMessageChanged += MessageStore_CurrentMessageChanged;
            _messageStore.CurrentMessageTypeChanged += MessageStore_CurrentMessageTypeChanged;
        }

        private void MessageStore_CurrentMessageTypeChanged()
        {
            OnPropertyChanged(nameof(MessageType));

        }

        private void MessageStore_CurrentMessageChanged()
        {
            OnPropertyChanged(nameof(Message));
            OnPropertyChanged(nameof(HasMessage));
        }
    }
}
