using csun_marketplace.data;

namespace csun_marketplace.services
{
    public interface ICSUNMarketplaceService
    {
        Product GetProduct(int productId);
        List<Product> GetProductList();
        public List<SavedForLaterVM> GetSavedForLater(string userId);
        public int SaveForLater(SavedForLaterVM svm);
        public int RemoveSavedForLater(SavedForLaterVM svm);
        List<TextbookInformation> GetTextbookInformationList();
        List<Product> GetTextbooks();
        public List<Product> GetElectronics();
        public List<Product> GetSchoolSupplies();
        public List<Product> GetSportsAndFitness();
        public List<Product> GetFurniture();
        List<Product> GetUsersProducts(string userId);
        int UpdateProduct(Product pvm);
        int UpdateTextbookInformation(TextbookInformation tvm);
        UserInformation GetUserInformation(string userId);
        List<UserInformation> GetUserInformationList();
        string UpdateUserInformation(UserInformation uvm);
    }
}