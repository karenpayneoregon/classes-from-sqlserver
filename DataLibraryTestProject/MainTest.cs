using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataLibrary.Classes;
using DataLibraryTestProject.Base;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataLibraryTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.SqlOperations)]
        public void GetCountries()
        {
            SqlOperations.Server = ".\\SQLEXPRESS";
            SqlOperations.Database = "NorthWind2020";

            var (success, _, countriesList) = SqlOperations.GetCountriesList();

            Assert.IsTrue(success);
            countriesList.IsDeepEqual(ExpectedCountriesList());
        }

    }
}
