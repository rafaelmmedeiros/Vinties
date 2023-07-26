using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInitializer
{
     public static void InitDb(WebApplication app)
     {
          using var scope = app.Services.CreateScope();
          SeedData(scope.ServiceProvider.GetRequiredService<AuctionDbContext>());
     }

     private static void SeedData(AuctionDbContext context)
     {
          context.Database.Migrate();
          if (context.Auctions.Any()) return;

          var auctions = new List<Auction>
          {
               new Auction("Mark", 2000, DateTime.UtcNow.AddDays(7))
               {
                    Id = Guid.NewGuid(),
                    Item = new AuctionItem(
                         "Stratocaster", "Fender", "A classic guitar", 
                         AuctionItemType.Guitar, "123456", 1985, "Red", 
                         "https://1.bp.blogspot.com/-305fBVmguqg/YGYOPgjJHHI/AAAAAAAAM7s/XFGr5UW2Q5cnXtfmV1m01tDjKYNPnFXZQCLcBGAsYHQ/s1600/Fender%2BStratocaster%2BCandy%2BApple%2BRed%2Bmatching%2Bheadstock.jpg")
                    { Id = Guid.NewGuid(), }
               },
               new Auction("John", 1000, DateTime.UtcNow.AddDays(30))
               {
                    Id = Guid.NewGuid(),
                    Item = new AuctionItem("Les Paul", "Gibson", "A classic guitar", 
                         AuctionItemType.Guitar, "123456", 1985, "Red", 
                         "https://cdn.awsli.com.br/2500x2500/1005/1005709/produto/151107154/img_1043-lgrhxr.jpg")
                    { Id = Guid.NewGuid(), }
               }
          };
          
          context.Auctions.AddRange(auctions);
          context.SaveChanges();
     }
}