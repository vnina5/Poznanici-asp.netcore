using ApplicationLayer.Validators;

namespace Test.Validation
{
    public class JMBGValidatorTest
    {

        public JMBGValidatorTest()
        {

        }

        [Fact]
        public void JMBGValid()
        {
            long jmbg = 1912000715061;

            bool result = JMBGValidator.ValidateJMBG(jmbg);

            Assert.True(result);
        }

        [Fact]
        public void JMBGInvalidLenghth()
        {
            long jmbg = 1912000715;

            bool result = JMBGValidator.ValidateJMBG(jmbg);

            Assert.False(result);
        }

        [Fact]
        public void JMBGInvalidDate()
        {
            long jmbg = 9999999000000;

            bool result = JMBGValidator.ValidateJMBG(jmbg);

            Assert.False(result);
        }

        [Fact]
        public void JMBGInvalidControlNumber()
        {
            long jmbg = 1912000715066;

            bool result = JMBGValidator.ValidateJMBG(jmbg);

            Assert.False(result);
        }

    }
}
