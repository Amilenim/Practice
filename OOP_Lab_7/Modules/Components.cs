using Shop.Enums;

namespace Shop.Modules
{
    internal class Components
    {
        private List<int> vegetables = new List<int>() { 10, 20, 5, 15 };
        private List<int> fruit = new List<int>() { 25, 70, 50, 40 };

        public void Models()
        {
            Console.WriteLine("Рiзновид продуктiв:");
            Console.WriteLine("\nОвочi\n");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"{(Vegetables)i} {vegetables[i - 1]} grn");
            }

            Console.WriteLine("\nФрукти\n");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"{(Fruits)i} {fruit[i - 1]} grn");
            }
            Console.WriteLine("\n");
        }
    }
}
