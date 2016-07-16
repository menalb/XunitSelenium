using Xunit;

namespace XunitSeleniumTests
{
    public class Tests
    {
        [Fact]
        public void Everything_Is_OK()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public void OPS()
        {
            Assert.True(0 == 1);
        }
    }
}