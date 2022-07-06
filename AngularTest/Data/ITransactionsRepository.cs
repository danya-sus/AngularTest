using AngularTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularTest.Data
{
    public interface ITransactionsRepository
    {
        Task<IEnumerable<Airline>> GetAllAirlinesAsync();

        Task<IEnumerable<AllData>> GetAllTicketsAsync();

        Task<IEnumerable<AllData>> GetByDocNumAsync(string docNum);

        Task<IEnumerable<AllData>> GetByTicketNumAsync(string ticketNum);
    }
}
