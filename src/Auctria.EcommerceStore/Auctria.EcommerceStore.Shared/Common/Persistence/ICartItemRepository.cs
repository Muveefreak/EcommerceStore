﻿namespace Auctria.EcommerceStore.Core.Application.Common.Persistence;
public interface ICartItemRepository : IRepository<CartItem>
{
    Task<CartItem> FindById(int cartItemId);
}