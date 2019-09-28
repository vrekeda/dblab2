using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace dblab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            //dblab2Context db = new dblab2Context();
            //    //// создаем два объекта User
            //    //User user1 = new User { Name = "Tom", Age = 33 };
            //    //User user2 = new User { Name = "Alice", Age = 26 };

            //    //// добавляем их в бд
            //    //db.Users.Add(user1);
            //    //db.Users.Add(user2);
            //    //db.SaveChanges();

            //    // получаем объекты из бд и выводим на консоль
            //    Console.WriteLine("connecting");
            //    var clients = db.Clients.Where(c => c.Gender==true).ToList();

            //    Console.WriteLine("clients=...");

            //    Console.WriteLine("Users list:");
            //    foreach (Client client in clients)
            //    {
            //        Console.WriteLine($"{client.Id} {client.Firstname} {client.Lastname} {client.Birthdate} {client.Gender}");
            //    }


            //    var tac = db.TravelAgencys.Include(tc => tc.TravelAgencyToClient).ThenInclude(t => t.Client).ToList();

            //    Console.WriteLine("tac=...");
            //    foreach (var c in tac)
            //    {
            //        Console.WriteLine($"\n ta: {c.Name}");
            //        // выводим всех студентов для данного кура
            //        var students = c.TravelAgencyToClient.Select(sc => sc.Client).ToList();
            //        foreach (Client s in students)
            //            Console.WriteLine($"{s.Firstname } {s.Lastname}");
            //    }

            //    //var tc=db.Clients.I
            //Console.Read();
        }
    }
}
