using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    internal class Bank : IEnumerable
    {
        public ObservableCollection<Client> listOfClients { get; private set; }
        public StringBuilder Logs { get; private set; }

        public int CountClients { get { return this.listOfClients.Count; } }
        public DateTime dateNow { get; private set; }

        public Bank()
        {
            this.listOfClients = new ObservableCollection<Client>();
            this.dateNow = DateTime.Now;
            this.Logs = new StringBuilder();
        }
        public Bank(Client client)
        {
            this.listOfClients = new ObservableCollection<Client> { client };
            this.dateNow = DateTime.Now;
            this.Logs = new StringBuilder();
        }

        public Client this[int index]
        {
            get { return this.listOfClients[index]; }
        }

        public void AddClient(Client client)
        {
            this.listOfClients.Add(client);
            string type;
            if (client is Individual)
            {
                type = "Физическое лицо";
            }
            else if (client is VIP)
            {
                type = "VIP";
            }
            else
            {
                type = "Юридическое лицо";
            }
            Logs.Append($"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}]: Добавление клиента" +
                $" {type} {client.FullName}.\n");
        }

        public void RemoveClient(Client client)
        {
            this.listOfClients.Remove(client);
        }

        public DateTime AddDay()
        {
            this.dateNow = this.dateNow.AddDays(1); 
            this.listOfClients.ToList().ForEach(c => c.OnCheckDay?.Invoke(this.dateNow));
            return this.dateNow;
        }

        public void RemoveAtClient(int index)
        {
            this.listOfClients.RemoveAt(index);
        }

        public IEnumerator GetEnumerator()
        {
            return this.listOfClients.GetEnumerator();
        }
    }
}
