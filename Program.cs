using System;

namespace uniStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //var garage = new CarGarage();
            //garage.Add(new Car("asd-123"),new Car("dsa-321"));

            //var storeresult = garage.GetAll();

            var idStore = new GenericStore<int>();
            idStore.Add(1,2,3,4,5,6);
            var storeresult = idStore.GetAll();

            var garage = new GenericStore<Car>();
            garage.Add(new Car("asd-123"),new Car("dsa-321"));

            var storeResult = garage.GetAll();
        }
    }
}
