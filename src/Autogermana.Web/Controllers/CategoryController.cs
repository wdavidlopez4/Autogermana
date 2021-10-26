using Autogermana.Application.CategoryServices.CommandCategoryCreate;
using Autogermana.Application.CategoryServices.QueryAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autogermana.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// index
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<AllCategoriesDTO> dtos = await mediator.Send(new AllCategoriesQuery());

            return View(dtos);
        }

        /// <summary>
        /// GET - creamos la categoria
        /// </summary>
        /// <returns></returns>
        public IActionResult CrearCategoria()
        {
            return View();
        }

        /// <summary>
        /// POST - resive los datos de la creacion de la categoria
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CrearCategoria([Bind("Nombre,Descripcion,Estado")] CategoryCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                var dto = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
                
        }
    }
}
