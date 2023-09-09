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
                    Seller = "bob",
                    ReservePrice = 2000,
                    Status = AuctionStatus.Live,
                    AuctionEnd = DateTime.UtcNow.AddDays(7),
                    Item = new AuctionItem
                    {
                         Id = Guid.NewGuid(),
                         Model = "Stratocaster",
                         Brand = "Fender",
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
                    Seller = "bob",
                    ReservePrice = 1000,
                    Status = AuctionStatus.Live,
                    AuctionEnd = DateTime.UtcNow.AddDays(10),
                    Item = new AuctionItem
                    {
                         Id = Guid.NewGuid(),
                         Model = "Les Paul",
                         Brand = "Gibson",
                         Description = "A classic guitar",
                         Type = AuctionItemType.Guitar,
                         SerialNumber = "123456",
                         Year = 1985,
                         Color = "Red",
                         ImageUrl = "https://cdn.ecommercedns.uk/files/6/248156/3/27615803/1960-gibson-les-paul-standard-0-0308-7.jpg"
                    }
               },
               new Auction
               {
                    Id = Guid.NewGuid(),
                    Seller = "alice",
                    ReservePrice = 2000,
                    Status = AuctionStatus.Live,
                    AuctionEnd = DateTime.UtcNow.AddDays(2),
                    Item = new AuctionItem
                    {
                         Id = Guid.NewGuid(),
                         Model = "Randy Rhoads RR24",
                         Brand = "Jackson",
                         Description = "A true metal guitar",
                         Type = AuctionItemType.Guitar,
                         SerialNumber = "123456",
                         Year = 2015,
                         Color = "White",
                         ImageUrl = "https://images.reverb.com/image/upload/s--FIS-3w67--/a_exif,c_limit,e_unsharp_mask:80,f_auto,fl_progressive,g_south,h_620,q_90,w_620/v1476902026/d7n25szi6pyjrtf5te4n.jpg"
                    }
               },
               new Auction
               {
                    Id = Guid.NewGuid(),
                    Seller = "alice",
                    ReservePrice = 2000,
                    Status = AuctionStatus.Live,
                    AuctionEnd = DateTime.UtcNow.AddDays(1),
                    Item = new AuctionItem
                    {
                         Id = Guid.NewGuid(),
                         Model = "Invader",
                         Brand = "Ran",
                         Description = "Guitarra do caralho",
                         Type = AuctionItemType.Guitar,
                         SerialNumber = "123456",
                         Year = 2020,
                         Color = "Black",
                         ImageUrl = "https://ranguitars.com/ran-models/invader/img/ran-guitars-14-074-invader.jpg"
                    }
               }
          };
          
          context.Auctions.AddRange(auctions);
          context.SaveChanges();
     }
}