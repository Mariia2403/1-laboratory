using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Перевірити, що конструктор ініціалізує властивості правильно при наданні коректних параметрів.
        public void Constructor_ValidParameters_ShouldInitializeProperties()
        {
            // Arrange
            double difference = 2.5;
            double firstTerm = 1.0;
            int nthTerm = 5;

            // Act
            ArithmeticProgression progression = new ArithmeticProgression(difference, firstTerm, nthTerm);

            // Assert
            Assert.AreEqual(difference, progression.Difference);
            Assert.AreEqual(firstTerm, progression.FirstTerm);
            Assert.AreEqual(nthTerm, progression.ProgressionTerm);
        }
        [TestMethod]
        public void Constructor_WithArrayParameters_ShouldInitializeArray()
        {
            // Arrange
            double difference = 3.0;
            double firstTerm = 2.0;
            int num = 3;
            int nthTerm = 5;

            // Act
            ArithmeticProgression progression = new ArithmeticProgression(difference, firstTerm, num, nthTerm);

            // Assert
            Assert.AreEqual(difference, progression.Difference);
            Assert.AreEqual(firstTerm, progression.FirstTerm);
            Assert.AreEqual(nthTerm, progression.ProgressionTerm);

            // Перевірка масиву
            Assert.IsNotNull(progression);
            Assert.AreEqual(firstTerm, progression[1]);
            Assert.AreEqual(firstTerm + difference, progression[2]);
            Assert.AreEqual(firstTerm + 2 * difference, progression[3]);
            Assert.AreEqual(firstTerm + 3 * difference, progression[4]);
            Assert.AreEqual(firstTerm + 4 * difference, progression[5]);
        }
        [TestMethod]
        public void Constructor_WithInvalidNum_ShouldThrowArgumentException()
        {
            // Arrange
            double difference = 1.0;
            double firstTerm = 1.0;
            int num = 0; // Неправильне значення
            int nthTerm = 5;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new ArithmeticProgression(difference, firstTerm, num, nthTerm));
        }
        [TestMethod]
        public void Indexer_ValidIndex_ShouldReturnCorrectTerm()
        {
            // Arrange
            double difference = 3.0;
            double firstTerm = 2.0;
            int nthTerm = 5;
            ArithmeticProgression progression = new ArithmeticProgression(difference, firstTerm, nthTerm, nthTerm);

            // Act
            double term = progression[3];

            // Assert
            Assert.AreEqual(8.0, term); // 2 + 3 * (3 - 1) = 8
        }

        [TestMethod]
        public void Indexer_InvalidIndex_ShouldThrowArgumentException()
        {
            // Arrange
            double difference = 2.0;
            double firstTerm = 1.0;
            int nthTerm = 5;
            ArithmeticProgression progression = new ArithmeticProgression(difference, firstTerm, nthTerm, nthTerm);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { var term = progression[6]; });
        }
        [TestMethod]

        public void SumProgression_ValidInput_ShouldReturnCorrectSum()
        {
            // Arrange
            double difference = 2.0;
            double firstTerm = 1.0;
            int nthTerm = 5;
            ArithmeticProgression progression = new ArithmeticProgression(difference, firstTerm, nthTerm);

            // Act
            double sum = progression.SumProgression(difference, firstTerm, nthTerm);

            // Assert
            Assert.AreEqual(25.0, sum); // Expected sum: (1 + 3 + 5 + 7 + 9) = 25
        }
        [TestMethod]


        public void OutputArr_ShouldPrintCorrectArray()
        {
            // Arrange
            double difference = 2.0;
            double firstTerm = 1.0;
            int nthTerm = 5;
            ArithmeticProgression progression = new ArithmeticProgression(difference, firstTerm, nthTerm, nthTerm);

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                progression.OutputArr();
                var result = sw.ToString().Trim();

                // Assert
                Assert.AreEqual("1 3 5 7 9", result);
            }
        }


    }
}
