using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LotoClassNS;

namespace ExamenLoto
{
    public partial class Form1 : Form
    {
        public loto miLoto, miGanadora;
        private TextBox[] combinacion = new TextBox[6]; // Estos arrays se usan para recorrer de manera más sencilla los controles
        private TextBox[] ganadora = new TextBox[6];
        private const int Cero = 0;
        private const int Uno = 1;
        private const int Dos = 2;
        private const int Tres = 3;
        private const int Cuatro = 4;
        private const int Cinco = 5;
        public Form1()
        {
            InitializeComponent();
            combinacion[cero] = txtNumero1; ganadora[cero] = txtGanadora1;
            combinacion[uno] = txtNumero2; ganadora[uno] = txtGanadora2;
            combinacion[dos] = txtNumero3; ganadora[dos] = txtGanadora3;
            combinacion[tres] = txtNumero4; ganadora[tres] = txtGanadora4;
            combinacion[cuatro] = txtNumero5; ganadora[cuatro] = txtGanadora5;
            combinacion[cinco] = txtNumero6; ganadora[cinco] = txtGanadora6;
            miGanadora = new loto(); // generamos la combinación ganadora
            for (int i = 0; i < 6; i++)
                ganadora[i].Text = Convert.ToString(miGanadora.Nums[i]);

        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            miLoto = new loto(); // usamos constructor vacío, se genera combinación aleatoria
            for ( int i=0; i<6; i++ )
                combinacion[i].Text = Convert.ToString(miLoto.Nums[i]);
        }

        private void btValidar_Click(object sender, EventArgs e)
        {
            int[] numeros = MetodoRefactorizar();
            miLoto = new loto(numeros);
            if (miLoto.Ok)
                MessageBox.Show("Combinación válida");
            else
                MessageBox.Show("Combinación no válida");
        }

        private int[] MetodoRefactorizar()
        {
            int[] numeros = new int[6];
            for (int i = 0; i < 6; i++)
                numeros[i] = Convert.ToInt32(combinacion[i].Text);
            return numeros;
        }

        private void btComprobar_Click(object sender, EventArgs e)
        {
            int[] nums = MetodoRefactorizar();
            miLoto = new loto(nums);
            if (miLoto.Ok)
            {
                nums = new int[6];
                for (int i = 0; i < 6; i++)
                    nums[i] = Convert.ToInt32(combinacion[i].Text);
                int aciertos = miGanadora.comprobar(nums);
                if (aciertos < 3)
                    MessageBox.Show("No ha resultado premiada");
                else
                    MessageBox.Show("¡Enhorabuena! Tiene una combinación con " + Convert.ToString(aciertos) + " aciertos");
            }
            else
                MessageBox.Show("La combinación introducida no es válida");
        }
    }
}
