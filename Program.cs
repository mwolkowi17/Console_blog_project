using System;
using System.Linq;

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
                    // próba wylistowania rekordów

                    var lista = db.Posts.ToList();

                    foreach (var rekord in lista)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("=====================================================================");
                        Console.WriteLine(rekord.PostId);
                        Console.WriteLine(rekord.Title);
                        Console.WriteLine(rekord.Content);
                        Console.WriteLine("=====================================================================");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine("Jeśli chcesz wprowadzić kolejny wpis wciśnij dowony inny klawisz.");
                    Console.WriteLine("Jeśli chcesz usunąć jakię wpis wpisz:kas");
                    string choice_a = Console.ReadLine();
                    bool choice_b = false;
                    if (choice_a == "kas")
                    {
                        choice_b = true;
                    }
                    while (choice_b == true)
                    {
                        //usunięcie konkretndo posta (o danym ID o ile istnieje)
                        Console.WriteLine("Wprowadź numer post do usunięcia:");
                        string o = Console.ReadLine();
                        int p = Convert.ToInt32(o);
                        //w tej chwili zawsze usuwa 2
                        var singlePost = db.Posts
                            .Single(b => b.PostId == p);

                        Console.WriteLine("usuwam post o tytule - " + singlePost.Title);
                        db.Remove(singlePost);
                        //db.Remove(blog);
                        db.SaveChanges();
                        choice_b = false;
                        Console.WriteLine("Kasujesz kolejny wpis? Jeśli tak wpisz: tak jeśli nie to dowolny inny klawisz");
                        string choice_c = Console.ReadLine();
                        if (choice_c == "tak")
                        {
                            choice_b = true;
                        }

                    }


                }


            }
        }
    }
}
