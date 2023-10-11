// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Http.Headers;
using System.Linq.Expressions;

namespace ConsoleAppPlayground
{
    public class Orders
    {
        private static HashSet<int> usedOrderIDs = new HashSet<int>();
        private static HashSet<int> usedItemIDs = new HashSet<int>();
        public static void Main() 
        { }

        public Orders(int orderid, int itemid)
        {
            OrderID = orderid;
            ItemID = itemid;
            ItemName = string.Empty;
            ItemStatus = string.Empty;
            ItemSizes = new List<string>();
            //OrderInfoDict = new Dictionary<int, List<int>>();
            ItemInfoDict = new Dictionary<int, Dictionary<string, List<string>>>();
            ItemStockDict = new Dictionary<int, Dictionary<string, int>>();

            //try/Catch Block: similar to rescue in Rails - try 

            if (usedOrderIDs.Contains(orderid))
            {
                throw new ArgumentException($"{orderid} is not unique.");
            }
            else
            {
                usedOrderIDs.Add(orderid);
            }
            
            if (usedItemIDs.Contains(itemid))
            {
                throw new ArgumentException($"{itemid} is not unique.");
            }
            else
            {
                usedItemIDs.Add(itemid);
            }



            // Check if the OrderInfoDict is already initialized
            if (OrderInfoDict == null)
            {
                OrderInfoDict = new Dictionary<int, List<int>>();
            }

            // automatically create key/value pair
            if (OrderInfoDict.ContainsKey(orderid))
            {
                OrderInfoDict[orderid].Add(itemid); // If the key exists, add the itemid to the list
            }
            else
            {
                OrderInfoDict[orderid] = new List<int> { itemid }; // If the key doesn't exist, create a new list with the itemid
            }

        }

        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemStatus { get; set; }
        public List<string> ItemSizes { get; set; }
        public static Dictionary<int, List<int>>? OrderInfoDict { get; set; } 
        public Dictionary<int, Dictionary<string, List<string>>> ItemInfoDict { get; set; } // itemid, [tyes of applicable hazards]
        public Dictionary<int, Dictionary<string, int>> ItemStockDict { get; set; } // shelf, bulk, backorder


        //Method to add item with initial dictionary
        public static void AddItemToDictionaries(Dictionary<int, Dictionary<string, List<string>>> dictionary, int itemid)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary), "The dictionary does not exist and needs to be initialized.");
            }
            else if (OrderInfoDict.Any(kvp => kvp.Value.Contains(itemid))) //confirm that itemid is valid
            {
               if (!dictionary.ContainsKey(itemid))
                    {
                        dictionary[itemid] = new Dictionary<string, List<string>>();
                    }
            }
            else
            {
                return;
            }
        }


    }
}


//    while (requestedGenre != null)
//        if (filmsDict.ContainsKey(requestedGenre))
//Console.WriteLine(filmsDict[requestedGenre]);
//    else if (filmsDict.ContainsKey(requestedGenre))
//        Console.WriteLine("There are no films in that genre. Would you like to add one?");


//     else
//         Console.WriteLine("Okay, select another genre");
//         var requestedGenre = Console.ReadLine();

//static void Main()
//{
//    // Create an instance of the Orders class
//    Orders orders = new(1, 2);

//    // Add items to the ItemInfoDict dictionary
//    AddItemToDictionaries(orders.ItemInfoDict, orders.ItemID);

//}

//Console.WriteLine("Hello, World!");
//Console.WriteLine("What movie genre are you interested in?");
//var requestedGenre = Console.ReadLine();