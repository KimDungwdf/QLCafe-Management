using System;
using System.Collections.Generic;
using QLCafe.Domain.DTOs;

namespace QLCafe.Application.Interfaces
{
    public interface IBillService
    {
        List<BillHistoryDto> GetBillHistory(DateTime fromDate, DateTime toDate, int? tableId = null, int? status = null);
        List<string> GetAllTableNames();
    }
}
