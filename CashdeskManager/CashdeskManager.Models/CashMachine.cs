using System;
using System.Collections.Generic;
using System.Text;

namespace CashdeskManager.Models
{
    public class CashMachine
    {
        public CashMachine(int id, bool state, int customerCount)
        {
            this.Id = id;
            this.State = state;
            this.CustomerCount = customerCount;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public int CustomerCount { get; set; }
    }
}
