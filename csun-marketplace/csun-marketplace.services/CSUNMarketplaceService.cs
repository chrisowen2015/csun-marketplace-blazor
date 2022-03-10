using csun_marketplace.dbo;
using csun_marketplace.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csun_marketplace.services
{
    public class CSUNMarketplaceService : ICSUNMarketplaceService
    {
        private readonly IDbContextFactory<CSUNMarketplaceContext> _context;

        public CSUNMarketplaceService(IDbContextFactory<CSUNMarketplaceContext> context)
        {
            _context = context;
        }
        
        public Product GetProduct(int productId)
        {
            var CSUNMarketplaceEvaluatorDB = _context.CreateDbContext();

            Product pvm = CSUNMarketplaceEvaluatorDB.Products.Where(p => p.ProductId == productId).Select(p => new Product
            {
                ProductId = p.ProductId,
                OwnerId = p.OwnerId,
                Title = p.Title,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                Price = p.Price,
                DateCreated = p.DateCreated,
                Available = p.Available,
                Category = p.Category,
                Tags = p.Tags,

            }).Single();

            // If we have any complex structures stored on the Product class like a list of Users or something, we will grab them below here
            

            return pvm;
        }

        /*
         * A function to get all products, can be easily rewritten to pull only available products by setting p.Available == true (or == 1)
         * Also note this function doesn't need to fill all fields, just the ones needed for how we display all products, then we can just call getProduct() for the rest
         */
        
        public List<Product> GetProductList()
        {
            var CSUNMarketplaceEvaluatorDB = _context.CreateDbContext();

            List<Product> productList = CSUNMarketplaceEvaluatorDB.Products.Select(p => new Product 
            { 
                ProductId = p.ProductId, 
                OwnerId = p.OwnerId,
                Title = p.Title,
                ImageUrl= p.ImageUrl,
                Description= p.Description,
                Price = p.Price,
                Available = p.Available,

            }).ToList();

            return productList;
        }

        public List<Product> GetUsersProducts(int userId)
        {
            var CSUNMarketplaceEvaluatorDB = _context.CreateDbContext();

            List<Product> productList = CSUNMarketplaceEvaluatorDB.Products.Where(p => p.OwnerId == userId).Select(p => new Product
            {
                ProductId = p.ProductId,
                OwnerId = p.OwnerId,
                Title = p.Title,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
                Price = p.Price,
                Available = p.Available,

            }).ToList();

            return productList;
        }

        public int UpdateProduct(Product pvm)
        {
            try
            {
                var CSUNMarketplaceEvaluatorDB = _context.CreateDbContext();

                if(pvm.ProductId == 0)
                {
                    Product p = new Product
                    {
                        ProductId = pvm.ProductId,
                        OwnerId = pvm.OwnerId,
                        Title = pvm.Title,
                        ImageUrl = pvm.ImageUrl,
                        Description = pvm.Description,
                        Price = pvm.Price,
                        DateCreated = pvm.DateCreated,
                        Available = pvm.Available,
                        Category = pvm.Category,
                        Tags = pvm.Tags
                    };
                    CSUNMarketplaceEvaluatorDB.Products.Add(p);
                    CSUNMarketplaceEvaluatorDB.SaveChanges();
                    return p.ProductId;
                } else
                {
                    Product p = CSUNMarketplaceEvaluatorDB.Products.Where(p => p.ProductId == pvm.ProductId).Single();

                    p.Title = pvm.Title;
                    p.ImageUrl = pvm.ImageUrl;
                    p.Description = pvm.Description;
                    p.Price = pvm.Price;
                    p.Available = pvm.Available;
                    p.Category = pvm.Category;
                    p.Tags = pvm.Tags;

                    CSUNMarketplaceEvaluatorDB.SaveChanges();
                    return p.ProductId;
                }
            } catch (Exception ex)
            {
                return -1;
            }
        }

        public UserInformation GetUserInformation(int userId)
        {
            var CSUNMarketplaceEvaluatorDB = _context.CreateDbContext();

            UserInformation user = CSUNMarketplaceEvaluatorDB.UserInformations.Where(u => u.UserId == userId).Select(u => new UserInformation
            {
                UserId = u.UserId,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Bio = u.Bio,
                JoinDate = u.JoinDate,
                Rating = u.Rating,
                Major = u.Major,
                Gender = u.Gender
            }).Single();

            // If we have any complex structures stored on the UserInformation class like a list of Products or something, we will grab them below here

            return user;
        }

        public int UpdateUserInformation(UserInformation uvm)
        {
            try
            {
                var CSUNMarketplaceEvaluatorDB = _context.CreateDbContext();

                if(uvm.UserId == 0)
                {
                    UserInformation user = new UserInformation
                    {
                        UserId = uvm.UserId,
                        Email=uvm.Email,
                        FirstName=uvm.FirstName,
                        LastName=uvm.LastName,
                        Bio=uvm.Bio,
                        JoinDate=uvm.JoinDate,
                        Rating=uvm.Rating,
                        Major=uvm.Major,
                        Gender=uvm.Gender
                    };

                    CSUNMarketplaceEvaluatorDB.UserInformations.Add(user);
                    CSUNMarketplaceEvaluatorDB.SaveChanges();
                    return user.UserId;

                } else
                {
                    UserInformation user = CSUNMarketplaceEvaluatorDB.UserInformations.Where(p => p.UserId == uvm.UserId).Single();

                    user.FirstName = uvm.FirstName;
                    user.LastName = uvm.LastName;
                    user.Bio = uvm.Bio;
                    user.JoinDate = uvm.JoinDate;
                    user.Rating = uvm.Rating;
                    user.Major = uvm.Major;
                    user.Gender = uvm.Gender;

                    CSUNMarketplaceEvaluatorDB.SaveChanges();
                    return user.UserId;
                }
            } catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
