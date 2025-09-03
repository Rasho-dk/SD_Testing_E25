using Password_field;

namespace Test
{
    public class Tests
    {
        private CheckPasswordField _passwordField;
        [SetUp]
        public void Setup()
        {
            const string password = "mypwd";
            _passwordField = new CheckPasswordField(password);
        }

        [Test]
        [Category("HappyPass")]
        [TestCase("abcdef")] // Partition value 6 characters - 10 characters lower boundary
        [TestCase("abcdefs")]
        [TestCase("abcdefaw")]
        [TestCase("abcdefrew")]
        [TestCase("abcdefghij")] // Partition value 6 characters - 10 characters upper boundary
        public void Test_HappyPass_Password(string password)
        {
            // Act
            _passwordField = new CheckPasswordField(password);
            TestDelegate testDelegate = () => _passwordField.ValidatePassword();
            // Assert
            Assert.DoesNotThrow(testDelegate);
        }
        [Test]
        [Category("UnHappyPass")]
        [TestCase(null)] 
        [TestCase("")] 
        [TestCase(" ")]
        [TestCase("a")]
        [TestCase("wr2")] 
        [TestCase("abcde")] // Partition value less than 6 characters lower boundary
        [TestCase("abcdefghijk")] // Partition value greater than 10 characters upper boundary
        
        public void Test_UnHappyPass_Password(string? password)
        {
            // Act
            _passwordField = new CheckPasswordField(password);
            TestDelegate testDelegate = () => _passwordField.ValidatePassword();
            // Assert
            Assert.Throws<ArgumentException>(testDelegate);
        }

    }
}
