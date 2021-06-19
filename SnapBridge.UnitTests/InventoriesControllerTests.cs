 using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnapBridge.Controllers;
using SnapBridge.Dtos;
using SnapBridge.Models;
using SnapBridge.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SnapBridge.UnitTests
{
    [TestClass]
    public class InventoriesControllerTests
    {
        [TestMethod]
        public void InsertToDB_Test()
        {
            // Arrange  
            HttpPostedFileBase httpPostedFile = Mock.Of<HttpPostedFileBase>();
            var mock = Mock.Get(httpPostedFile);
            mock.Setup(_ => _.FileName).Returns("images.jpg");
            var memoryStream = new MemoryStream();
            //...populate fake stream
            //setup mock to return stream
            mock.Setup(_ => _.InputStream).Returns(memoryStream);
            InventoryDto inventoryDto = new InventoryDto
            {
                Name = "TestItem",
                Discription = "TestDiscription",
                Price = 100,
                Image = httpPostedFile
            };
            DbWriteRepository writeRepo = new DbWriteRepository();
            int i = writeRepo.InsertInDataBase(inventoryDto);

            Assert.IsTrue(i == 1);
        }
        [TestMethod]
        public void ReadItemFromDb_Test()
        {
            // Arrange  
            HttpPostedFileBase httpPostedFile = Mock.Of<HttpPostedFileBase>();
            var mock = Mock.Get(httpPostedFile);
            mock.Setup(_ => _.FileName).Returns("images.jpg");
            var memoryStream = new MemoryStream();
            //...populate fake stream
            //setup mock to return stream
            mock.Setup(_ => _.InputStream).Returns(memoryStream);
            InventoryDto inventoryDto = new InventoryDto
            {
                Name = "TestItem",
                Discription = "TestDiscription",
                Price = 100,
                Image = httpPostedFile
            };
            DbWriteRepository writeRepo = new DbWriteRepository();
            int i = writeRepo.InsertInDataBase(inventoryDto);
            DbReadRepository readRepo = new DbReadRepository();
            List<Inventory> items = (List<Inventory>)readRepo.ReadAllItemsFromDB();
            Inventory inventory = readRepo.ReadItemFromDb(items[0].Id);
            var img = readRepo.GetImageFromDb(items[0].Id);
            Assert.IsNotNull(inventory);
            Assert.IsNotNull(img);
        }

        [TestMethod]
        public void DeleteItemFromDb_Test()
        {
            // Arrange  
            HttpPostedFileBase httpPostedFile = Mock.Of<HttpPostedFileBase>();
            var mock = Mock.Get(httpPostedFile);
            mock.Setup(_ => _.FileName).Returns("images.jpg");
            var memoryStream = new MemoryStream();
            //...populate fake stream
            //setup mock to return stream
            mock.Setup(_ => _.InputStream).Returns(memoryStream);
            InventoryDto inventoryDto = new InventoryDto
            {
                Name = "TestItem",
                Discription = "TestDiscription",
                Price = 100,
                Image = httpPostedFile
            };
            DbWriteRepository writeRepo = new DbWriteRepository();
            int i = writeRepo.InsertInDataBase(inventoryDto);
            DbReadRepository readRepo = new DbReadRepository();
            List<Inventory> items = (List<Inventory>)readRepo.ReadAllItemsFromDB();
            writeRepo.DeleteItemFromDb(items[0].Id);
            DbReadRepository readRepos = new DbReadRepository();
            Inventory inventory = readRepos.ReadItemFromDb(items[0].Id);
            Assert.IsNull(inventory);
        }

    }
}
