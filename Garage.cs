using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace uniStore
{
   class CarGarage
    {
        private List<Car> cars;

        public CarGarage() {

            cars = new List<Car>();
        }

        public void Add(params Car[] items) {

            cars.AddRange(items);
        }

        public IEnumerable<Car> GetAll() {

            return cars;
        }
    }
}
