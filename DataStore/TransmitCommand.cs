using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class DataStoreContext : DbContext
    {
        public DataStoreContext() : base("name=TransmitCommand")
        {

        }
        public DbSet<TransmitCommand> TransmitCommands { get; set; }
    }
    public class TransmitCommand
    {
        private int id;
        private int number;
        private string carID;
        private string railID;
        private string startPhysicalAddress;
        private string startLogicalAddress;
        private string targetPhysicalAddress;
        private string targetLogicalAddress;
        private int priority;
        private DateTime createTime;
        private DateTime completeTime;
        private bool isComplete;
        public int ID { get; set; }
        public string Number { get; set; }
        public string CarID { get; set; }
        public string RailID { get; set; }
        public string StartPhysicalAddress
        {
            get; set;
        }
        public string StartLogicalAddress
        {
            get; set;
        }
        public string TargetPhysicalAddress
        {
            get; set;
        }
        public string TargetLogicalAddress
        {
            get; set;
        }
        public int Priority { get; set; }
        public DateTime CreateTime
        {
            get; set;
        }
        public DateTime CompleteTime
        {
            get; set;
        }
        public bool IsComplete
        {
            get; set;
        }
    }
}
