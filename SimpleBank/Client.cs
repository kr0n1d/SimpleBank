using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework_13
{
    internal abstract class Client : IClient
    {
        protected int countTime;
        protected decimal sum;
        public Action<DateTime> OnCheckDay { get; }
        public decimal Sum 
        { 
            get
            {
                return Math.Round(this.sum, 2);
            }
            protected set
            {
                this.sum = value;
            }
        }
        protected DateTime StartDeposit { get; private set; }
        public string StartDate 
        { 
            get
            {
                return StartDeposit.ToShortDateString();
            }
        }
        public bool Capitalization { get; set; }
        public string FullName { get; private set; }
        public string ClientType { get; private set; }

        public Client(string fullName, bool capitalization, decimal startCopital)
        {
            this.FullName = fullName;
            this.Capitalization = capitalization;
            this.Sum = startCopital;
            this.StartDeposit = DateTime.Now;
            this.OnCheckDay = CheckDay;
            this.countTime = 0;
            if (this is Individual)
            {
                ClientType = "Физическое лицо";
            }
            else if (this is VIP)
            {
                ClientType = "VIP";
            }
            else
            {
                ClientType = "Юридическое лицо";
            }
        }

        private void IncreaseAmountWithCapitalization()
        {
            if (this is Individual)
            {
                this.Sum += (this.Sum * 0.01m);
            }
            else if (this is VIP)
            {
                this.Sum += (this.Sum * 0.015m);
            }
            else
            {
                this.Sum += (this.Sum * 0.02m);
            }
        }

        private void IncreaseAmountWithotCapitalization()
        {
            if (this is Individual)
            {
                this.Sum += (this.Sum * 0.12m);
            }
            else if (this is VIP)
            {
                this.Sum += (this.Sum * 0.15m);
            }
            else
            {
                this.Sum += (this.Sum * 0.2m);
            }
        }

        private void CheckDay(DateTime date)
        {
            if (this.Capitalization == true)
            {
                int month = (int)((date - this.StartDeposit).TotalDays / 30);
                if (month > this.countTime)
                {
                    this.countTime = month;
                    this.IncreaseAmountWithCapitalization();
                    MessageBox.Show($"У клиента {this.FullName} увеличилась сумма в банке. И теперь составляет {this.Sum} $");
                }
            }
            else
            {
                int year = (int)((date - this.StartDeposit).TotalDays / 365);
                if (year > this.countTime)
                {
                    this.countTime = year;
                    this.IncreaseAmountWithotCapitalization();
                    MessageBox.Show($"У клиента {this.FullName} увеличилась сумма в банке. И теперь составляет {this.Sum} $");
                }
            }
        }

        public void Put(decimal sum)
        {
            if (sum > 0)
            {
                this.Sum += sum;
                Console.WriteLine($"Клиент {this.FullName} успешно пополнил свой счет на сумму {sum} $.");
            }
            else
            {
                Console.WriteLine("Нельзя положить не положительную сумму на счет!");
            }
        }

        public void Transfer(Client toClient, decimal sum)
        {
            if (this.Sum >= sum)
            {
                this.Sum -= sum;
                toClient.Sum += sum;
                Console.WriteLine($"Клиент {this.FullName} успешно перевел {sum} $ клиенту {toClient.FullName}.");
            }
            else
            {
                Console.WriteLine("У Вас недостаточно средств для перевода!");
            }
        }

        public decimal Withdraw(decimal sum)
        {
            if (this.Sum >= sum)
            {
                this.Sum -= sum;
                Console.WriteLine($"Клиент {this.FullName} успешно снял {sum} $ со своего счета.");
                return sum;
            }
            else
            {
                Console.WriteLine("У Вас недостаточно средств для перевода!");
                return 0;
            }
        }

        public override string ToString()
        {
            return $"Full Name: {this.FullName, 7} | Deposit Type: {this.Capitalization,6} | Start Copital: {this.Sum:### ###.##, 8} $";
        }
    }
}
