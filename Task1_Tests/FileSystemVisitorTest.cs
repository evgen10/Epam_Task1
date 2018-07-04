﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T1;
using Moq;
using System.IO;
using System.Collections.Generic;

namespace Task1_Tests
{
    [TestClass]
    public class FileSystemVisitorTest
    {

        static string path = @"TestFolder";
        string fullPath = Path.GetFullPath(path);

        [TestMethod]
        public void FileFindTest()
        {
            //arrange        
            
            List<CatalogItem> result = new List<CatalogItem>();

            FileSystemVisitor visitor = new FileSystemVisitor();

            List<CatalogItem> expected = new List<CatalogItem>()
            {
                new CatalogItem { Name = "TestFolder", Deep = 0, Item = CatalogItems.Directory },
                new CatalogItem { Name = "Documents", Deep = 1, Item = CatalogItems.Directory },
                new CatalogItem { Name = "Excel", Deep = 2, Item = CatalogItems.Directory },
                new CatalogItem { Name = "NewDocuments", Deep = 3, Item = CatalogItems.Directory },
                new CatalogItem { Name = "25052018.xlsx", Deep = 4, Item = CatalogItems.File },
                new CatalogItem { Name = "10112017.xlsx", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "11062014.xlsx", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "22112006.xlsx", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "25032017.xlsx", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "Word", Deep = 2, Item = CatalogItems.Directory },
                new CatalogItem { Name = "10122005.docx", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "11032005.docx", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "14112018.docx", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "15022008.docx", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "16082009.docx", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "EmptyFolder", Deep = 1, Item = CatalogItems.Directory },
                new CatalogItem { Name = "Music", Deep = 1, Item = CatalogItems.Directory },
                new CatalogItem { Name = "Rap", Deep = 2, Item = CatalogItems.Directory },
                new CatalogItem { Name = "6IX9INE-Billy.mp3", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "oxxxy-x-xxxtentation_-_look-at-me.mp3", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "Rock&Roll", Deep = 2, Item = CatalogItems.Directory },
                new CatalogItem { Name = "guns-n-roses_-_welcome-to-the-jungle.mp3", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "metallica_-_die-die-my-darling.mp3", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "Pictures", Deep = 1, Item = CatalogItems.Directory },
                new CatalogItem { Name = "Animals", Deep = 2, Item = CatalogItems.Directory },
                new CatalogItem { Name = "1.jpg", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "2.jpg", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "3.jpg", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "Cars", Deep = 2, Item = CatalogItems.Directory },
                new CatalogItem { Name = "LuxuryCars", Deep = 3, Item = CatalogItems.Directory },
                new CatalogItem { Name = "1.jpg", Deep = 4, Item = CatalogItems.File },
                new CatalogItem { Name = "SportCars", Deep = 3, Item = CatalogItems.Directory },
                new CatalogItem { Name = "1.jpg", Deep = 4, Item = CatalogItems.File },
                new CatalogItem { Name = "2.jpg", Deep = 4, Item = CatalogItems.File },
                new CatalogItem { Name = "1.jpg", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "2.jpg", Deep = 3, Item = CatalogItems.File },
                new CatalogItem { Name = "Doc1.pptx", Deep = 1, Item = CatalogItems.File },
                new CatalogItem { Name = "TTT.zip", Deep = 1, Item = CatalogItems.File },
                
            };



            //act

            foreach (var item in visitor.FindItems(fullPath))
            {
                result.Add(item);
            }

            //accept
            CollectionAssert.AreEqual(expected,result);       
            
        }

        [TestMethod]
        public void FileFiltredFind()
        {

            //arrange
            string extension = ".xlsx";


            SearchFilter filter = new SearchFilter(extension);
            FileSystemVisitor visitor = new FileSystemVisitor(filter.MFilter);

            List<CatalogItem> result = new List<CatalogItem>();

            List<CatalogItem> expected = new List<CatalogItem>()
            {
               new CatalogItem { Name = "TestFolder", Deep = 0, Item = CatalogItems.Directory },
               new CatalogItem { Name = "Documents", Deep = 1, Item = CatalogItems.Directory },
               new CatalogItem { Name = "Excel", Deep = 2, Item = CatalogItems.Directory },
               new CatalogItem { Name = "NewDocuments", Deep = 3, Item = CatalogItems.Directory },
               new CatalogItem { Name = "25052018.xlsx", Deep = 4, Item = CatalogItems.File },
               new CatalogItem { Name = "10112017.xlsx", Deep = 3, Item = CatalogItems.File },
               new CatalogItem { Name = "11062014.xlsx", Deep = 3, Item = CatalogItems.File },
               new CatalogItem { Name = "22112006.xlsx", Deep = 3, Item = CatalogItems.File },
               new CatalogItem { Name = "25032017.xlsx", Deep = 3, Item = CatalogItems.File },
               new CatalogItem { Name = "Word", Deep = 2, Item = CatalogItems.Directory },
               new CatalogItem { Name = "EmptyFolder", Deep = 1, Item = CatalogItems.Directory },
               new CatalogItem { Name = "Music", Deep = 1, Item = CatalogItems.Directory },
               new CatalogItem { Name = "Rap", Deep = 2, Item = CatalogItems.Directory },
               new CatalogItem { Name = "Rock&Roll", Deep = 2, Item = CatalogItems.Directory },
               new CatalogItem { Name = "Pictures", Deep = 1, Item = CatalogItems.Directory },
               new CatalogItem { Name = "Animals", Deep = 2, Item = CatalogItems.Directory },
               new CatalogItem { Name = "Cars", Deep = 2, Item = CatalogItems.Directory },
               new CatalogItem { Name = "LuxuryCars", Deep = 3, Item = CatalogItems.Directory },
               new CatalogItem { Name = "SportCars", Deep = 3, Item = CatalogItems.Directory },

            };

            //act 
            foreach (var item in visitor.FindItems(fullPath))
            {
                result.Add(item);
            }          

            //accept
            CollectionAssert.AreEqual(expected, result);
            
        }




    }
}
