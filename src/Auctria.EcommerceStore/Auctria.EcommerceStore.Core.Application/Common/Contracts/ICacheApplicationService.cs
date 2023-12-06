namespace Auctria.EcommerceStore.Core.Application.Common.Contracts
{
    public interface ICacheApplicationService<T> where T : class
    {
        T GetCachedItems(string key);
        void DeleteCachedItems(string key);
        void SetCachedItems(T entry, string key);
        void SetListCachedItems(IEnumerable<T> entry, string key);
        IEnumerable<T> GetCachedItemsList(string key);
    }
}
