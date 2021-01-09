using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                string title = tokens[0];
                string content = tokens[1];
                string author = tokens[2];
                Article article = new Article(title, content, author);
                articles.Add(article);
            }
            string criteria = Console.ReadLine();
            //Order == Sort
            if (criteria == "title")
            {
               articles = articles.OrderBy(a => a.Title).ToList();
            }
            else if (criteria == "content")
            {
                articles.Sort((c1, c2) => c1.Content.CompareTo(c2.Content));
            }
            else if (criteria == "author")
            {
               articles = articles.OrderBy(a => a.Author).ToList();
            }
            Console.WriteLine(string.Join(Environment.NewLine,articles));
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }      
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
