using Shop.Enums;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Shop.Logic
{
    public class ShopLogic
    {
        Random rand = new Random();
        private int choice;
        private static int cash;
        private string text;
        private static List<string> element = new List<string>();
        private List<int> vegetables = new List<int>() { 10, 20, 5, 15 };
        private List<int> fruit = new List<int>() { 25, 70, 50, 40 };

        public ShopLogic()
        {
            cash = 0;
            text = string.Empty;
        }

        public ShopLogic(int balance, int id)
        {
            TypeProducts(id);
            choice = rand.Next(1, 4);
            Buy(choice);
        }

        public ShopLogic(int productIndex, int productType, int money)
        {
            Cash = money;
            Index = productIndex;
            Buy(productType);
        }
        public static int Index { get; set; } = 0;
        public static string VegetableElement { get => element[0]; }
        public static string FruitElement { get => element[1]; }

        [JsonInclude]
        public int Balance { get => cash;}
        public static int Cash
        {
            get =>cash;
            set
            {
                if (value > 0 && value <= 1000)
                {
                    cash += value;
                }
            }
        }
        [JsonInclude]
        public string ProductInp
        {
            get => element[0];
        }
        [JsonIgnore]
        public string ClearBasket
        {
            get 
            { 
                element.Clear(); 
                Index = 0; 
                return "\nВсi продукти видаленi!"; 
            }
        }
        public string TypeProducts(int input)
        {
            text = string.Empty;
            VegetablesOrFruit = input;
            return text;
        }
        int VegetablesOrFruit
        {
            set
            {
                switch (value)
                {
                    case 1:
                        Index = 1;
                        for (int i = 1; i < 5; i++) { text += ($"{i} - {(Vegetables)i} {vegetables[i - 1]} grn\n"); }
                        break;
                    case 2:
                        Index = 2;
                        for (int i = 1; i < 5; i++) { text += ($"{i} - {(Fruits)i} {fruit[i - 1]} grn\n"); }
                        break;
                }
            }
        }
        public void Buy(int input)
        {
            if (Index < 3)
            {
                if (cash - vegetables[input - 1] >= 0 || cash - fruit[input - 1] >= 0)
                {
                    switch (Index)
                    {
                        case 1:
                            element.Add($"{(Vegetables)input} - {vegetables[input - 1]} grn");
                            cash -= vegetables[input - 1];
                            break;
                        case 2:
                            element.Add($"{(Fruits)input} - {fruit[input - 1]} grn");
                            cash -= fruit[input - 1];
                            break;
                    }
                }
                else throw new Exception("Не вистачає грошей. Поповнiть баланс");
            }
            else throw new ArgumentOutOfRangeException("Неправильний index товару");
        }

        public void ReplacementBuy(int input, int id)
        {
            if (cash - vegetables[input - 1] >= 0 || cash - fruit[input - 1] >= 0)
            {
                switch (Index)
                {
                    case 1:
                        element[id - 1] = ($"{(Vegetables)input} - {vegetables[input - 1]} grn");
                        cash -= vegetables[input - 1];
                        break;
                    case 2:
                        element[id - 1] = ($"{(Fruits)input} - {fruit[input - 1]} grn");
                        cash -= fruit[input - 1];
                        break;
                }
            }
            else throw new Exception("Не вистачає грошей. Поповнiть баланс!");
        }

        public string ReplacementProductsBasket(ref string product)
        {
            if (element.Count == 0) throw new Exception("Список покупок пустий. Оберiть продукти!");

            product = string.Empty;

            if (element.Count != 0)
            {
                for (int i = 0; i < element.Count; i++)
                {
                    product += $"\n{i + 1} - {element[i]}";
                }
            }
            return product;
        }

        public static ShopLogic Parse(string productInfo)
        {
            if (string.IsNullOrWhiteSpace(productInfo))
            {
                throw new ArgumentException("Строка не може бути пустою!");
            }
            string[] productInfoArray = productInfo.Split(',');
            if (productInfoArray.Length != 2)
            {
                throw new FormatException("Формат введенно не вiрно! Приклад правельного введення: Баланс,Продукт");
            }
            if (!int.TryParse(productInfoArray[0], out int money))
            {
                throw new FormatException("Формат введенно не вiрно! Баланс повинен бути типу int!");
            }
            int productType = 0;
            int productIndex = 0;
            if (!ShopEqual.Equal(productInfoArray[1], ref productType, ref productIndex))
            {
                throw new FormatException("Цей продукт вiдсутнiй в продажу!");
            }
            ShopLogic BuyProduct = new ShopLogic(productIndex, productType, money);
            return BuyProduct;
        }
        public static bool TryParse(string productInfo, out ShopLogic BuyProduct)
        {
            BuyProduct = null;
            try
            {
                BuyProduct = Parse(productInfo);
                return true;
            }
            catch (FormatException ex) { return false; }
            catch (ArgumentOutOfRangeException ex) { return false; }
            catch (ArgumentException ex) { return false; }
        }
        public static string ProductsBasket
        {
            get
            {
                if (element.Count != 0)
                {
                    string itemsOutput = "Дякуємо за придбання:\n";
                    foreach (var item in element)
                    {
                        itemsOutput += $"{item}\n";
                    }
                    itemsOutput += $"Залишок: {cash} grn";
                    return itemsOutput;
                }
                return "\nСписок покупок пустий. Оберiть продукти!";
            }
        }

        public override string ToString()
        {
            return $"{Cash}, {ProductInp}";
        }
    }
}
