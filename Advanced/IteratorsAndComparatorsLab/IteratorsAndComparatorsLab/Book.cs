using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            this.Authors = authors.ToList();
        }

        public int CompareTo([AllowNull] Book other)
        {
            int result = this.Year.CompareTo(other.Year);

            if (result == 0)
            {
                 result = this.Title.CompareTo(other.Title);
            }
            return result;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}"; 
        }
    }
    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book book1, [AllowNull] Book book2)
        {
            int result = book1.Title.CompareTo(book2.Title);

            if (result == 0)
            {
                result = book1.Year.CompareTo(book2.Year);
            }
            return result;
        }
    }
}
