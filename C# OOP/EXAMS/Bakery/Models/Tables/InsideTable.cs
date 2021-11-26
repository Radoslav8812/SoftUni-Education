using System;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {

        public InsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, 2.50m)
        {
        }
    }
}
