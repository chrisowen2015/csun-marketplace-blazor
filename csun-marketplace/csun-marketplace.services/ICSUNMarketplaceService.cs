using csun_marketplace.data;


namespace csun_marketplace.services
{
    public interface ICSUNMarketplaceService
    {
        Product GetProduct(int productId);
        List<Product> GetProductList();
        List<Product> GetUsersProducts(int userId);
        int UpdateProduct(Product pvm);
        UserInformation GetUserInformation(int userId);
        int UpdateUserInformation(UserInformation uvm);

    }
}