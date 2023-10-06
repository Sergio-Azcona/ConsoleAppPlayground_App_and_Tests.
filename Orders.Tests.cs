using ConsoleAppPlayground;
using System;
using System.Collections.Generic;

namespace ConsoleAppPlayground.Tests
{
    public class OrdersTests
    {
        [Fact]
        public void IDs_Uniquness()
        {
            Orders order = new(9, 10);
            Orders order1 = new(11, 12);

            Orders order3 = new(9, 13);
            var exception3 = Assert.Throws<ArgumentException>(() => order3);
            Assert.Equal("9 is not a unique OrderID.", exception3.Message); // Should throw due to non-unique OrderID

        }


        //[Fact]
        //public void AddItemToDictionaries_CanAddItemsToDict()
        //{
        //    Orders order = new(1, 2);
        //    Orders order1 = new(3, 4);

        //    Assert.Empty(order.ItemInfoDict);
        //    Assert.Empty(order1.ItemInfoDict);

        //    Orders.AddItemToDictionaries(order.ItemInfoDict, order.ItemID);

        //    Assert.Contains(order.ItemID, order.ItemInfoDict.Keys);
        //    Assert.DoesNotContain(order1.ItemID, order1.ItemInfoDict.Keys);

        //    Assert.Single(order.ItemInfoDict.Keys);
        //    Assert.Empty(order1.ItemInfoDict);
        //}

        //[Fact]
        //public void AddItemToDictionaries_AddsOnlyValidItems()
        //{
        //    Orders order = new(5, 6);
        //    Orders order1 = new(7, 8);

        //    Assert.Empty(order.ItemInfoDict);
        //    Assert.Empty(order1.ItemInfoDict);

        //    Orders.AddItemToDictionaries(order.ItemInfoDict, order.OrderID);
        //    Orders.AddItemToDictionaries(order1.ItemInfoDict, order1.ItemID);

        //    Assert.Empty(order.ItemInfoDict);
        //    Assert.Single(order1.ItemInfoDict);
        //}
    }

}