﻿using System;
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

            Task.Delay(new TimeSpan(0, 0, 0, 2, 0)).ContinueWith(o => { ClearCurrentMessage(); });
        }

        public void ClearCurrentMessage()
        {
            CurrentMessage = string.Empty;
        }
    }
}
