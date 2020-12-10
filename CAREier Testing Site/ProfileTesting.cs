using CAREier.Models;
using CAREier.Models.profiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CAREier_Testing_Site {
    [TestClass]
    public class ProfileTesting {
        private BuyerCatalog _buyers;
        private BringerCatalog _bringers;
        private StoreCatalog _stores;

        [TestMethod]
        public void UserTestBuyer1() {
            //Arrange
            ProfileArrangement();

            User user = new User();

            //Act
            user.Profile = _buyers.Read(1);

            //Assert

            Assert.AreEqual(user.Profile, _buyers.Read(1));
        }
        [TestMethod]
        public void UserTestBringer1() {
            //Arrange
            ProfileArrangement();

            User user = new User();

            //Act
            user.Profile = _bringers.Read(1);

            //Assert

            Assert.AreEqual(user.Profile, _bringers.Read(1));
        }
        [TestMethod]
        public void UserTestStore1() {
            //Arrange
            ProfileArrangement();

            User user = new User();

            //Act
            user.Profile = _stores.Read(1);

            //Assert

            Assert.AreEqual(user.Profile, _stores.Read(1));
        }
        [TestMethod]
        public void UserTestExchange1() {
            //Arrange
            ProfileArrangement();

            User user = new User();

            //Act
            user.Profile = _stores.Read(1);
            user.Profile = _buyers.Read(1);

            //Assert

            Assert.AreEqual(user.Profile, _buyers.Read(1));
        }

        private void ProfileArrangement() {
            _buyers = new BuyerCatalog();
            _bringers = new BringerCatalog();
            _stores = new StoreCatalog();

            _buyers.Create(new Buyer("Bob", "Bob@hotmail.com", "38383260", "Kærlighedsvej 7777, Intetsted", new List<Order>(), "B0b", "Langelænder"));
            _buyers.Create(new Buyer("Eugene", "MyLittlePony@Bronuts.com", "34-237-957-362", "Austin Delaware street 802, Texas", new List<Order>(), "XXB1gD1ck69XX", "LoveuMom"));
            //_buyers.Create(new Buyer());

            _bringers.Create(new Bringer("Dillon", "GenericEmail@Gmail.com", "11111111111", 2.3d, new List<Order>(), "Do1l0r", "$$$$$$$$$$"));
            _bringers.Create(new Bringer("Raily", "RailCraft@mojang.com", "123456789", 5.0, new List<Order>(), "420BlazeIt", "ILikeBigBlocks&IJustCan'tLie"));
            //_bringers.Create(new Bringer());

            _stores.Create(new Store("Fætter BR", "Molesting@candy.ir", "Your backyard", "18:00-7:00", 10/10, "BRBehindYou", "You'llNeverGuessThis"));
            _stores.Create(new Store("Fakta", "NoReply@fakta.dk", "Everywhere", "All the frigging time", 1.3d, "DetFakta", "Faktuelt"));
            //_stores.Create(new Store());
        }
    }
}
