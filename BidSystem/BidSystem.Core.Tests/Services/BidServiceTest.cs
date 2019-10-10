using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BidSystem.Core.Models;
using BidSystem.Core.Services;

namespace BidSystem.Core.Tests.Services
{
    [TestClass]
    public class BidServiceTest
    {
        Item item;
        int testValue = 2;

        [TestCleanup]
        public void testClean()
        {
            testValue = 0;
        }

        [TestInitialize]
        public void Initialize()
        {
            testValue = 5;
            item = new Item();
            item.ItemId = new Guid();
            item.Name = "Item_1";
        }

        [TestMethod]
        [Timeout(50)]  // Milliseconds
        public void TestGetActualOwner_GeneralLogicContender()
        {
            // Arrange
            const float rule = 1.0F;

            Bid owner = new Bid(CurrentBid: 10, MaxOffer: 13, item: item);
            Bid contender1 = new Bid(CurrentBid: 11, MaxOffer: 15, item: item);
            Bid contender2 = new Bid(CurrentBid: 17, MaxOffer: 20, item: item);

            BidService ser = new BidService(rule);

            // Act
            ser.GetActualOwner(ref owner, ref contender1);

            // Assert
            Assert.AreEqual(owner.CurrentBid, 13);
            Assert.AreEqual(owner.CurrentBid, owner.MaxOffer);
            Assert.AreEqual(contender1.CurrentBid, 14);
            Assert.AreEqual(15, contender1.MaxOffer);

            ser.GetActualOwner(ref contender1, ref contender2);

            Assert.AreEqual(contender1.CurrentBid, 15);
            Assert.AreEqual(15, contender1.MaxOffer);
            Assert.AreEqual(contender2.CurrentBid, 16);
            Assert.AreEqual(20, contender2.MaxOffer);

            contender1.CurrentBid = 17;
            contender1.MaxOffer = 25;

            ser.GetActualOwner(ref contender2, ref contender1);
            Assert.AreEqual(contender1.CurrentBid, 21);
            Assert.AreEqual(25, contender1.MaxOffer);
            Assert.AreEqual(20, contender2.MaxOffer);
            Assert.AreEqual(contender2.CurrentBid, contender2.MaxOffer);
        }

        [TestMethod]
        [Timeout(50)]  // Milliseconds
        public void TestGetActualOwner_ErrorContenderMaxOfferExceded()
        {
            // Arrange
            const float rule = 2.0F;

            Bid owner = new Bid(CurrentBid: 10, MaxOffer: 11, item: item);
            Bid contender1 = new Bid(CurrentBid: 11, MaxOffer: 11, item: item);

            BidService ser = new BidService(rule);

            // Act
            try
            {
                ser.GetActualOwner(ref owner, ref contender1);
            }
            catch (Exception e)
            {
                Assert.IsNotNull(e);
            }

            // Assert
            Assert.AreEqual(owner.CurrentBid, 10);
            Assert.AreEqual(11, owner.MaxOffer);
            Assert.AreEqual(contender1.CurrentBid, 11);
            Assert.AreEqual(contender1.CurrentBid, contender1.MaxOffer);
        }

        [TestMethod]
        [Timeout(50)]  // Milliseconds
        public void TestGetActualOwner_OwnerAboveContender()
        {
            // Arrange
            const float rule = 1.0F;

            Bid owner = new Bid(CurrentBid: 10, MaxOffer: 17, item: item);
            Bid contender1 = new Bid(CurrentBid: 11, MaxOffer: 14, item: item);

            BidService ser = new BidService(rule);

            // Act
            ser.GetActualOwner(ref owner, ref contender1);

            // Assert
            Assert.AreEqual(owner.CurrentBid, 15);
            Assert.AreEqual(17, owner.MaxOffer);
            Assert.AreEqual(contender1.CurrentBid, 14);
            Assert.AreEqual(contender1.CurrentBid, contender1.MaxOffer);
        }

        [TestMethod]
        [Timeout(50)]  // Milliseconds
        public void TestGetActualOwner_ErrorOwnerMaxOfferExceded()
        {
            // Arrange
            const float rule = 3.0F;

            Bid owner = new Bid(CurrentBid: 10, MaxOffer: 12, item: item);
            Bid contender1 = new Bid(CurrentBid: 11, MaxOffer: 11, item: item);

            BidService ser = new BidService(rule);

            // Act
            try
            {
                ser.GetActualOwner(ref owner, ref contender1);
            }
            catch (Exception e)
            {
                Assert.IsNotNull(e);
            }

            // Assert
            Assert.AreEqual(owner.CurrentBid, 10);
            Assert.AreEqual(12, owner.MaxOffer);
            Assert.AreEqual(contender1.CurrentBid, 11);
            Assert.AreEqual(contender1.CurrentBid, contender1.MaxOffer);
        }
    }
}


//[TestMethod]
//public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
//{
//    // Arrange
//    double beginningBalance = 11.99;
//    double debitAmount = -100.00;
//    BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

//    // Act and assert
//    Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
//}


//[TestMethod]
//public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
//{
//    // Arrange
//    double beginningBalance = 11.99;
//    double debitAmount = 20.0;
//    BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

//    // Act
//    try
//    {
//        account.Debit(debitAmount);
//    }
//    catch (System.ArgumentOutOfRangeException e)
//    {
//        // Assert
//        StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
//    }
//}



//[TestMethod]
//public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
//{
//    // Arrange
//    double beginningBalance = 11.99;
//    double debitAmount = 20.0;
//    BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
//
//    // Act
//    try
//    {
//        account.Debit(debitAmount);
//    }
//    catch (System.ArgumentOutOfRangeException e)
//    {
//        // Assert
//        StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
//        return;
//    }
//
//    Assert.Fail("The expected exception was not thrown.");
//}