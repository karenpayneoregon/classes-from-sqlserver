using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Classes;


// ReSharper disable once CheckNamespace - do not change
namespace DataLibraryTestProject
{
    public partial class MainTest
    {

        /// <summary>
        /// Perform any initialize for the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
        /// <summary>
        /// For assertions in <see cref="GetCountries"/> test method
        /// </summary>
        /// <returns></returns>
        protected List<Countries> ExpectedCountriesList() =>
            new()
            {
                new() {CountryIdentifier = 1, Name = "Argentina"},
                new() {CountryIdentifier = 2, Name = "Austria"},
                new() {CountryIdentifier = 3, Name = "Belgium"},
                new() {CountryIdentifier = 4, Name = "Brazil"},
                new() {CountryIdentifier = 5, Name = "Canada"},
                new() {CountryIdentifier = 6, Name = "Denmark"},
                new() {CountryIdentifier = 7, Name = "Finland"},
                new() {CountryIdentifier = 8, Name = "France"},
                new() {CountryIdentifier = 9, Name = "Germany"},
                new() {CountryIdentifier = 10, Name = "Ireland"}
            };
    }
}
