using csun_marketplace.data;

namespace csun_marketplace.services
{
    public interface ICSUNMarketplaceService
    {
        Product GetProduct(int productId);
        List<Product> GetProductList();
        List<Product> GetTextbooks();
        List<Product> GetUsersProducts(string userId);
        int UpdateProduct(Product pvm);
        UserInformation GetUserInformation(string userId);
        string UpdateUserInformation(UserInformation uvm);
    }
}