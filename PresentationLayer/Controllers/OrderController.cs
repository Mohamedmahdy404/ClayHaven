using System.Threading.Tasks;
using BusinessLayer.Contract;
using BusinessLayer.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Actions_Request.Order;
using PresentationLayer.Mapping;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Customer, Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;
        private readonly BusinessLayer.Service.Payment.PaymentManager _paymentManager;

        public OrderController(IOrderManager orderManager, IProductManager productManager, BusinessLayer.Service.Payment.PaymentManager paymentManager)
        {
            _orderManager = orderManager;
            _productManager = productManager;
            _paymentManager = paymentManager;
        }

        public async Task<IActionResult>  Index()
        {
            ViewData["ShowSignOut"] = true;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["ShowSignOut"] = true;

            var x = await _productManager.GetAllProduct();
           var y = x.Select(o => o.ToProductVm()).ToList();
           ViewBag.GetProductVM = y;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderAction orderAction)
        {
            ViewData["ShowSignOut"] = true;
            var paymentResult = await _paymentManager.ProcessPayment(orderAction.PaymentToken);

            if (!paymentResult.Success) // If payment fails
            {
                ViewBag.ErrorMessage = "Payment failed. Please try again.";
                return View("Error"); // Return an error view or the same page with the error message
            }

            await _orderManager.CreateOrder(orderAction.CreateOrderActionToCreateOrderDto());
            //  return View();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Display()
        {
            ViewData["ShowSignOut"] = true;
            var orders = await  _orderManager
                .GetAllOrder();

            var orderListVm = orders
                .Select(p => p.GetOrderDtoToGetOrderVM())
                .ToList();

            return View(orderListVm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
           await _orderManager.RemoveOrder(id);
            return RedirectToAction("Display");
        }

    }
}
