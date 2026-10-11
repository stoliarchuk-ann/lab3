using lab3;

namespace TestProject1
{
    [TestClass]
    public sealed class TabletTests
    {
        [TestMethod]
        public void CalculateTreatmentCourse_ValidData_ReturnCorrectDays()
        {
            Tablet tab = new Tablet("Аспірин", "500 мг", 100.0, 30);
            int days = tab.CalculateTreatmentCourse(3);
            Assert.AreEqual(10, days);
        }

        [TestMethod]
        public void TabletConstructor_NegativePrice_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Tablet("Тест", "10 мг", -50.0, 10));
        }

        [TestMethod]
        public void CalculateTreatmentCourse_ZeroPillsPerDay_ThrowsDivideByZeroException()
        {
            Tablet tab = new Tablet("Аспірин", "500 мг", 100.0, 30);
            Assert.ThrowsException<DivideByZeroException>(() => tab.CalculateTreatmentCourse(0));
        }

        [TestMethod]
        public void CalculateTreatmentCourse_FractionalDivision_ReturnRoundedDownDays()
        {
            Tablet tab = new Tablet("Аспірин", "500 мг", 100.0, 20);
            int days = tab.CalculateTreatmentCourse(3);
            Assert.AreEqual(6, days);
        }

        [TestMethod]
        public void Apply_ReturnCorrectFormattedString()
        {
            Tablet tab = new Tablet("Ношпа", "40 мг", 80.0, 24);
            string result = tab.Apply();
            Assert.AreEqual("Прийняти таблетку Ношпа (дозування: 40 мг).", result);
        }

        [TestMethod]
        public void GetSideEffects_ReturnsCorrectFormattedString()
        {
            Tablet tab = new Tablet("Ношпа", "40 мг", 80.0, 24);
            string result = tab.GetSideEffects();
            Assert.AreEqual("Побічні ефекти від Ношпа: можливий головний біль або нудота.", result);
        }
    }

    [TestClass]
    public sealed class SyrupTests
    {
        [TestMethod]
        public void CheckExpirationDate_ValidMonths_returnTrue()
        {
            Syrup syr = new Syrup("Пектолван", "100 мл", 150.0, 200.0);
            bool isValid = syr.CheckExpirationDate(6);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void CheckExpiretionDate_ExpiredMonths_ReturnsFalse()
        {
            Syrup syr = new Syrup("Пектолван", "100 мл", 150.0, 200.0);
            bool isValid = syr.CheckExpirationDate(14);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CheckExpiretionDate_Exactly12Months_ReturnsTrue()
        {
            Syrup syr = new Syrup("Пектолван", "100 мл", 150.0, 200.0);
            bool isValid = syr.CheckExpirationDate(12);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Apply_ReturnsCorrectFormattedString()
        {
            Syrup syr = new Syrup("Амброксол", "15 мл", 120.0, 200.0);
            string result = syr.Apply();
            Assert.AreEqual("Прийняти сироп Амброксол (дозування: 15 мл).", result);
        }

        [TestMethod]
        public void GetSideEffects_ReturnsCorrectFormattedString()
        {
            Syrup syr = new Syrup("Амброксол", "15 мл", 120.0, 200.0);
            string result = syr.GetSideEffects();
            Assert.AreEqual("Побічні ефекти від Амброксол: можливий головний біль та запаморочення.", result);
        }

        [TestMethod]
        public void CheckExpirationDate_NegativeMonths_ReturnsTrue()
        {
            Syrup syr = new Syrup("Амброксол", "15 мл", 120.0, 200.0);
            bool isValid = syr.CheckExpirationDate(-5);
            Assert.IsTrue(isValid);
        }
    }

    [TestClass]
    public sealed class MedicineAnalysisTests
    {
        [TestMethod]
        public void GetTotalCost_CalculatesCorrectly()
        {
            List<Medicine> list = new List<Medicine>();
            Tablet tab = new Tablet("Аспірин", "500 мг", 100.0, 30);
            list.Add(tab);
            Syrup syr = new Syrup("Пектолван", "100 мл", 150.0, 200.0);
            list.Add(syr);
            double totalCost = MedicineAnalysis.GetTotalCost(list);
            Assert.AreEqual(totalCost, 250);
        }

        [TestMethod]
        public void GetTotalCost_EmptyList_ReturnsZero()
        {
            List<Medicine> list = new List<Medicine>();
            double totalCost = MedicineAnalysis.GetTotalCost(list);
            Assert.AreEqual(0.0, totalCost);
        }

        [TestMethod]
        public void GetTotalCost_SingleItem_ReturnsItemPrice()
        {
            List<Medicine> list = new List<Medicine>();
            Tablet tab = new Tablet("Аспірин", "500 мг", 100.0, 30);
            list.Add(tab);
            double totalCost = MedicineAnalysis.GetTotalCost(list);
            Assert.AreEqual(100.0, totalCost);
        }

        [TestMethod]
        public void GetTotalCost_NullList_ThrowsNullReferenceException()
        {
            Assert.ThrowsException<NullReferenceException>(() => MedicineAnalysis.GetTotalCost(null));
        }
    }
}
