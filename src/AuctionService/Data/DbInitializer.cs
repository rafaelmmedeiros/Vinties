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
               new Auction
               {
                    Id = Guid.NewGuid(),
                    Seller = "Mark",
                    ReservePrice = 2000,
                    Status = AuctionStatus.Live,
                    AuctionEnd = DateTime.UtcNow.AddDays(7),
                    Item = new AuctionItem
                    {
                         Id = Guid.NewGuid(),
                         Model = "Stratocaster",
                         Manufacturer = "Fender",
                         Description = "A classic guitar",
                         Type = AuctionItemType.Guitar,
                         SerialNumber = "123456",
                         Year = 1985,
                         Color = "Red",
                         ImageUrl = "https://1.bp.blogspot.com/-305fBVmguqg/YGYOPgjJHHI/AAAAAAAAM7s/XFGr5UW2Q5cnXtfmV1m01tDjKYNPnFXZQCLcBGAsYHQ/s1600/Fender%2BStratocaster%2BCandy%2BApple%2BRed%2Bmatching%2Bheadstock.jpg"
                    }
               },
               new Auction
               {
                    Id = Guid.NewGuid(),
                    Seller = "John",
                    ReservePrice = 1000,
                    Status = AuctionStatus.Live,
                    AuctionEnd = DateTime.UtcNow.AddDays(10),
                    Item = new AuctionItem
                    {
                         Id = Guid.NewGuid(),
                         Model = "Les Paul",
                         Manufacturer = "Gibson",
                         Description = "A classic guitar",
                         Type = AuctionItemType.Guitar,
                         SerialNumber = "123456",
                         Year = 1985,
                         Color = "Red",
                         ImageUrl = "https://www.gibson.com/GibsonTV/Epiphone/Epiphone%20Les%20Paul%20Standard%2050s%20-%20Vintage%20Sunburst/Epiphone%20Les%20Paul%20Standard%2050s%20-%20Vintage%20Sunburst%20-%20Front%20Full.jpg"
                    }
               }
          };
          
          context.Auctions.AddRange(auctions);
          context.SaveChanges();
     }
}