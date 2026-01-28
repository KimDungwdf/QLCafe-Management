using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using QLCafe.Domain.DTOs;
using QLCafe.Application.Interfaces;
using QLCafe.Infrastructure.Repositories;

namespace QLCafe.Application.Services
{
    public class BillService : IBillService
    {
        private readonly BillRepository _repository;

        public BillService(string connectionString)
        {
            _repository = new BillRepository(connectionString);
        }

        public List<BillHistoryDto> GetBillHistory(DateTime fromDate, DateTime toDate, int? tableId = null, int? status = null)
        {
            return _repository.GetBillHistory(fromDate, toDate, tableId, status);
        }

        public List<string> GetAllTableNames()
        {
            return _repository.GetAllTableNames();
        }
    }
}
