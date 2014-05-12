using Microsoft.VisualStudio.TestTools.UnitTesting;
using skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skjatextar.Tests.DAL
{
    [TestClass]
    public class TestVideoRepo
    {

        [TestMethod]
        public void TestCreateVideo() {
            TranslationRepository repo = new TranslationRepository();
            VideoRepository videoRepo = new VideoRepository();

            Category cat = new Category() { Title = "Spenna" };
            videoRepo.addCategory(cat);

            Video testvideo = new Video();
            testvideo.Name = "The Batman";
            testvideo.Category = cat;
            
            int returnId = repo.AddVideo(testvideo);
            Assert.IsTrue(returnId > 0);
            Assert.AreEqual("Spenna", testvideo.Category.Title);
            Assert.AreEqual(cat.ID, testvideo.CategoryID);
        }

        [TestMethod]
        public void testVideoCategory() { 
        
        }
    }
}
