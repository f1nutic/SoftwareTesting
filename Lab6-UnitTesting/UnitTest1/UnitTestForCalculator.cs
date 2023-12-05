using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Tests;

namespace UnitTest1
{
    [TestClass]
    public class UnitTestForCalculator
    {
        int a, b;
        Calculator _calc;

        [TestInitialize]
        public void Init()
        {
            Random random = new Random();
            a = random.Next(-50,50);
            b = random.Next(-2,4);
            _calc = new Calculator();
        }

        [TestMethod]
        public void TestSum() 
        {
            int expend = a + b;
            int sum = _calc.Sum(a,b);
            
            Debug.WriteLine($"Входные данные: {a}, {b}. Ожидается = {expend}. Ответ = {sum}.");
            Assert.AreEqual(expend, sum);

        }

        [TestMethod]
        public void TestSubstraction()
        {
            int expend = a - b;
            int substraction = _calc.Substraction(a, b);

            Debug.WriteLine($"Входные данные: {a}, {b}. Ожидается = {expend}. Ответ = {substraction}.");
            Assert.AreEqual(expend, substraction);

        }

        [TestMethod]
        public void TestMultiplication()
        {
            int expend = a * b;
            int multiplication = _calc.Multiplication(a, b);

            Debug.WriteLine($"Входные данные: {a}, {b}. Ожидается = {expend}. Ответ = {multiplication}.");
            Assert.AreEqual(expend, multiplication);

        }

        [TestMethod]
        public void TestDivision()
        {
            double expend = a / b;
            double division = _calc.Division(a, b);

            Debug.WriteLine($"Входные данные: {a}, {b}. Ожидается = {expend}. Ответ = {division}.");
            Assert.AreEqual(expend, division);

        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivisionIfDividerIsNull()
        {
            if (b == 0)
                Debug.WriteLine($"Входные данные: {a}, {b}. Ожидается статус - успешно.");

            if (double.IsInfinity(_calc.Division(a, b)))
                throw new DivideByZeroException();
        }


        // TestInitialize | Обращение к объекту, вызывается блок для создания нового объекта | Будет метод, где инициализируется
        // TestCleanup | Очистка вс
        // ExceptedException(typeof(DivideByZeroException)) | Тест успешный, если выбьет ошибку указанную | Ставится псоле ТестМетод
        // Коллекции
        // ClassInitialize | Создание вх данных для всего класса и других тестов
        // Конструктор static Init pub static void Init(TestContext test) {_item = new List<string>();}
        //[TestMethod]
        //public void TestMethod1()
        //{
            


        //    Calculator _calc = new Calculator();

        //    // arranges | Описательная часть, входные данные
        //    int a = 10;
        //    int b = 20;
        //    int expend = 30;

        //    // act | Действие, что делается
        //    int it = _calc.Sum(a, b);

        //    // assert | Сравнение
        //    Assert.AreEqual(it, expend);

        //    // https://learn.microsoft.com/ru-ru/visualstudio/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests?view=vs-2022
        //}



    }
}
