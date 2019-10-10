using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Console_Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {

                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();
                Console.WriteLine("Console Blog Platform");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();
                bool control_a = true;
                while (control_a == true)
                {
                    Console.WriteLine("Wprowadź nowy tytuł wpisu:");
                    string a = Console.ReadLine();
                    Console.WriteLine("Wprowadź nowy wpis");
                    string b = Console.ReadLine();
                    blog.Posts.Add(
                    new Post
                    {

                        Title = a,
                        Content = b
                    });
                    db.SaveChanges();
                    Console.WriteLine("Jeśli chcesz wyświetlić zawartość bloga wprowadź w");
                    Console.WriteLine("Jeśłi chcesz wprowadzić kolejny wpis wciśnij dowony inny klawisz.");
                    string choice_a = Console.ReadLine();
                    if (choice_a == "w")
                    {
                        var number = db.Posts
                            .ToList();
                        Console.WriteLine("Na blogu jest: "+number.Count + " wpisów");
                        Console.WriteLine("Wprowadź liczbę wpisów które chcesz obaczyć");
                        string choice_b = Console.ReadLine();
                        int int_choice_b = Convert.ToInt32(choice_b);
                        for (int n=1; n<=int_choice_b; n++)
                        {
                            var title = db.Posts
                        .Single(b => b.PostId == n).Title;
                            string title_string = Convert.ToString(title);

                            var body = db.Posts
                                .Single(b => b.PostId == n).Content;
                            string body_string = Convert.ToString(body);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("=====================================================================");
                            Console.WriteLine(title_string);
                            Console.WriteLine(body_string);
                            Console.WriteLine("=====================================================================");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    

                }


            }
        }
    }
}
