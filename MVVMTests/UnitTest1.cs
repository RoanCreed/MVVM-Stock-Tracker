using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernDesign.Core;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using ModernDesign.Exceptions;
using System;
using static System.Collections.Specialized.BitVector32;
using ModernDesign.MVVM.ViewModels;
using ModernDesign.Stores;
using Moq;

namespace MVVMTests
{
    [TestClass]
    public class UnitTest1
    {
                
        [TestMethod]
        public void AddStockCommandCheckInput_IfStocksIs0_ReturnInputValidationException()
        {
            //Arrange
            //Creating mocks
            Mock<StocksList> mockStocksList = new Mock<StocksList>();
            Mock<NavigationStore> mockNavigationStore = new Mock<NavigationStore>();
            Mock<MessageStore> mockMessageStore = new Mock<MessageStore>();
            Mock<GlobalMessageViewModel> mockGlobalMessageViewModel = new Mock<GlobalMessageViewModel>(mockMessageStore.Object);

            AddStockViewModel stock = new AddStockViewModel(mockNavigationStore.Object, mockMessageStore.Object , mockGlobalMessageViewModel.Object);

            //Act
            Action action = () => AddStockCommand.CheckInput(stock);
            //Assert
            Assert.ThrowsException<InputValidationException>(action);
        }

        [TestMethod]
        public void AddStockCommandCheckInput_IfAvgPriceIs0_ReturnInputValidationException()
        {
            //Arrange
            AddStockViewModel stock = new AddStockViewModel(new ModernDesign.Stores.NavigationStore(), new MessageStore(), new GlobalMessageViewModel(new MessageStore()));
            //Act
            Action action = () => AddStockCommand.CheckInput(stock);
            //Assert
            Assert.ThrowsException<InputValidationException>(action);
        }

        [TestMethod]
        public void AddStockCommandCheckInput_IfCurrentPriceIs0_ReturnInputValidationException()
        {
            //Arrange
            AddStockViewModel stock = new AddStockViewModel(new ModernDesign.Stores.NavigationStore(), new MessageStore(), new GlobalMessageViewModel(new MessageStore()));
            //Act
            Action action = () => AddStockCommand.CheckInput(stock);
            //Assert
            Assert.ThrowsException<InputValidationException>(action);
        }
        
    }
}

