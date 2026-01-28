using System;
using System.Collections.Generic;
using QLCafe.Domain.DTOs;
using QLCafe.Application.Interfaces;
using QLCafe.Infrastructure.Repositories;

namespace QLCafe.Application.Services
{
    public class SalesReportService : ISalesReportService
    {
        private readonly SalesReportRepository _repository;

        public SalesReportService(string connectionString)
        {
            _repository = new SalesReportRepository(connectionString);
        }

        public SalesReportDto GetSalesReport(DateTime fromDate, DateTime toDate)
        {
            return _repository.GetSalesReport(fromDate, toDate);
        }

        public List<DailyRevenueDto> GetDailyRevenue(DateTime fromDate, DateTime toDate)
        {
            return _repository.GetDailyRevenue(fromDate, toDate);
        }

        public List<TopProductDto> GetTopProducts(DateTime fromDate, DateTime toDate, int topCount = 10)
        {
            return _repository.GetTopProducts(fromDate, toDate, topCount);
        }

        public List<EmployeeRevenueDto> GetEmployeeRevenue(DateTime fromDate, DateTime toDate)
        {
            return _repository.GetEmployeeRevenue(fromDate, toDate);
        }
    }
}
