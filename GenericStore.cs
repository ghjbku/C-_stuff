using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace uniStore
{
    class GenericStore<T>
    {
        private List<T> Items;

        public GenericStore()
        {
            Items = new List<T>();
        }

        public void Add(params T[] items) {
            Items.AddRange(items);
        }

        public IEnumerable<T> GetAll() {
            return Items;
        }
    }
}
