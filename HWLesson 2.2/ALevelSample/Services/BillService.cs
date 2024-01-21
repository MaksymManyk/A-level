using System;
using Models;
using Repositories;

namespace Services
{
    public class BillService
    {
        private readonly BillRepository _billRepository;
        private readonly UserService _userService;

        public BillService(UserService userService, BillRepository billRepository)
        {
            _userService = userService;
            _billRepository = billRepository;
        }

        public string AddBill(User user, Basket basket)
        {
            var idBill = _billRepository.AddBill(CalculateBill(basket), user);
            return idBill;
        }

        public Bill GetBill(string id)
        {
            var bill = _billRepository.GetBill(id);

            if (bill == null)
            {
               return null;
            }

            return new Bill()
            {
                Id = bill.Id,
                Number = bill.Number,
                Cost = bill.Cost,
                User = _userService.GetUser(bill.UserID),
                Date = bill.Date
            };
        }

        private int CalculateBill(Basket basket)
        {
            int cost = 0;
            foreach (var item in basket.Toys)
            {
                cost += item.Quantity * item.Toy.Price;
            }

            return cost;
        }
    }
}
