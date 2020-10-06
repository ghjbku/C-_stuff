using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace uniStore
{
    class Car
    {
        private String License;

        public Car(String license) {

            if (license == null)
            {
                throw new ArgumentNullException(nameof(license));
            }
            else if (String.IsNullOrWhiteSpace(license))
            {

                throw new ArgumentException("License can't be empty");
            }
            License = license;
        }

        public String GetLicense() {
            return License;
        }
    }
}
