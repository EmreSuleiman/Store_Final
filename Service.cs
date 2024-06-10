using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using StoreProject.Models;
using StoreProject.Data;


public class StoreManager
{
    private readonly StoreContext _context;

    public StoreManager()
    {
        _context = new StoreContext();
        _context.Database.Migrate();
    }
    public List<Article> GetArticles()
    {
        return _context.Articles.ToList();
    }

    public void AddArticle(Article item)
    {
        _context.Articles.Add(item);
        _context.SaveChanges();
    }

    public void AddClient(Person client)
    {
        _context.Persons.Add(client);
        _context.SaveChanges();
    }

    public void PurchaseItem(int clientId, int itemId, int quantity)
    {
        var purchase = new Purchase
        {
            ClientId = clientId,
            ItemId = itemId,
            Quantity = quantity,
        };
        _context.Purchases.Add(purchase);
        _context.SaveChanges();
    }

    public List<Person> GetTopClients()
    {
        return _context.Persons
            .Include(c => c.Purchases)
            .ThenInclude(p => p.Item)
            .OrderByDescending(c => c.Purchases.Sum(p => p.Quantity * p.Item.SellPrice))
            .Take(3)
            .ToList();
    }

    public List<Purchase> GetPurchasesByClientId(int clientId)
    {
        return _context.Purchases
            .Include(p => p.Item)
            .Where(p => p.ClientId == clientId)
            .ToList();
    }

    public Article GetHitItem()
    {
        return _context.Articles
            .Include(i => i.Purchases)
            .OrderByDescending(i => i.Purchases.Sum(p => p.Quantity * i.SellPrice))
            .FirstOrDefault();
    }
}