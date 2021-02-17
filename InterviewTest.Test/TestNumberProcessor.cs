using InterviewTest.BusinessLogic;
using NUnit.Framework;

namespace InterviewTest.Test
{
    public class TestNumberProcessor
    {        
        [TestCase(1,1)]
        [TestCase(2,2)]
        [TestCase(4,2)]
        [TestCase(8,2)]
        [TestCase(9,3)]
        [TestCase(7, 7)]
        public void GetMultiple_GivenNumber_ShouldReturnMultipleOfNumber(int num, int expected)
        {  
            //Arrange

            //Act
            var actual = NumberProcessor.GetMultiple(num);

            //Assert            
            Assert.AreEqual(expected, actual);
        }
    }
}