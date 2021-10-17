using Domain.DataModels;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Idempotency
{
    public class RequestManager : IRequestManager
    {
        private readonly KanbanContext _context;

        public RequestManager(KanbanContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            var request = await _context.
                FindAsync<Request>(id);

            return request != null;
        }

        public async Task CreateRequestForCommandAsync<T>(Guid id)
        {
            var exists = await ExistAsync(id);

            var request = exists ?
                throw new ApplicationException($"Request with {id} already exists") :
                new Request()
                {
                    Id = id,
                    Name = typeof(T).Name,
                    Time = DateTime.UtcNow
                };

            _context.Add(request);

            await _context.SaveChangesAsync();
        }
        public async Task CreateRequestForCommandNoIDRequestAsync<T>(Guid id)
        {


            var request = new Request()
            {
                Id = id,
                Name = typeof(T).Name,
                Time = DateTime.UtcNow
            };

            _context.Add(request);

            await _context.SaveChangesAsync();
        }
    }
}