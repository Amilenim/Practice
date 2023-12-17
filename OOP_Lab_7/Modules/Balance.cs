namespace Shop.Modules
{
    public class ShopBalance
    {
        public int BalanceAdd(int cash)
        {
            try
            {
                int balance = 0;

                Console.WriteLine($"\nНа балансi: {cash} грн");
                Console.WriteLine("Додайте бажану сумму");
                balance += Convert.ToInt32(Console.ReadLine());
                if (balance > 0 && balance <= 1000)
                    Console.WriteLine($"\nНа балансi: {cash + balance} грн");
                else throw new Exception("\nВведiть число бiльше за 0 грн, та не бiльше за 1000 грн");
                return balance;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nВведiть тiльки цифри!");
            }
            return 0;
        }
        public int BalanceAdd(int cash, int random)
        {
            int balance = 0;

            balance += random;
            Console.WriteLine($"\nВiтаэмо! Ваш виграш складає {random} грн!");
            Console.WriteLine($"На балансi: {cash + balance} грн");
            return balance;
        }
    }
}
