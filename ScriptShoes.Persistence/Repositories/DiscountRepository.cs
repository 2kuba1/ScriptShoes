using Mapster;
using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Discount;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
{
    public DiscountRepository(AppDbContext context) : base(context)
    {
    }

    public async Task CreateDiscount(CreateDiscountDto dto)
    {
        var discount = dto.Adapt<Discount>();
        await _context.Discounts.AddAsync(discount);
        await _context.SaveChangesAsync();

        dto.ShoesIds.ForEach(id =>
        {
            Console.WriteLine(id);
            var shoe = _context.Shoes.FirstOrDefault(x => x.Id == id);
            if (shoe is null) return;
            var price = shoe.CurrentPrice;
            shoe.PriceBeforeDiscount = price;
            if (dto.DiscountPercentage is not null)
            {
                shoe.CurrentPrice = (float)(price - (price * dto.DiscountPercentage / 100f))!;
                _context.Shoes.Update(shoe);
                _context.SaveChanges();
            }

            if (dto.MoneyDiscount is null) return;
            var newPrice = price - dto.MoneyDiscount;
            if (newPrice <= 0)
                return;

            shoe.CurrentPrice = (float)newPrice!;
            _context.Shoes.Update(shoe);
            _context.SaveChanges();
        });
    }

    public async Task DeleteDiscount(Discount discount)
    {
        var shoes = new List<Shoe>();

        foreach (var shoeId in discount.ShoesIds)
        {
            var shoe = await _context.Shoes.FirstOrDefaultAsync(x => x.Id == shoeId);
            if (shoe is null)
                continue;
            shoes.Add(shoe);
        }

        foreach (var shoe in shoes)
        {
            shoe.CurrentPrice = (float)shoe.PriceBeforeDiscount!;
            shoe.PriceBeforeDiscount = null;
            _context.Shoes.Update(shoe);
            await _context.SaveChangesAsync();
        }
    }
}