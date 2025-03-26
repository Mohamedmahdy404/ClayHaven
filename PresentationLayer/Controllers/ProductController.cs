using BusinessLayer.Contract;
using BusinessLayer.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Actions_Request;
using PresentationLayer.Actions_Request.Product;
using PresentationLayer.Mapping;

namespace PresentationLayer.Controllers
{
    [Authorize (Roles = "Admin, Buyer")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [Route("Product")]
        public async Task<IActionResult> Display()
        {
            ViewData["ShowSignOut"] = true;

            var x = await _productManager.GetAllProduct();
          var y = x.Select(P => P.ToProductVm()).ToList();
            return View(y);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["ShowSignOut"] = true;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductAction productAction)
        {
          await  _productManager.AddProduct(productAction.ToProductDto());

            //return View("Display");
            return RedirectToAction("Display");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _productManager.DeleteProduct(id);
            return RedirectToAction("Display");

        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewData["ShowSignOut"] = true;

            var x =  await _productManager.GetProductById(id);
            return View(x.DtoToUpdateProductAction());

        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductAction productAction)
        {
            await _productManager.UpdateProduct(productAction.UpdateToProductDto());
            return RedirectToAction("Display");
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
