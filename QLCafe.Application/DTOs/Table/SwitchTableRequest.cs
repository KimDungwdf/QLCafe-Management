using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.Application.DTOs.Table
{
    public class SwitchTableRequest
    {
        public int FromTableId { get; set; }
        public int ToTableId { get; set; }
        public string UserName { get; set; }
    }
}