using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace random
{
    class Data
    {
        [Key]
        public string Name { get; set; }
    }
    class Db : DbContext
    {
        public DbSet<Data> Items { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Db())
            {
                if (db.Items.Count() == 0)
                {
                    db.Items.Add(new Data { Name = "A" });
                    db.Items.Add(new Data { Name = "B" });
                    db.Items.Add(new Data { Name = "C" });
                    db.Items.Add(new Data { Name = "D" });
                    db.SaveChanges();
                }
                var qry = from row in db.Items orderby row.Name select row;
                int count = qry.Count(); // 1st round-trip
                int index = new Random().Next(count);
                var cust = qry.Skip(index).FirstOrDefault();
                Console.WriteLine(cust.Name);
            }
        }
    }
}