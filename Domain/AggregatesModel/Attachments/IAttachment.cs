

using Domain.Attachments;
using Domain.SeedWork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.Attachments
{
    public interface IAttachmentRepository : IRepository<AttachmentObject>
    {
        AttachmentObject Add(AttachmentObject order);

        void Update(AttachmentObject order);

        Task<AttachmentObject> GetAsync(int orderId);

        void Delete(string id);
    }
}