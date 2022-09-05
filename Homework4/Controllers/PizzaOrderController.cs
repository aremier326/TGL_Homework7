using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaShop.Dal.Repos.Interfaces;
using PizzaShop.Dal.Repos;
using PizzaShop.Models;
using PizzaShop.Models.Entities;


namespace PizzaShop.MVC.Controllers
{
    public class PizzaOrderController : Controller
    {
        private IOrderRepo OrderRepo { get; }

        public PizzaOrderController(IOrderRepo repo)
        {
            OrderRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = OrderRepo.GetAll();
            return View(orders);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order placeOrderRequest)
        {

            var order = new Order()
            {
                CustomerNavigation = new Customer() {
                    CustomerName = placeOrderRequest.CustomerNavigation.CustomerName,
                    Address = placeOrderRequest.CustomerNavigation.Address,
                    Phone = placeOrderRequest.CustomerNavigation.Phone,
                    Email = placeOrderRequest.CustomerNavigation.Email,
                },

                PizzaNavigation = new Pizza()
                {
                    PizzaType = placeOrderRequest.PizzaNavigation.PizzaType,
                    PizzaCrust = placeOrderRequest.PizzaNavigation.PizzaCrust,
                    PizzaSize = placeOrderRequest.PizzaNavigation.PizzaSize,
                },

                AdditionalOrderInfo = placeOrderRequest.AdditionalOrderInfo
            };

            ModelState.Remove("PizzaNavigation.OrderNavigation");

            if (ModelState.IsValid)
            {
                await OrderRepo.AddAsync(order);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var order = await OrderRepo.FindAsync(id);

            if (order == null) return RedirectToAction("Index");

            return await Task.Run(() => View("View", order));
        }

        [HttpPost]
        public async Task<ActionResult> View(Order editedOrder)
        {
            if (ModelState.IsValid)
            {
                await OrderRepo.UpdateAsync(editedOrder);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Order editedOrder)
        {
            var order = await OrderRepo.FindAsync(editedOrder.Id);

            if (order != null)
            {
                await OrderRepo.DeleteAsync(order);
            }
            return RedirectToAction("Index");
        }
    }
}
