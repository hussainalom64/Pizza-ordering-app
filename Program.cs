using System;
using System.ComponentModel.Design;

namespace PizzaApp
{

    //Pizza Ordering System 
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaring the variables I will be using in this system
            string firstName;
            string lastName;
            int houseNo;
            string postCode;
            string customerDet;
            int thinCrust = 5;
            int deepPan = 6;
            int numberOfPizzas = 0;
            double pizzaPrice;
            double toppingPrice = 0;
            int toppingOptions;
            string delivery;
            int deliveryCost = 0;
            double vat = 1.2;
            int totalNoOfPizzas = 0;

            //Getting the user input
            Console.WriteLine("Please enter your first name: ");
            firstName = Console.ReadLine();

            Console.WriteLine("Please enter your last name: ");
            lastName = Console.ReadLine();

            Console.WriteLine("Please enter your house number: ");
            houseNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter your post code: ");
            postCode = Console.ReadLine();

            customerDet = lastName + "_" + houseNo + "_" + postCode;
            Console.WriteLine("Your details are: " + customerDet);

            //Calculating the costs of the pizzas
            Console.WriteLine(customerDet + " Pizza types avaiable are Thin Crust and Deep Pan");
            Console.WriteLine("One Thin Crust costs £5.00 and one Deep Pan costs £6.00");
            Console.WriteLine("Please enter how many Thin crusts you would like: ");
            numberOfPizzas = Convert.ToInt32(Console.ReadLine());
            pizzaPrice = thinCrust * numberOfPizzas;
            totalNoOfPizzas = totalNoOfPizzas + numberOfPizzas;

            Console.WriteLine(customerDet + " Please enter how many Deep Pan pizzas you would like: ");
            numberOfPizzas = Convert.ToInt32(Console.ReadLine());
            pizzaPrice = deepPan * numberOfPizzas + pizzaPrice;
            totalNoOfPizzas = totalNoOfPizzas + numberOfPizzas;
           
            Console.WriteLine("Currently your cost is at: £" + pizzaPrice);

            //Using a method to figure out what topping they would like and how much it would cost them
            toppingOptions = PizzaToppings();

            switch (toppingOptions)
            {
                case 1:
                    toppingPrice = 3.00;
                    break;
                case 2:
                    toppingPrice = 2.00;
                    break;
                case 3:
                    toppingPrice = 3.00;
                    break;
                case 4:
                    toppingPrice = 1.50;
                    break;
                default:
                    Console.WriteLine("Please choose a correct input! 1,2,3,4");
                    break;
            }

            pizzaPrice = totalNoOfPizzas * toppingPrice + pizzaPrice;
            Console.WriteLine(customerDet + " Now your current cost is £" + pizzaPrice);

            //Delivery check
            Console.WriteLine("Would you like the pizzas to be delievered, please enter either y, or n.");
            delivery = Console.ReadLine();

            if(delivery == "y")
            {
                Console.WriteLine("Please choose how many miles away it would take for it to be delivered, we do not do over 8 miles");
                deliveryCost = Convert.ToInt32(Console.ReadLine());
                if(deliveryCost <= 2)
                {
                    Console.WriteLine("Free delivery.");
                    deliveryCost = 0;
                }
                else if(deliveryCost <= 5)
                {
                    Console.WriteLine("£3.00 delivery");
                    deliveryCost = 3;
                }
                else if(deliveryCost <= 8)
                {
                    Console.WriteLine("£5.00 delivery");
                    deliveryCost = 5;
                }
                else
                {
                    Console.WriteLine("We do not do deliveries over 8 miles!");
                }
            }
            else if(delivery == "n")
            {
                deliveryCost = 0;
            }
            else
            {
                Console.WriteLine("Please enter either y or n!");
            }

            //Total cost of everything
            pizzaPrice = deliveryCost + pizzaPrice;
            Console.WriteLine(customerDet + " Thank you for your purchase your total cost is £" + pizzaPrice * vat);
        }

        static int PizzaToppings()
        {
            int selection;
            Console.WriteLine("Pizza Toppings avaiable, please only choose one of them: ");
            Console.WriteLine("1. Ham, which costs £3.00");
            Console.WriteLine("2. Mushroom, which costs £2.00");
            Console.WriteLine("3. Mediterranian Veggies £3.00");
            Console.WriteLine("4. Extra Cheese, which costs £1.50");

            selection = Convert.ToInt32(Console.ReadLine());
            return selection;
        }
    }
}