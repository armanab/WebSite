using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Package.Core.Domain.Content;
using Package.Core.DTO.Products;
using Package.Service.Content;
using Package.UI.Extensions;
using System;
using System.Linq;

namespace Package.UI.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    [Authorize(Roles = "Administrator")]
    public class ApplicationController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public ApplicationController(IProductService _productService, IMapper _mapper)
        {
            mapper = _mapper;
            productService = _productService;
        }


        [Route("AboutUs")]
        public IActionResult AboutUs()
        {
            try
            {
                var Model = productService.GetPagedListViewModel(x => true, null, include: source => source.Include(pic => pic.Pictures));


                return View(Model);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            try
            {
                var Model = productService.GetPagedListViewModel(x => true, null, include: source => source.Include(pic => pic.Pictures));


                return View(Model);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IActionResult Edit(int id)
        {
            try
            {

                ProductViewModel Model = productService.GetViewModelById(id);

                return View(Model);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public IActionResult Edit(IFormCollection collection, ProductViewModel Model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Product entity = mapper.Map<Product>(Model);
                    productService.Update(entity);
                }
                else
                {
                    return View(Model);
                }


                return Redirect("/Admin/Products/List");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}