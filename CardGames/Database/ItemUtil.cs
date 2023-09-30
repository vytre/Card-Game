using CardGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Database
{
    public class ItemUtil {
        #region Get methods

        //GET'S FOR SHOP

        public static Item GetItem(int id) {
            using GamblingDbContext db = new();

            Item item = db.Item.SingleOrDefault(u => u.Id == id);
            return item;
        }

        public static string GetItemDesc(int id) {
            using GamblingDbContext db = new();

            Item item = db.Item.SingleOrDefault(u => u.Id == id);
            return item.Description;
        }
        #endregion

        #region CRUD methods

        //CREATE
        public static Item CreateItem(string name, string description, int price) {
            using GamblingDbContext db = new();

            Item item = new() { Name = name, Description = description, Price = price };
            db.Add(item);
            db.SaveChanges();

            return item;
        }

        //READ
        public static List<Item> ReadItems() {
            using GamblingDbContext db = new();

            List<Item> item = db.Item.Select(i => i).ToList();
            return item;
        }

        //UPDATE
        public static Item ChangeItemName(int id, string name) {

            using GamblingDbContext db = new();

            Item item = db.Item.SingleOrDefault(u => u.Id == id);
            if (item != null) {
                item.Name = name;
                db.Update(item);
                db.SaveChanges();
            }
            return item;

        }

        //UPDATE
        public static Item ChangeItemDesc(int id, string description) {

            using GamblingDbContext db = new();

            Item item = db.Item.SingleOrDefault(u => u.Id == id);
            if (item != null) {
                item.Description = description;
                db.Update(item);
                db.SaveChanges();
            }
            return item;
        }

        public static Item ChangeItemPrice(int id, int price) {

            using GamblingDbContext db = new();

            Item item = db.Item.SingleOrDefault(u => u.Id == id);
            if (item != null) {
                item.Price = price;
                db.Update(item);
                db.SaveChanges();
            }
            return item;
        }

        //DELETE
        public static Item DeleteItem(int id) {

            using GamblingDbContext db = new();

            Item item = db.Item.SingleOrDefault(u => u.Id == id);
            if (item != null) {
                db.Remove(item);
                db.SaveChanges();
            }
            return item;
        }

        #endregion
        
    }
    
}

