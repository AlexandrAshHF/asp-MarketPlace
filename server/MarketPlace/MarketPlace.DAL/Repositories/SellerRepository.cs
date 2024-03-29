﻿using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.DAL.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private ApplicationContext _context;
        public SellerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<SellerModel?> GetSellerByIdAsync(Guid id)
        {
            var entity = await _context.Sellers.Include(x => x.User)
                                               .FirstOrDefaultAsync();

            if (entity == null || entity.Products.IsNullOrEmpty())
                return null;

            var user = UserModel.CreateUser(entity.User.Id, entity.User.Username,
                entity.User.Email, entity.User.EmailConfirm,
                entity.User.PasswordHash, entity.User.Role, entity.Id.ToString()).Item1;

            var model = SellerModel.CreateSeller(id, entity.PhoneNumber, user).Item1;

            return model;
        }

        public async Task<SellerModel> GetSellerByProductId(Guid productId)
        {
            var entity = await _context.Sellers.AsNoTracking()
                .Where(x => x.Products.Contains(new ProductEntity { Id = productId }))
                .Include(x => x.User).FirstOrDefaultAsync();

            var model = SellerModel.CreateSeller(entity.Id, entity.PhoneNumber, 
                UserModel.CreateUser(entity.UserId, entity.User.Username, entity.User.Email, entity.User.EmailConfirm, "", "", "").Item1);

            return model.Item1;
        }
        public async Task<Guid> AddSellerAsync(SellerModel seller)
        {
            var entity = new SellerEntity
            {
                Id = seller.Id,
                PhoneNumber = seller.PhoneNumber,
                Products = new List<ProductEntity>(),
                UserId = seller.User.Id
            };

            await _context.Sellers.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<Guid> RemoveSellerAsync(Guid sellerId)
        {
            _context.Sellers.Remove(new SellerEntity { Id = sellerId });
            await _context.SaveChangesAsync();

            return sellerId;
        }
    }
}