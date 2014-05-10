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
            Video testvideo = new Video();
            testvideo.Name = "The Batman";
            
            int returnId = repo.AddVideo(testvideo);
            Assert.IsTrue(returnId > 0);
        }
    }
}
