using System;
using System.Collections.Generic;
using System.Text;

namespace bank_unit_testing
{
    public class BankAccount
    {
        public string customerName { get; }
        public int Balance { get; private set; }

        public BankAccount(string name,int initialValue) {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace", nameof(name));
            }

            customerName = name;
            Balance = initialValue;

            if (initialValue < 0) {
                throw new ArgumentOutOfRangeException(" initial value is negative: " + nameof(initialValue));
            }
        }

        public void Deposit(int addValue) {
            if (addValue < 0) {
                throw new ArgumentOutOfRangeException(" initial value is negative: " + nameof(addValue));
            }
            Balance = Balance + addValue;
        }

        public void WithDraw(int RemoveValue) {
            if (RemoveValue > Balance)
            {
                throw new ArgumentException( " cant take off more than there is: " + nameof(RemoveValue));
            }
            Balance = Balance - RemoveValue;
        }
    }
}
