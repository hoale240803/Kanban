using Domain.AggregatesModel.Attachments;
using Domain.SeedWork;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    internal class AttachmentRepository : IAttachmentRepository
    {
        public IUnitOfWork UnitOfWork => throw new System.NotImplementedException();

        public AttachmentObject Add(AttachmentObject order)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<AttachmentObject> GetAsync(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(AttachmentObject order)
        {
            throw new System.NotImplementedException();
        }
    }
}