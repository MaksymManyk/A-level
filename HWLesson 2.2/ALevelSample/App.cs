using System;
using Services;
using Repositories;
using Models;

namespace Entities;

public class App
{
    private readonly UserService _userService;
    private readonly ToyService _toyService;
    private readonly BillService _billService;
    public App(UserService userService, ToyService toyService)
    {
        _userService = userService;
        _toyService = toyService;
        _billService = new BillService(userService, new BillRepository());
    }

    public void Start()
    {
        User customer = CreateUser();
        int[] toysId = GenerateToys();
        string userMessage = $"{Environment.NewLine}Welcome to store,{customer.FirstName} {customer.LastName} " +
            $"\n {Environment.NewLine}Catalog of toys: " +
            $"\n{"ID",-5}  {"Type",-15}   {"Color",-15}   {"Price",-15}";
        PrintCatalog(userMessage, toysId);

        string isCreateOrder = Questions($"{Environment.NewLine}Do you want to create order ?: Y/N");
        if (isCreateOrder.ToUpper() == "Y")
        {
            BasketService basketService = GenerateBasket(customer, toysId);
            Basket basket = basketService.GetBasket();
            PrintOrder(basket);

            string isCreateBill = Questions($"{Environment.NewLine}Do you want to create Bill?: Y/N");
            if (isCreateBill.ToUpper() == "Y")
            {
                var billId = _billService.AddBill(customer, basket);
                Bill bill = _billService.GetBill(billId);
                Console.WriteLine($"{Environment.NewLine}Dear {bill.User.FullName}. Your bill number {bill.Number} is created {bill.Date}. Total cost = {bill.Cost}");
            }
            else
            {
                Console.WriteLine("The Bill didn`t create!");
            }
        }
        else
        {
            Console.WriteLine("The order didn`t create!");
        }
    }

    public User CreateUser()
    {
        Console.WriteLine("Dear customer. Enter your name, please.");
        var firstName = Console.ReadLine();
        Console.WriteLine("Dear customer. Enter your surname, please.");
        var lastName = Console.ReadLine();
        User user = _userService.GetUser(_userService.AddUser(firstName, lastName));
        return user;
    }

    public string Questions(string message)
    {
        Console.WriteLine(message);
        string answer = Console.ReadLine();
        return answer;
    }

    public void PrintOrder(Basket basket)
    {
        Console.WriteLine($"{Environment.NewLine}Your order:\n{"ID",-5}  {"Type",-15}   {"Color",-15}   {"Price",-15}   {"Quantity",-15}");
        for (int i = 0; i < basket.Toys.Length; i++)
        {
            ToyQuantity orderToy = basket.Toys[i];
            Console.WriteLine($"{orderToy.Toy.Id,-5}  {orderToy.Toy.Type,-15}   {orderToy.Toy.Color,-15}   {orderToy.Toy.Price,-15}  {orderToy.Quantity,-15}");
        }
    }

    public void PrintCatalog(string message, int[] toysId)
    {
        Console.WriteLine(message);
        for (int i = 0; i < toysId.Length; i++)
        {
            Toy toy = _toyService.GetToy(i);
            Console.WriteLine($"{toy.Id,-5}  {toy.Type,-15}   {toy.Color,-15}   {toy.Price,-15}");
        }
    }

    public int[] GenerateToys()
    {
        string[] colors = new string[] { "blue", "red", "yellow", "black", "Green", "pink" };
        string[] types = new string[] { "car", "animal", "airplane", "seaship", "spaceShip", "human" };
        int[] price = new int[] { 10, 15, 20, 30, 40, 50, 60, 70, 80 };
        int[] toys = new int[30];
        for (int i = 0; i < 30; i++)
        {
            toys[i] = _toyService.AddToy(i, types[new Random().Next(0, 6)], colors[new Random().Next(0, 6)], price[new Random().Next(0, 9)]);
        }

        return toys;
    }

    public BasketService GenerateBasket(User customer, int[] toysId)
    {
        ToyQuantity[] orderToys = new ToyQuantity[10];

        for (int i = 0; i < orderToys.Length; i++)
        {
            orderToys[i] = new ToyQuantity()
            {
                Toy = _toyService.GetToy(new Random().Next(0, toysId.Length)),
                Quantity = new Random().Next(1, 10)
            };
        }

        BasketService basket = new BasketService(customer, orderToys);
        return basket;
    }
}