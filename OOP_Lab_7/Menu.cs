using Shop.Logic;
using Shop.Modules;

namespace Shop
{
    internal class Menu
    {
        static void Main(string[] args)
        {
            List<ShopLogic> list = new();
            ShopLogic logic = new();
            ShopBalance balance = new();
            Components components = new();
            Random rand = new();

            int input;
            int coupon;
            string output = string.Empty;

            while (true)
            {
                try
                {
                    Console.WriteLine("\nВиберiть:");
                    Console.WriteLine("1 - Поповнити баланс");
                    Console.WriteLine("2 - Вивести на екран обранi продукти");
                    Console.WriteLine("3 - Замiнити продукти");
                    Console.WriteLine("4 - Видалити продукт");
                    Console.WriteLine("5 - Демонстрацiя роботи");
                    Console.WriteLine("6 - Демонстрацiя роботи6 методiв static");
                    Console.WriteLine("7 - зберегти колекцiю об'єктiв у файлi");
                    Console.WriteLine("8 - зчитати колекцiю об'єктiв з файлу");
                    Console.WriteLine("9 - очистити колекцiю об'єктiв");
                    Console.WriteLine("0 - Вихiд");

                    input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case 0:
                            return;
                        case 1:
                            Console.WriteLine("\n1 - Поповнити баланс \n2 - Вiдкрити святковий купон на сумму вiд 100 до 300 grn \n0 - Вийти в головне меню");
                            input = Convert.ToInt32(Console.ReadLine());

                            if (input == 0)
                                break;
                            if (input == 1)
                            {
                                ShopLogic.Cash = balance.BalanceAdd(ShopLogic.Cash);
                                break;
                            }
                            if (input == 2)
                            {
                                coupon = rand.Next(100, 300);
                                input = balance.BalanceAdd(ShopLogic.Cash, coupon);
                                if (input >= 100 && input <= 300)
                                    ShopLogic.Cash = input;
                            }
                            break;
                        case 2:
                            Console.WriteLine($"{ShopLogic.ProductsBasket}");
                            break;
                        case 3:
                            Console.WriteLine("\nОберiть операцiю: \n1 - Змiнити замовлення \n0 - Вийти в головне меню");
                            input = Convert.ToInt32(Console.ReadLine());

                            if (input == 0)
                                break;
                            if (input == 1)
                            {
                                Console.WriteLine("\nВиберiть який продукт хочете замiнити:");
                                output = logic.ReplacementProductsBasket(ref output);
                                Console.WriteLine(output);
                                input = Convert.ToInt32(Console.ReadLine());
                                int id = input;

                                Console.WriteLine("\nВиберiть групу товарiв: \n1 - Овочi \n2 - Фрукти");
                                input = Convert.ToInt32(Console.ReadLine());
                                output = logic.TypeProducts(input);

                                Console.WriteLine($"\n{output}");
                                input = Convert.ToInt32(Console.ReadLine());
                                logic.ReplacementBuy(input, id);
                                Console.WriteLine("\nПродукт успiшно замiнено!");
                            }
                            break;
                        case 4:
                            Console.WriteLine("\nОберiть операцiю: \n1 - Видалити всi продукти \n0 - Вийти в головне меню");
                            input = Convert.ToInt32(Console.ReadLine());

                            if (input == 0)
                                break;
                            if (input == 1)
                            {
                                Console.WriteLine(logic.ClearBasket);
                                break;
                            }
                            else
                                Console.WriteLine("Такого варiанту нема!");
                            break;
                        case 5:
                            Console.WriteLine(logic.ClearBasket);
                            Console.WriteLine("\nВiтаємо у магазинi Walmart!");
                            Console.WriteLine("1 - Самостiйний вибор продуктiв \n2 - Автоматичний закуп \n0 - Вийти в головне меню");
                            input = Convert.ToInt32(Console.ReadLine());

                            if (input == 0)
                                break;
                            if (input == 1)
                            {
                                ShopLogic.Cash = balance.BalanceAdd(ShopLogic.Cash);

                                do
                                {
                                    Console.WriteLine("\nВиберiть групу товарiв: \n1 - Овочi \n2 - Фрукти");
                                    input = Convert.ToInt32(Console.ReadLine());

                                    output = logic.TypeProducts(input);
                                    Console.WriteLine($"\n{output}");

                                    input = Convert.ToInt32(Console.ReadLine());
                                    logic.Buy(input);

                                    Console.WriteLine("\nБажаєте придбати щось ще? \n1 - Так \n0 - Нi");
                                    input = Convert.ToInt32(Console.ReadLine());
                                } while (input == 1);
                                break;
                            }
                            if (input == 2)
                            {
                                ShopLogic.Cash = balance.BalanceAdd(ShopLogic.Cash);

                                do
                                {
                                    logic = new ShopLogic(ShopLogic.Cash, rand.Next(1, 2));

                                    Console.WriteLine($"{ShopLogic.ProductsBasket}");
                                    input = rand.Next(0, 1);

                                } while (input == 1);
                                break;
                            }
                            break;
                        case 6:
                            Console.WriteLine("\nВiтаємо у магазинi Walmart!");
                            components.Models();
                            Console.WriteLine($"На балансi: {ShopLogic.Cash} grn");
                            Console.WriteLine("Введiть данi за принципом: Баланс,Продукту");
                            logic = ShopLogic.Parse(Console.ReadLine());
                            Console.WriteLine("\n");
                            Console.WriteLine(ShopLogic.ProductsBasket);
                            Console.WriteLine("\n");
                            break;
                        case 7:
                            Console.WriteLine("Виберiть:\n1 - Зберегти у (*.Csv)\n2 - Зберегти у (*.Json)");
                            input = Convert.ToInt32(Console.ReadLine());
                            string? path;
                            switch (input)
                            {
                                case 1:
                                    list.Add(logic);
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("Введiть назву файла (*.csv):");
                                    path = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(path))
                                    {
                                        path += ".csv";
                                        Save.ToCsv(list, path);
                                    }
                                    Console.WriteLine("----------------------------------------");
                                    break;
                                case 2:
                                    list.Add(logic);
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("Введiть назву файла (*.json):");
                                    path = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(path))
                                    {
                                        path += ".json";
                                        Save.ToJson(list, path);
                                    }
                                    Console.WriteLine("----------------------------------------");
                                    break;
                                default: Console.WriteLine("Помилка! Немає такого значення!"); 
                                    break;
                            }
                            break;
                        case 8:
                            Console.WriteLine("Виберiть:\n1 - Вiдкрити (*.Csv)\n2 - Вiдкрити (*.Json)");
                            input = Convert.ToInt32(Console.ReadLine());
                            switch (input)
                            {
                                case 1:
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("Введiть назву файла (*.csv):");
                                    path = Console.ReadLine();
                                    Console.WriteLine("----------------------------------------");
                                    if (!string.IsNullOrEmpty(path))
                                    {
                                        path += ".csv";
                                        list = Open.FromCsv(path);
                                        Console.WriteLine("----------------------------------------");
                                        Console.WriteLine("Об'єкти класу:");
                                        Console.WriteLine(ShopLogic.ProductsBasket);
                                        Console.WriteLine("----------------------------------------");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("Введiть назву файла (*.json):");
                                    path = Console.ReadLine();
                                    Console.WriteLine("----------------------------------------");
                                    if (!string.IsNullOrEmpty(path))
                                    {
                                        path += ".json";
                                        list = Open.FromJson(path);
                                        Console.WriteLine("----------------------------------------");
                                        Console.WriteLine("Об'єкти класу:");
                                        Console.WriteLine(ShopLogic.ProductsBasket);
                                        Console.WriteLine("----------------------------------------");
                                    }
                                    break;        
                            }
                            break;
                        case 9:
                            list.Clear();
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Очищено");
                            Console.WriteLine("----------------------------------------");
                            break;
                        default:
                            Console.WriteLine("Введiть цифри тiльки вiд 0 до 9");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nВводiть тiльки цифри");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                }
            }
        }
    }
}
