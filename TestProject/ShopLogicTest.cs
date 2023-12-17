using Shop.Logic;

namespace TestProject
{
    [TestClass]
    public class ShopLogicTest
    {
        [TestMethod]
        public void AddCash_less_0()
        {
            ShopLogic.Cash = -1;
            int expected = 0;
            int actual = ShopLogic.Cash;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddCash_more_1000()
        {
            ShopLogic.Cash = 1001;
            int expected = 0;
            int actual = ShopLogic.Cash;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddCash_normal_1000()
        {
            ShopLogic.Cash = 1000;
            int expected = 1000;
            int actual = ShopLogic.Cash;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddCash_normal_500()
        {
            ShopLogic.Cash = 500;
            int expected = 1500;
            int actual = ShopLogic.Cash;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void BuyVegetable_notenoughMoney_normalIndex_normalProduct()
        {
            ShopLogic.Cash = 0;
            ShopLogic.Index = 1;
            int product = 1;
            ShopLogic logic = new ShopLogic();
            Assert.ThrowsException<Exception>(() => logic.Buy(product));
        }

        [TestMethod]
        public void BuyVegetable_enoughMoney_normalIndex_normalProduct()
        {
            ShopLogic logic = new ShopLogic();
            ShopLogic.Cash = 100;
            ShopLogic.Index = 1;
            int product = 1;
            logic.Buy(product);
            string expected = "Cucumber - 10 grn";
            string actual = ShopLogic.VegetableElement;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BuyVegetable_enoughMoney_normalIndex_nonexistentProduct()
        {
            ShopLogic.Cash = 500;
            ShopLogic.Index = 1;
            int product = 5;
            ShopLogic logic = new ShopLogic();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => logic.Buy(product));
        }
        [TestMethod]
        public void BuyVegetable_enoughMoney_nonexistentIndex_normalProduct()
        {
            ShopLogic.Cash = 500;
            ShopLogic.Index = 3;
            int product = 2;
            ShopLogic logic = new ShopLogic();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => logic.Buy(product));
        }
        [TestMethod]
        public void BuyVegetable_enoughMoney_nonexistentIndex_nonexistentProduct()
        {
            ShopLogic.Cash = 500;
            ShopLogic.Index = 3;
            int product = 5;
            ShopLogic logic = new ShopLogic();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => logic.Buy(product));
        }
        [TestMethod]
        public void ClearList1()
        {
            ShopLogic logic = new ShopLogic();
            string expected = "\nВсi продукти видаленi!";
            string actual = logic.ClearBasket;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Check_bought2()
        {
            ShopLogic logic = new ShopLogic();
            string action = logic.ClearBasket;
            string expected = "\nСписок покупок пустий. Оберiть продукти!";
            string actual = ShopLogic.ProductsBasket;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ClearList2()
        {
            ShopLogic logic = new ShopLogic();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ShopLogic.VegetableElement);
        }
        [TestMethod]
        public void TestTryParse_NOTnormal_bool()
        {
            ShopLogic logic = new ShopLogic();
            string action = logic.ClearBasket;
            string expected = "500";
            bool a = ShopLogic.TryParse(expected, out logic);
            Assert.IsFalse(a);
        }
        [TestMethod]
        public void TestTryParse_NOTnormal()
        {
            ShopLogic logic = new ShopLogic();
            string action = logic.ClearBasket;
            string input = "500,Rediska";
            ShopLogic.TryParse(input, out logic);
            Assert.ThrowsException<NullReferenceException>(() => logic.ToString());
        }
        [TestMethod]
        public void TestTryParse_normal_bool()
        {
            ShopLogic logic = new ShopLogic();
            string action = logic.ClearBasket;
            string expected = "100,Tomato";
            bool a = ShopLogic.TryParse(expected, out logic);
            Assert.IsTrue(a);
        }
    }
}