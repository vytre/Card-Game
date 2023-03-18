using CardGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Database
{
    public class InventoryUtil
    {
        #region CRUD methods

        //CREATE
        public static Inventory AddItemToInventory(int userId, int itemId)
        {
            using GamblingDbContext db = new();

            Inventory inventory = new() { UserId = userId, ItemId = itemId };
            db.Add(inventory);
            db.SaveChanges();

            Item? item = db.Item.SingleOrDefault(i => i.Id == itemId);
            Console.WriteLine("Added " + item.Name + "  to your inventory");
            return inventory;
        }

        //READ
        // REFRENCE FOR QUERY: https://dotnettutorials.net/lesson/left-outer-join-in-linq/
        public static void ReadUserInventory(User user)
        {
            using GamblingDbContext db = new();

            List<Inventory> Inventories = db.Inventory.Where(i => i.UserId == user.Id).Select(i => i).ToList();

            var userInventoryQuery = Inventories
                                     .GroupJoin(
                                        ItemUtil.ReadItems(),
                                        inv => inv.ItemId,
                                        ite => ite.Id,
                                        (inv, ite) => new { inv, ite }
                                        )
                                    .SelectMany(
                                        x => x.ite.DefaultIfEmpty(),
                                        (inventory, item) => new { inventory, item }
                                    );

            foreach (var item in userInventoryQuery)
            {
                Console.WriteLine($"Item: {item.item?.Name} | Description: {item.item?.Description}");
            }
        }


        //UPDATE
        public static Inventory ChangeUserId(Inventory? inventory,int UserId)
        {

            using GamblingDbContext db = new();

            inventory = db.Inventory.SingleOrDefault(u => u.Id == inventory.Id);
            if (inventory != null)
            {
                inventory.UserId = UserId;
                db.Update(inventory);
                db.SaveChanges();
            }
            return inventory;

        }

        public static Inventory ChangeItemId(Inventory? inventory, int itemId)
        {

            using GamblingDbContext db = new();

            inventory = db.Inventory.SingleOrDefault(u => u.Id == inventory.Id);
            if (inventory == null)
            {
                inventory.ItemId = itemId;
                db.Update(inventory);
                db.SaveChanges();
            }
            return inventory;

        }

        //DELETE
        public static void DeleteUserInventory(int userId) {

            using GamblingDbContext db = new();

            Inventory inventory = db.Inventory.SingleOrDefault(u => u.Id == userId);
            if (inventory != null) {
                db.Remove(inventory);
                db.SaveChanges();
            }
        }
        public static void DeleteInventory(Inventory? inventory) {

            using GamblingDbContext db = new();

            inventory = db.Inventory.SingleOrDefault(u => u.Id == inventory.Id);
            if (inventory != null) {
                db.Remove(inventory);
                db.SaveChanges();
            }
        }
        #endregion
    }
}
