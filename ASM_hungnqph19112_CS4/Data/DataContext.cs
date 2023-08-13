using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ASM_hungnqph19112_CS4.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-TJU16KH0;Initial Catalog=asm_net104;Integrated Security=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            });
            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Image>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId);
            });
            modelBuilder.Entity<Role>(e =>
            {
                e.HasKey(e => e.Id);
            });
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            });

            modelBuilder.Entity<Category>().HasData(
              new Category
              {
                  Id = 1,
                  Title = "Orange"
              },
               new Category
               {
                   Id = 2,
                   Title = "Fresh Meat"
               },
                new Category
                {
                    Id = 3,
                    Title = "Vegetables"
                },
                 new Category
                 {
                     Id = 4,
                     Title = "Fastfood"
                 }
              );
            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 Id = 1,
                 Title = "Măng tây Lâm Đồng 200g",
                 Description = "Măng tây được nuôi trồng tại Lâm Đồng và đóng gói theo những tiêu chuẩn nghiêm ngặt, bảo đảm các tiêu chuẩn xanh - sạch, chất lượng và an toàn với người dùng. Măng giòn, ngọt, hàm lượng dinh dưỡng cao nên thường được chế biên bằng hấp, luộc hoặc nướng để có thể giữ được độ tươi ngon.",
                 Infomation = "Giá trị dinh dưỡng của măng tây\r\nMăng tây là thực phẩm quý giá có chứa hàm lượng dinh dưỡng cao như: chất xơ, đạm, glucid, các vitamin K, C, A, pyridoxine (B6), riboflavin (B2), acid folic, canxi, sắt, kẽm…\r\nTrong 100g măng tây có 20.3 Kcal." +
                 "\nTác dụng của măng tây đối với sức khỏe\r\nLàm đẹp da và ngăn ngừa lão hóa\r\nNgăn ngừa bệnh loãng xương\r\nNgăn ngừa bệnh ung thư\r\nTăng cường hệ miễn dịch" +
                 "\nCác món ăn ngon từ măng tây\r\nMăng tây thì bạn có thể chế biến thành nhiều món ăn khác nhau như: măng tây xào thịt bò, măng tây xào nấm, súp cá hồi phô mai măng tây, súp tôm măng tây,...\r\nCách bảo quản măng tây tươi ngon\r\nMăng tây nên được bảo quản trong ngăn mát tủ lạnh để giúp măng tây tươi ngon, giòn ngọt.",
                 ImageUrl = "featured/mang-tay.jpg",
                 Price = 27550,
                 CategoryId = 3
             },
              new Product
              {
                  Id = 2,
                  Title = "Crab Pool Security",
                  Description = "None",
                  ImageUrl = "featured/feature-2.jpg",
                  Price = 30000,
                  CategoryId = 2
              },
               new Product
               {
                   Id = 3,
                   Title = "Crab Pool Security",
                   Description = "None",
                   ImageUrl = "featured/feature-3.jpg",
                   Price = 30000,
                   CategoryId = 3
               },
                new Product
                {
                    Id = 4,
                    Title = "Crab Pool Security",
                    Description = "None",
                    ImageUrl = "featured/feature-4.jpg",
                    Price = 30000,
                    CategoryId = 4
                },
                 new Product
                 {
                     Id = 5,
                     Title = "Crab Pool Security",
                     Description = "None",
                     ImageUrl = "featured/feature-5.jpg",
                     Price = 30000,
                     CategoryId = 1
                 },
                  new Product
                  {
                      Id = 6,
                      Title = "Crab Pool Security",
                      Description = "None",
                      ImageUrl = "featured/feature-6.jpg",
                      Price = 30000,
                      CategoryId = 2
                  },
                   new Product
                   {
                       Id = 7,
                       Title = "Crab Pool Security",
                       Description = "None",
                       ImageUrl = "featured/feature-7.jpg",
                       Price = 30000,
                       CategoryId = 3
                   },
                    new Product
                    {
                        Id = 8,
                        Title = "Crab Pool Security",
                        Description = "None",
                        ImageUrl = "featured/feature-8.jpg",
                        Price = 30000,
                        CategoryId = 4
                    },
                      new Product
                      {
                          Id = 9,
                          Title = "Crab Pool Security",
                          Description = "None",
                          ImageUrl = "featured/feature-5.jpg",
                          Price = 30000,
                          CategoryId = 1
                      }
             );
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = 1,
                    ImageUrl = "details/mang-tay-1.jpg",
                    ProductId = 1
                },
                 new Image
                 {
                     Id = 2,
                     ImageUrl = "details/mang-tay-2.jpg",
                     ProductId = 1
                 },
                  new Image
                  {
                      Id = 3,
                      ImageUrl = "details/mang-tay-3.jpg",
                      ProductId = 1
                  },
                   new Image
                   {
                       Id = 4,
                       ImageUrl = "details/mang-tay-4.jpg",
                       ProductId = 1
                   }
                );
            modelBuilder.Entity<Role>().HasData(
             new Role
             {
                 Id = 1,
                 RoleName = "Admin"
             },
              new Role
              {
                  Id = 2,
                  RoleName = "Customer"
              }
            );
            modelBuilder.Entity<User>().HasData(
           new User
           {
               Id = 1,
               Account = "admin1234",
               Password = "123456",
               RoleId = 1
           },
            new User
            {
                Id = 2,
                Account = "user1234",
                Password = "123456",
                RoleId = 2
            }
          );
        }
    }
}
