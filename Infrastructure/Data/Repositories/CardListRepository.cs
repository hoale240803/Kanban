using Domain.AggregatesModel.CardLists;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CardListRepository : ICardListRepository
    {
        private readonly KanbanContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public CardListRepository(KanbanContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CardListObject Add(CardListObject cardList)
        {
            return _context.CardLists.Add(cardList).Entity;
        }

        public bool Delete(int id)
        {
            var existCardList = _context.CardLists.FirstOrDefault(x => x.Id == id);
            if (existCardList != null)
            {
                throw new ApplicationException("CardList not found");
            }
            _context.CardLists.Remove(existCardList);

            return true;
        }

        public async Task<CardListObject> GetAsync(int cardListId)
        {
            var cardList = await _context
                                  .CardLists
                                  .FirstOrDefaultAsync(o => o.Id == cardListId);
            if (cardList == null)
            {
                cardList = _context
                            .CardLists
                            .Local
                            .FirstOrDefault(o => o.Id == cardListId);
            }
            if (cardList != null)
            {
                await _context.Entry(cardList)
                    .Collection(i => i.TaskCards).LoadAsync();
                //await _context.Entry(cardList)
                //    .Reference(i => i.).LoadAsync();
            }

            return cardList;
        }

        public void Update(CardListObject cardList)
        {
            _context.Entry(cardList).State = EntityState.Modified;
        }

        public bool UpdateTitle(string title, int idCardList)
        {
            var existCardList = _context.CardLists.FirstOrDefault(x => x.Id == idCardList);

            if (existCardList == null)
            {
                return false;
            }
            existCardList._title = title;
            return true;
        }
    }
}