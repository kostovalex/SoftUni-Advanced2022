using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            
        }
        public void ListOrderer()
        {
            IComparer<Book> comparer = new BookComparator();
            SortedSet<Book> sortedBooks = new SortedSet<Book>(comparer);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex; 
            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            
            public void Dispose() { }
            public bool MoveNext() => ++this.currentIndex < this.books.Count;
            public Book Current => books[currentIndex];
            object IEnumerator.Current => this.Current;
            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
    
}
