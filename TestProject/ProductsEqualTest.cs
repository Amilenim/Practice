using Shop.Logic;

namespace TestProject
{
    [TestClass]
    public class ShopEqualTest
    {
        [TestMethod]
        public void Product_Equal_1()
        {
            string product = "Banana";      
            int a = 0;
            ShopEqual products = new ShopEqual();
            bool result = ShopEqual.Equal(product, ref a, ref a);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Product_Equal_2()
        {
            string product = "Banana";
            int actual = 0;
            int a = 0;
            int expected = 2;
            ShopEqual products = new ShopEqual();
            ShopEqual.Equal(product, ref actual, ref a);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Product_Equal_3()
        {
            string product = "Banana";
            int a = 0;
            int actual = 0;
            int expected = 2;
            ShopEqual products = new ShopEqual();
            ShopEqual.Equal(product, ref a, ref actual);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Product_Equal_4()
        {
            string product = "Tiger";
            int a = 0;
            ShopEqual products = new ShopEqual();
            bool result = ShopEqual.Equal(product, ref a, ref a);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Product_Equal_5()
        {
            string product = "Forel";
            int actual = 0;
            int b = 0;
            int expected = 1;
            ShopEqual products = new ShopEqual();
            ShopEqual.Equal(product, ref actual, ref b);
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void Product_Equal_6()
        {
            string product = "Cilca";
            int a = 0;
            int actual = 0;
            int expected = 1;
            ShopEqual products = new ShopEqual();
            ShopEqual.Equal(product, ref a, ref actual);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
