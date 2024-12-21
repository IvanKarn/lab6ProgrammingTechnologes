using lab6ProgrammingTechnologes;
using Moq;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void UserCreateWithBalanceTest()
        {
            var MockDb = new Mock<IDataSource>();
            MockDb.Setup(data => data.AddUser("1"));
            MockDb.Setup(data => data.IsUserExists("1")).Returns(false);
            MockDb.Setup(data => data.SetBalance("1", 10)).Verifiable();
            BankAccount account = new BankAccount("1", MockDb.Object, 10);
            MockDb.Verify(data => data.SetBalance("1", 10), Times.Once);
        }
        [Fact]
        public void UserCreateWithoutBalanceTest()
        {
            var MockDb = new Mock<IDataSource>();
            MockDb.Setup(data => data.AddUser("1"));
            MockDb.Setup(data => data.IsUserExists("1")).Returns(false);
            MockDb.Setup(data => data.SetBalance("1", 0)).Verifiable();
            BankAccount account = new BankAccount("1", MockDb.Object);
            MockDb.Verify(data => data.SetBalance("1", 0), Times.Once);
        }
        [Fact]
        public void UserExistsWithBalanceTest()
        {
            var MockDb = new Mock<IDataSource>();
            MockDb.Setup(data => data.AddUser("1"));
            MockDb.Setup(data => data.IsUserExists("1")).Returns(true);
            MockDb.Setup(data => data.SetBalance("1", 10)).Verifiable();
            BankAccount account = new BankAccount("1", MockDb.Object, 10);
            MockDb.Verify(data => data.SetBalance("1", 10), Times.Never);
        }
        [Fact]
        public void UserExistsWithoutBalanceTest()
        {
            var MockDb = new Mock<IDataSource>();
            MockDb.Setup(data => data.AddUser("1"));
            MockDb.Setup(data => data.IsUserExists("1")).Returns(true);
            MockDb.Setup(data => data.SetBalance("1", 0)).Verifiable();
            BankAccount account = new BankAccount("1", MockDb.Object);
            MockDb.Verify(data => data.SetBalance("1", 0), Times.Never);
        }
        [Fact]
        public void MakeDeposite()
        {
            var MockDb = new Mock<IDataSource>();
            MockDb.Setup(data => data.AddUser("1"));
            MockDb.Setup(data => data.IsUserExists("1")).Returns(true);
            MockDb.Setup(data => data.SetBalance("1", 10)).Verifiable();
            MockDb.Setup(data => data.GetBalance("1")).Returns(0);
            BankAccount account = new BankAccount("1", MockDb.Object);
            account.Deposit(10);
            MockDb.Verify(data => data.SetBalance("1", 10), Times.Once);
        }
        [Fact]
        public void MakeIncorrectDeposite()
        {
            var MockDb = new Mock<IDataSource>();
            MockDb.Setup(data => data.AddUser("1"));
            MockDb.Setup(data => data.IsUserExists("1")).Returns(true);
            BankAccount account = new BankAccount("1", MockDb.Object);
            Assert.Throws<ValueError>(() => account.Deposit(-10));
            Assert.Throws<ValueError>(() => account.Deposit(0));
        }
        [Fact]
        public void MakeWithdraw()
        {
            var MockDb = new Mock<IDataSource>();
            MockDb.Setup(data => data.AddUser("1"));
            MockDb.Setup(data => data.IsUserExists("1")).Returns(true);
            MockDb.Setup(data => data.SetBalance("1", 7)).Verifiable();
            MockDb.Setup(data => data.GetBalance("1")).Returns(10);
            BankAccount account = new BankAccount("1", MockDb.Object);
            account.Withdraw(3);
            MockDb.Verify(data => data.SetBalance("1", 7), Times.Once);
        }
        [Fact]
        public void MakeIncorrectWithdraw()
        {
            var MockDb = new Mock<IDataSource>();
            MockDb.Setup(data => data.AddUser("1"));
            MockDb.Setup(data => data.IsUserExists("1")).Returns(true);
            MockDb.Setup(data => data.GetBalance("1")).Returns(10);
            BankAccount account = new BankAccount("1", MockDb.Object);
            Assert.Throws<ValueError>(() => account.Withdraw(-10));
            var ex = Assert.Throws<ValueError>(() => account.Withdraw(11));
            Assert.Equal("Insufficient funds", ex.Message);
        }
        [Fact]
        public void BalanceTest()
        {
            Database data = new Database();
            BankAccount account = new BankAccount("1", data);
            account.Deposit(10);
            Assert.Equal(10, account.GetBalance());
            account.Deposit(10);
            Assert.Equal(20, account.GetBalance());
            account.Withdraw(10);
            Assert.Equal(10, account.GetBalance());
        }
    }
}
