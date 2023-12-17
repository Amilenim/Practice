using Shop.Enums;

namespace Shop.Logic
{
    public class ShopEqual
    {
        public static bool Equal(string product, ref int productIndex, ref int productType)
        {
            for (int i = 1; i <= 4; i++)
            {
                string inputProduct = Convert.ToString((Vegetables)i);

                if (inputProduct == product)
                {
                    productIndex = i;
                    productType = 1; 
                    return true;
                }
            }
            for (int i = 1; i <= 4; i++)
            {
                string inputProduct = Convert.ToString((Fruits)i);

                if (inputProduct == product)
                {
                    productIndex = i;
                    productType = 2; 
                    return true;
                }
            }
            return false;
        }
    }
}
