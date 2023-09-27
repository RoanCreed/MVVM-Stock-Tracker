using ModernDesign.MVVM.ViewModels;
using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using System;

namespace ModernDesign.Core
{
    public class NavigationCommand : CommandBase
    {

        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;
        private readonly MessageStore _messageStore;

        public NavigationCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel, MessageStore messageStore)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _messageStore = messageStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
            _messageStore.ClearCurrentMessage();
        }
    }
}
