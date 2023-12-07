
namespace Store.Service.Basket.Repositories
{
    public interface IBasketLinesRepository
    {
        Task<IEnumerable<Entities.BasketLine>> GetBasketLines(Guid basketId);

        Task<Entities.BasketLine> GetBasketLineById(Guid basketLineId);

        Task<Entities.BasketLine> AddOrUpdateBasketLine(Guid basketId, Entities.BasketLine basketLine);

        void UpdateBasketLine(Entities.BasketLine basketLine);

        void RemoveBasketLine(Entities.BasketLine basketLine);

        Task<bool> SaveChanges();
    }
}