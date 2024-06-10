using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreProject.Data;
using StoreProject.Models;

namespace StoreProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeManager = new StoreManager();

            while (true)
            {
                Console.WriteLine("1) Закупуване на стоки");
                Console.WriteLine("2) Справки");
                Console.WriteLine("3) Добавяне на нов артикул");
                Console.WriteLine("4) Добавяне на нов клиент");
                Console.WriteLine("Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PurchaseItems(storeManager);
                        break;
                    case "2":
                        GenerateReports(storeManager);
                        break;
                    case "3":
                        AddNewItem(storeManager);
                        break;
                    case "4":
                        AddNewClient(storeManager);
                        break;
                    case "Exit":
                        return;
                }
            }
        }
        static void PurchaseItems(StoreManager storeManager)
        {
            var items = storeManager.GetArticles();
            foreach (var item in items)
            {
                Console.WriteLine($"{item.ID}) {item.Description}");
            }

            Console.WriteLine("Enter purchase command (e.g., 3>5x7+2x3+6x1):");
            var command = Console.ReadLine();
            var parts = command.Split('>');
            var clientId = int.Parse(parts[0]);
            var purchases = parts[1].Split('+');

            foreach (var purchase in purchases)
            {
                var itemParts = purchase.Split('x');
                var quantity = int.Parse(itemParts[0]);
                var itemId = int.Parse(itemParts[1]);
                storeManager.PurchaseItem(clientId, itemId, quantity);
            }
        }

        static void GenerateReports(StoreManager storeManager)
        {
            Console.WriteLine("1) Топ клиенти");
            Console.WriteLine("2) По ID на клиент");
            Console.WriteLine("3) Хит стока");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var topClients = storeManager.GetTopClients();
                    foreach (var client in topClients)
                    {
                        Console.WriteLine($"{client.FirstName} {client.LastName}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Enter client ID:");
                    var clientId = int.Parse(Console.ReadLine());
                    var purchases = storeManager.GetPurchasesByClientId(clientId);
                    foreach (var purchase in purchases)
                    {
                        Console.WriteLine($"{purchase.Item.Description} {purchase.Quantity}");
                    }
                    break;
                case "3":
                    var hitItem = storeManager.GetHitItem();
                    if (hitItem != null)
                    {
                        Console.WriteLine($"{hitItem.Description} {hitItem.SellPrice}");
                    }
                    break;
            }
        }
        static void AddNewItem(StoreManager storeManager)
        {
            Console.WriteLine("Enter item description:");
            var description = Console.ReadLine();
            Console.WriteLine("Enter item category:");
            var category = Console.ReadLine();
            Console.WriteLine("Enter wholesale price:");
            var wholesalePrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter retail price:");
            var retailPrice = decimal.Parse(Console.ReadLine());

            var item = new Article
            {
                Description = description,
                Category = category,
                BuyCost = wholesalePrice,
                SellPrice = retailPrice
            };

            storeManager.AddArticle(item);
        }
        static void AddNewClient(StoreManager storeManager)
        {
            Console.WriteLine("Enter client first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter client last name:");
            var lastName = Console.ReadLine();

            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            storeManager.AddClient(person);
        }
    }
}
