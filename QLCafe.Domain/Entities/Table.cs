using System;

namespace QLCafe.Domain.Entities
{
    public class Table // SỬA: internal -> public
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TableStatus Status { get; set; }
    }

    public enum TableStatus // SỬA: internal -> public
    {
        Empty = 0,
        Occupied = 1
    }
}