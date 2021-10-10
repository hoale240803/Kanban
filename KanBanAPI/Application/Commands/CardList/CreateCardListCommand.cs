using MediatR;
using System.Runtime.Serialization;

namespace KanBanAPI.Application.Commands.CardList
{
    public class CreateCardListCommand : IRequest<bool>
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int IdUser{ get; set; }

        public CreateCardListCommand(string title,int idUser)
        {
            Title = title;
            IdUser = idUser;
        }
    }
}