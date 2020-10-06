using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace uniStore
{
   public class Garage
    {
        private List<int> ids;

        public Garage() {

            ids = new List<int>();
        }

        public void Add(params int[] items) {

            ids.AddRange(items);
        }

        public IEnumerable<int> GetAll() {

            return ids;
        }
    }
}
