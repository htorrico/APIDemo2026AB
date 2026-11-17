using APIDemo2026AB.DTO.Request;
using APIDemo2026AB.DTO.Response;
using APIDemo2026AB.Models;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo2026AB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesCustomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesCustomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert(CategoryRequestV1 request)
        {

            //Convertir el request a model
            Category model = new Category
            {
                Name = request.Name,
                isActive = true,
            };

            _context.Categories.Add(model);
            _context.SaveChanges();

        }


        [HttpPost]
        public void InsertAll(List<CategoryRequestV1> request)
        {

            List<Category> model = request.Select(x => new Category
            {
                Name = x.Name,
                isActive=true
            }).ToList();

            _context.AddRange(model);
            _context.SaveChanges();



            //foreach (var item in request)
            //{
            //    //Convertir el request a model
            //    Category model = new Category
            //    {
            //        Name = item.Descripcion,
            //        isActive = true,
            //    };

            //    _context.Categories.Add(model);
            //    _context.SaveChanges();
            //}


        }

        [HttpGet]
        public List<CategoryResponseV1> Get()
        {

            var categories = _context.Categories.Where(x => x.isActive == true).ToList();
            //Convertir lista de model a la lista de response

            List<CategoryResponseV1> response = categories.Select(x => new CategoryResponseV1
            {
                CategoryId = x.CategoryId,
                Name = x.Name
            }).ToList();

            return response;


        }


        [HttpGet]
        public List<CategoryResponseV1> GetByName(string name)
        {

            var categories = _context.Categories.
                Where(x => x.isActive == true && x.Name.Contains(name)).ToList();
            //Convertir lista de model a la lista de response

            List<CategoryResponseV1> response = categories.Select(x => new CategoryResponseV1
            {
                CategoryId = x.CategoryId,
                Name = x.Name
            }).ToList();

            return response;


        }

    }
}
