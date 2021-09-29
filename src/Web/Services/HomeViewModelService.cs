﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Brand> _brandRepository;

        public HomeViewModelService(IAsyncRepository<Product> productRepository, IAsyncRepository<Category> categoryRepository, IAsyncRepository<Brand> brandRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }
        public async Task<HomeViewModel> GetHomeViewModelAsync(int? categoryId, int? brandId, int page)
        {
            var specProducts = new ProductsFilterSpecification(categoryId, brandId);
            var totalItemsCount = await _productRepository.CountAsync(specProducts);
            var totalPagesCount = (int)Math.Ceiling((decimal)totalItemsCount / Constants.ITEMS_PER_PAGE);

            var specPaginatedProducts = new ProductsFilterPaginatedSpecifications(categoryId, brandId,
                (page - 1) * Constants.ITEMS_PER_PAGE, Constants.ITEMS_PER_PAGE);
            var products = await _productRepository.ListAsync(specPaginatedProducts);

            var vm = new HomeViewModel()
            {
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    PictureUri = p.PictureUri,
                    Price = p.Price
                }).ToList(),
                Categories = await GetCategoriesAsync(),
                Brands = await GetBrandsAsync(),
                CategoryId = categoryId,
                BrandId = brandId,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    Page = page,
                    TotalItems = totalItemsCount,
                    TotalPages = totalPagesCount,
                    ItemsOnPage = products.Count,
                    HasPrevious = page > 1,
                    HasNext = page < totalPagesCount
                }
            };
            return vm;
        }


        private async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
        {
            var brands = await _brandRepository.ListAllAsync();
            return brands.Select(c => new SelectListItem(c.BrandName, c.Id.ToString()));
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.ListAllAsync();
            return categories.Select(c => new SelectListItem(c.CategoryName, c.Id.ToString()));
        }
    }
}
