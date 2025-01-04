using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto?> ConvertToProductDto(this IEnumerable<Product>? products)
        {
            return (from product in products
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        CategoryId = product.ProductCategory.Id,
                        CategoryName = product.ProductCategory.Name,
                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        Qty = product.Qty
                    }).ToList();
        }

        public static ProductDto? ConvertToProductDto(this Product? product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.ProductCategory.Id,
                CategoryName = product.ProductCategory.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Qty = product.Qty
            };
        }

        public static IEnumerable<CartItemDto>? ConvertToCartItemDto(this IEnumerable<CartItem>? cartItems,
            IEnumerable<Product>? products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductPrice = product.Price,
                        ProductImageUrl = product.ImageUrl,
                        Qty = cartItem.Qty,
                        CartId = cartItem.CartId,
                        TotalPrice = product.Price * cartItem.Qty
                    }).ToList();
        }

        public static CartItemDto? ConvertToCartItemDto(this CartItem? cartItem,
            Product? product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductPrice = product.Price,
                ProductImageUrl = product.ImageUrl,
                Qty = cartItem.Qty,
                CartId = cartItem.CartId,
                TotalPrice = product.Price * cartItem.Qty
            };
        }

        public static IEnumerable<ProductCategoryDto>? ConvertToProductCategoryDto(this IEnumerable<ProductCategory>? categories)
        {
            return (from category in categories
                    select new ProductCategoryDto
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Icon = category.Icon
                    }).ToList();
        }
    }
}
