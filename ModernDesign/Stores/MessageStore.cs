using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModernDesign.Stores
{
    public enum MessageType
    {
        Status,
        Error
    }

    public class MessageStore
    {
        private string _currentMessage;

        public string CurrentMessage 
        {
            get => _currentMessage;
            private set
            {
                _currentMessage = value;
                CurrentMessageChanged?.Invoke();
            }
        }

        private MessageType _currentMessageType;

        public MessageType CurrentMessageType
        {
            get => _currentMessageType;
            private set
            {
                _currentMessageType = value;
                CurrentMessageTypeChanged?.Invoke();
            }
        }

        public bool HasCurrentMessage => !string.IsNullOrEmpty(_currentMessage);
        
        public event Action CurrentMessageChanged;
        public event Action CurrentMessageTypeChanged;

        public void SetCurrentMessage(string message, MessageType messageType)
        {
            CurrentMessageType = messageType;
            CurrentMessage = message;

            Timer timer = new Timer(ClearCurrentMessage, null, 1300, Timeout.Infinite);
        }

        public void ClearCurrentMessage(object state)
        {
            CurrentMessage = string.Empty;
           
        }
    }
}
