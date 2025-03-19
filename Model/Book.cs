//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bookmaster.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Book
    {
        public Book()
        {
            this.BookAuthor = new HashSet<BookAuthor>();
            this.BookCover = new HashSet<BookCover>();
            this.BookSubject = new HashSet<BookSubject>();
            this.Circulation = new HashSet<Circulation>();
        }
    
        public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Nullable<System.DateTime> FirstPublishDate { get; set; }
        public string Description { get; set; }

        public string Authors
        {
            get
            {
                return string.Join(", ", BookAuthor.Select(bookAuthor => bookAuthor.Author.Name));
            }
        }
        
    
        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
        public virtual ICollection<BookCover> BookCover { get; set; }
        public virtual ICollection<BookSubject> BookSubject { get; set; }
        public virtual ICollection<Circulation> Circulation { get; set; }
    }
}
