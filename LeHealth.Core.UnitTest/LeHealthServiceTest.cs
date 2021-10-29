using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LeHealth.Core.UnitTest
{
    [TestClass]
    public class LeHealthServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {

           

            
        }
        //[TestMethod]
        //public void TestMethod2()
        //{
        //    List<Auto> Auto = new List<Auto>()
        //    {
        //        new Auto{Marca = "Chevrolet", Modelo = "Sport", Ano = 2019, Color= "Azul", Cilindros=6, Peronsas= 4 },
        //        new Auto{Marca = "Chevrolet", Modelo = "Sport", Ano = 2018, Color= "Azul", Cilindros=6, Peronsas= 4 },
        //        new Auto{Marca = "Chevrolet", Modelo = "Sport", Ano = 2017, Color= "Azul", Cilindros=6, Peronsas= 4 }
        //    };

        //    Helper.GenerateExcel(Helper.ConvertToDataTable(Auto));
        //}

    }
    public class Auto
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }
        public int Ano { get; set; }

        public string Color { get; set; }
        public int Peronsas { get; set; }
        public int Cilindros { get; set; }
    }
}
