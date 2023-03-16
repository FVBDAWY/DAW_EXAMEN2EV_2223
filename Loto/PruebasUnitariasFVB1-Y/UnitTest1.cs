using LotoClassNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace PruebasUnitariasFVB1_Y
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MetodoDePruebConUnValorSuperiorA49()
        {    //
            const int Ktam = 6;
            bool falso = false;
            int[] ListaNumeros = new int[Ktam] { 1, 2, 3, 4, 5, 50 };
            loto loto = new loto(ListaNumeros);
            Assert.AreEqual(falso,loto.MAX_NUMEROS);
        }
       
        [TestMethod]
        public void MetodoDePruebConUnValorInferior1()
        {
            const int Ktam = 6;
            bool falso = false;
            int[] ListaNumeros = new int[Ktam] { 0, 2, 3, 4, 5, 50 };
            loto loto = new loto(ListaNumeros);
            Assert.AreEqual(falso, ListaNumeros);
        }
        [TestMethod]
        public void MetodoDePruebConUnValorRepetido()
        {
                 
            const int Ktam = 6;
            bool falso = false;
            int[] ListaNumeros = new int[Ktam] { 0, 2, 2, 4, 5, 50 };
            loto loto = new loto(ListaNumeros);
            Assert.AreEqual(falso, ListaNumeros);

        }
        [TestMethod]
        public void Arrayde7()
        {

            const int Ktam = 7;
            bool falso = false;
            int[] ListaNumeros = new int[Ktam] { 0, 2, 2, 4, 5, 50,58 };
            loto loto = new loto(ListaNumeros);
            Assert.AreEqual(falso, ListaNumeros);

        }
        [TestMethod]
        public void Arrayde5()
        {

            const int Ktam = 5;
            bool falso = false;
            int[] ListaNumeros = new int[Ktam] { 0, 2, 2, 4, 5 };
            loto loto = new loto(ListaNumeros);
            Assert.AreEqual(falso, ListaNumeros);

        }
    }
}
