using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLCafe.Domain.Enums;

namespace QLCafe.Application.DTOs.Account
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Phone { get; set; }
        public RoleType Role { get; set; }
        public string Status { get; set; } // Hoạt động / Ngừng
    }
}
