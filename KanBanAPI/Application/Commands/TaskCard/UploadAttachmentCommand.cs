using MediatR;

namespace KanBanAPI.Application.Commands.TaskCard
{
    public class UploadAttachmentCommand : IRequest<bool>
    {
        public int IdTaskCard { get; set; }
        //public AttachmentDTO AttachmentDTO { get; set; }

        //public UploadAttachmentCommand(int idTaskCard, AttachmentDTO attachmentDTO)
        //{
        //    IdTaskCard = idTaskCard;
        //    AttachmentDTO = attachmentDTO;
        //}
    }
}