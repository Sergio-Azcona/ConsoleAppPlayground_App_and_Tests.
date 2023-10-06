// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Net.NetworkInformation;

//Console.WriteLine("Hello, World!");
//Console.WriteLine("What movie genre are you interested in?");
//var requestedGenre = Console.ReadLine();

namespace ConsoleAppPlayground
{
    public class Orders
    {
        static void Main()
        {
            // Create an instance of the Orders class
            Orders orders = new(1, 2);

            // Add items to the ItemInfoDict dictionary
            AddItemToDictionaries(orders.ItemInfoDict, orders.ItemID);

        }
        public Orders(int orderid, int itemid)
        {
            OrderID = orderid;
            ItemID = itemid;
            ItemName = string.Empty;
            ItemStatus = string.Empty;
            ItemSizes = new List<string>();
            ItemInfoDict = new Dictionary<int, Dictionary<string, List<string>>>();
            ItemStockDict = new Dictionary<int, Dictionary<string, int>>();
        }

        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemStatus { get; set; }
        public List<string> ItemSizes { get; set; }
        public Dictionary<int, Dictionary<string, List<string>>> ItemInfoDict { get; set; }
        public Dictionary<int, Dictionary<string, int>> ItemStockDict { get; set; }


        //Method to add item with initial itemstockdictionary info
        static void AddItemToDictionaries(Dictionary<int, Dictionary<string, List<string>>> dictionary, int itemid)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary), "The dictionary does not exist and needs to be initialized.");
            }
            else if (!dictionary.TryGetValue(itemid, out _))
            {
                dictionary[itemid] = new Dictionary<string, List<string>>();
            }
            else if (dictionary.ContainsKey(itemid))
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