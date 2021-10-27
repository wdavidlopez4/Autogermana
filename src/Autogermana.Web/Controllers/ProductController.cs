using Autogermana.Application.ProductServices.CommandProductCreate;
using Autogermana.Application.ProductServices.CommandProductUpdateData;
using Autogermana.Application.ProductServices.QueryProductsByCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autogermana.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator meditor;

        public ProductController(IMediator meditor)
        {
            this.meditor = meditor;
        }

        public async Task<IActionResult> Index(string categoryId)
        {
            var query = new ProductsByCategoryQuery
            {
                CategoryId = categoryId
            };

            var dtos = await meditor.Send(query);

            ViewBag.categoriaId = categoryId;
            return View(dtos);
        }

        public IActionResult CrearProducto(string idCategoria)
        {
            TempData["IdCategoria"] = idCategoria;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearProducto([Bind("Nombre,Descripcion,Estado,Codigo,Stock,Precio")] 
            ProductCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                command.CategoryId = TempData["IdCategoria"].ToString();
                var dto = await this.meditor.Send(command);

                return RedirectToAction("Index", "Category");
            }
            else
            {
                return NotFound();
            }
            
        }

        public IActionResult ModificarProducto(string idCategoria, string idProducto)
        {
            TempData["IdCategoria"] = idCategoria;
            TempData["idProducto"] = idProducto;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModificarProducto([Bind("Nombre,Descripcion,Estado,Codigo,Stock,Precio")]
            ProductUpdateDataCommand command)
        {
            if (ModelState.IsValid)
            {
                command.CategoryId = TempData["IdCategoria"].ToString();
                command.Id = TempData["idProducto"].ToString();
                var dto = await this.meditor.Send(command);

                return RedirectToAction("Index", "Category");
            }
            else
            {
                return NotFound();
            }

        }
    }
}
