using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project_with_Database
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class UserContext :DbContext
    {
        public UserContext() : base("DbConnection")
        { }
        public DbSet<User> Users { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                /*User user1 = new User { Name = "Sergey", Age = 20 };
                db.Users.Add(user1);*/
                db.SaveChanges();
                var users = db.Users;
                foreach(User u in users)
                {
                    Console.WriteLine("Number {0}. {1}: Age {2};", u.Id, u.Name, u.Age);
                }
                User user2 = db.Users.LastOrDefault();
                user2.Age = 45;
                db.SaveChanges();
                Console.Read();
            }
        }
    }
}
