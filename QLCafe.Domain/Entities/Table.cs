using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.Domain.Entities
{
    internal class Table
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TableStatus Status { get; set; }
    }

    public enum TableStatus
    {
        Empty = 0,
        Occupied = 1
    }
}
