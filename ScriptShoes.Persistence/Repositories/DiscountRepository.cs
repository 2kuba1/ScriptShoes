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

        foreach (var shoe in discount.ShoesIds.Select(shoesIds => _context.Shoes.FirstOrDefault(x => x.Id == shoesIds)))
        {
            if (shoe is null) continue;
            var price = shoe.CurrentPrice;
            shoe.PriceBeforeDiscount = price;
            if (dto.DiscountPercentage is not null)
            {
                shoe.CurrentPrice = (float)(price - (price * dto.DiscountPercentage / 100f))!;
                _context.Shoes.Update(shoe);
                await _context.SaveChangesAsync();
            }

            if (dto.MoneyDiscount is null) continue;
            var newPrice = price - dto.MoneyDiscount;
            if (newPrice <= 0)
                continue;

            shoe.CurrentPrice = (float)newPrice!;
            _context.Shoes.Update(shoe);
            await _context.SaveChangesAsync();
        }
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

        _context.Discounts.Remove(discount);
        await _context.SaveChangesAsync();
    }

    public async Task<Discount?> GetDiscountByShoeId(int shoeId)
    {
        var discount = await _context.Discounts.FirstOrDefaultAsync(x => x.ShoesIds.Contains(shoeId));
        return discount;
    }

    public async Task RemoveShoeFromDiscount(Discount discount, Shoe shoe)
    {
        shoe.CurrentPrice = (float)shoe.PriceBeforeDiscount!;
        shoe.PriceBeforeDiscount = null;

        _context.Shoes.Update(shoe);

        if (discount.ShoesIds.Count > 1)
        {
            discount.ShoesIds.Remove(shoe.Id);
            _context.Discounts.Update(discount);
            await _context.SaveChangesAsync();
            return;
        }

        _context.Discounts.Remove(discount);
        await _context.SaveChangesAsync();
    }
}