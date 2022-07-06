﻿using AngularTest.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTest.Data
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly TransactionsContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public TransactionsRepository(TransactionsContext context, IMapper mapper, IConfiguration configuration, ILogger<TransactionsRepository> logger)
        {
            this._context = context;
            this._mapper = mapper;
            this._configuration = configuration;
            this._logger = logger;
        }

        public async Task<IEnumerable<Airline>> GetAllAirlinesAsync()
        {
            var sqlRequest = File.ReadAllText(_configuration.GetSection("SqlRequests")["GetAirlines"]);

            var result = _mapper.Map<IEnumerable<Airline>>(
                await _context.airline_company.FromSqlRaw(sqlRequest).ToListAsync());

            if (result.Count() > 0)
            {
                return result;
            }
            throw new NullReferenceException("No data available");
        }

        public async Task<IEnumerable<AllData>> GetByDocNumAsync(string docNumber)
        {
            var sqlRequest = File.ReadAllText(_configuration.GetSection("SqlRequests")["ByDocNum"]);

            var result = _mapper.Map<IEnumerable<AllData>>(
                await _context.data_all.FromSqlRaw(sqlRequest, docNumber).ToListAsync());

            if (result.Count() > 0)
            {
                return result;
            }
            throw new NullReferenceException("No data available");
        }

        public async Task<IEnumerable<AllData>> GetByTicketNumAsync(string ticketNumber)
        {
            var sqlRequest = File.ReadAllText(_configuration.GetSection("SqlRequests")["ByTicketNum"]);

            var result = _mapper.Map<IEnumerable<AllData>>(
                await _context.data_all.FromSqlRaw(sqlRequest, ticketNumber).ToListAsync());

            if (result.Count() > 0)
            {
                return result;
            }
            throw new NullReferenceException("No data available");
        }

        public async Task<IEnumerable<AllData>> GetByTicketNumAllAsync(string ticketNumber)
        {
            var sqlRequest = File.ReadAllText(_configuration.GetSection("SqlRequests")["ByTicketNumAll"]);

            var result = _mapper.Map<IEnumerable<AllData>>(
                await _context.data_all.FromSqlRaw(sqlRequest, ticketNumber).ToListAsync());

            if (result.Count() > 0)
            {
                return result;
            }
            throw new NullReferenceException("No data available");
        }
    }
}
