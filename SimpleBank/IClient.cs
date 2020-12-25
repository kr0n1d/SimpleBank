using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    interface IClient
    {
        // Положить деньги на счет
        void Put(decimal sum);
        // Взять со счета
        decimal Withdraw(decimal sum);
        // Перевести со своего счета другому клиенту
        void Transfer(Client toClient, decimal sum);
    }
}
