using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_jrencher.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public virtual void AddItem (Book book, int qty)
        {
            CartLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = book,
                    Quantity = qty

                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public virtual double CalculateTotal()
        {
            var sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }

    }

    

    public class CartLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
