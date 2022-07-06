using AngularTest.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTest.Data
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly TransactionsContext _context;
        private readonly IMapper _mapper;

        public TransactionsRepository(TransactionsContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Airline>> GetAllAirlinesAsync()
        {
            return _mapper.Map<IEnumerable<Airline>>(await _context.airline_company.ToListAsync());
        }

        public async Task<IEnumerable<AllData>> GetAllTicketsAsync()
        {
            return _mapper.Map<IEnumerable<AllData>>(await _context.data_all.ToListAsync());
        }

        public async Task<IEnumerable<AllData>> GetByDocNumAsync(string docNumber)
        {
            var data = _mapper.Map<IEnumerable<AllData>>(await _context.data_all.Where(d => d.PassengerDocumentNumber == docNumber).ToListAsync());

            if (data.Count() > 0)
            {
                return data;
            }

            throw new NullReferenceException("No data available");
        }

        public async Task<IEnumerable<AllData>> GetByTicketNumAsync(string ticketNumber)
        {
            var data = _mapper.Map<IEnumerable<AllData>>(await _context.data_all.Where(d => d.TicketNumber == ticketNumber).ToListAsync());

            if (data.Count() > 0)
            {
                return data;
            }

            throw new NullReferenceException("No data available");
        }
    }
}
