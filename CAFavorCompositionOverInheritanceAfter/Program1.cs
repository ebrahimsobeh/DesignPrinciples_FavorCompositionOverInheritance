using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFavorCompositionOverInheritanceAfter
{
     class Program1
    {
        static void Main(string[] args)
        {
            int choice = 0;
            var pizza = new Pizza();
            do
            {
                Console.Clear();
                choice = ReadChoise(choice);
                if(choice>=1 && choice <= 2)
                {
                    ITopping topping = null;
                    switch (choice)
                    {
                        case 1:
                            topping = new Cheese();
                            break;
                        case 2:
                            topping = new Checkin();
                            break;
                        default:
                            break;

                    }
                    pizza.addTopping(topping);
                    Console.WriteLine("Press any key to continue");
                }
                Console.ReadKey();
            } while (choice != 0);
            // will call override tostring()
            Console.WriteLine(pizza);
            Console.ReadKey();
        }
        private static int ReadChoise(int choice)
        {
            Console.WriteLine("Available Topping");
            Console.WriteLine("------------");
            Console.WriteLine("1. Cheese");
            Console.WriteLine("2. Chicken");
            Console.WriteLine("select topping: ");
            if (int.TryParse(Console.ReadLine(), out int ch))
            {
                choice = ch;
            }

            return choice;


        }


    }
    public class Pizza
    {
        public virtual decimal Price => 10;

        public List<ITopping> Toppings { get; set; } = new List<ITopping>();

        public void addTopping(ITopping topping) => Toppings.Add(topping);

        private decimal calculate()
        {
            decimal result = Price;
            foreach (ITopping toping in Toppings)
            {
                result+=toping.Price;

            }

            return result;
        }
        public override string ToString()
        {
            var output = $"{nameof(Pizza)}";
            output += $"\n\t Base Price\t ({Price})";
            foreach(ITopping toping in Toppings)
            {
                output += $"\n\t{toping.Title}\t({toping.Price})\n----------------------";
            }
            output += $"\nTotal\t({calculate()})";
            return output;
        }
    }
    public interface ITopping
    {
        public string Title { get; }
        public decimal Price { get; }

    }

    public class Cheese : ITopping
    {
        public string Title => nameof(Cheese);

        public decimal Price => 3;
    }
    public class Checkin : ITopping
    {
        public string Title => nameof(Checkin);

        public decimal Price => 5;
    }

}
