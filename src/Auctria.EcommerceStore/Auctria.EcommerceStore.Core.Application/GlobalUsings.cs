﻿global using Auctria.EcommerceStore.Core.Application.Carts;
global using Auctria.EcommerceStore.Core.Application.CartItems;
global using Auctria.EcommerceStore.Core.Application.Carts.Commands;
global using Auctria.EcommerceStore.Core.Application.Carts.Query;
global using Auctria.EcommerceStore.Core.Application.CartItems.Commands;
global using Auctria.EcommerceStore.Core.Application.Common.Contracts;
global using Auctria.EcommerceStore.Core.Application.Common.Extensions;
global using Auctria.EcommerceStore.Core.Application.Common.Models;
global using Auctria.EcommerceStore.Core.Application.Common.Exceptions;
global using Auctria.EcommerceStore.Core.Application.Common.Persistence;
global using Auctria.EcommerceStore.Core.Application.Products;
global using Auctria.EcommerceStore.Core.Application.Products.Commands.CreateProduct;
global using Auctria.EcommerceStore.Core.Application.Products.Queries;
global using Auctria.EcommerceStore.Core.Domain.Entities;
global using Microsoft.EntityFrameworkCore;
global using InvalidOperationException = Auctria.EcommerceStore.Core.Application.Common.Exceptions.InvalidOperationException;