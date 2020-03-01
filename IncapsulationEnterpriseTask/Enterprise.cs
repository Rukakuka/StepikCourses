using System;
using System.Linq;

namespace Incapsulation.EnterpriseTask
{
    public class Enterprise
    {
        public readonly Guid Guid;

        public Enterprise(Guid guid)
        {
            Guid = guid;
        }

        public string Name { get; set; }


        public string Inn
        {
            get { return Inn; }
            set
            {
                if (value.Length != 10 || !value.All(z => char.IsDigit(z)))
                    throw new ArgumentException();
                Inn = value;
            }
        }

        public DateTime EstablishDate { get; set; }

        public TimeSpan ActiveTimeSpan
        {
            get { return DateTime.Now - EstablishDate; }
        }

        public double GetTotalTransactionsAmount()
        {
            DataBase.OpenConnection();
            var amount = 0.0;
            foreach (Transaction t in DataBase.Transactions().Where(z => z.EnterpriseGuid == Guid))
                amount += t.Amount;
            return amount;
        }
    }
}