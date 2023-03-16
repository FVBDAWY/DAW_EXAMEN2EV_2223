using System;

namespace LotoClassNS
{
    
    /// <summary>
    /// Clase que almacena una combinación de la lotería
    /// </summary>
    public class loto
    {
        private const int Maximo = 6;
        private const int Minimo = 1;
        
        /// <summary>
        /// L constante define que el maximo de numeros a introducir seran 6
        /// </summary>
        private const int mAX_NUMEROS = Maximo;
        /// <summary>
        /// La constante define que el numero maximo que se podra introducir sera el 1
        /// </summary>
        private const int nUMERO_MENOR = Minimo;
        /// <summary>
        /// La constante define que el maximo numero que se podra introducir sera el 49
        /// </summary>
        private const int nUMERO_MAYOR = 49;
        /// <summary>
        /// Un array con los numeros de la combinacion
        /// </summary>
        private int[] _nums = new int[MAX_NUMEROS];
        /// <summary>
        /// combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)
        /// </summary>
        private bool ok = false;
        ///<value>
        /// Recibe el valor de los numeros
        /// </value>
        public int[] Nums { 
            get => _nums; 
            set => _nums = value; 
        }

        public static int MAX_NUMEROS => mAX_NUMEROS;

        public static int NUMERO_MENOR => nUMERO_MENOR;

        public static int NUMERO_MAYOR => nUMERO_MAYOR;

        public bool Ok { get => ok; set => ok = value; }



        /// <summary>
        /// El construnctor genera numeros aleatorios
        /// </summary>
        ///<remarks>Se genera automaticamente,En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta</remarks>
        ///<returns>Te devolvera un true una vez generado con exito</returns>
        public loto()
        {
            Random r = new Random();    // clase generadora de números aleatorios

            int i=0, j, num;

            do             // generamos la combinación
            {                       
                num = r.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);     // generamos un número aleatorio del 1 al 49
                for (j=0; j<i; j++)    // comprobamos que el número no está
                    if (Nums[j]==num)
                        break;
                if (i==j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    Nums[i]=num;
                    i++;
                }
            } while (i<MAX_NUMEROS);

            Ok=true;
        }

        
        /// <summary>
        /// La segunda forma de crear una combinación es pasando el conjunto de números
        // <remarks>misnums es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)</remarks>
        /// </summary>
        /// <param name="misnums">Define combinacion con la que queremos inicializar la clase</param>
        public loto(int[] misnums)  // misnumeros: combinación con la que queremos inicializar la clase
        {
            for (int i=0; i<MAX_NUMEROS; i++)
                if (misnums[i]>=NUMERO_MENOR && misnums[i]<=NUMERO_MAYOR) {
                    int j;
                    for (j=0; j<i; j++) 
                        if (misnums[i]==Nums[j])
                            break;
                    if (i==j)
                        Nums[i]=misnums[i]; // validamos la combinación
                    else {
                        Ok=false;
                        return;
                    }
                }
                else
                {
                    Ok=false;     // La combinación no es válida, terminamos
                    return;
                }
	    Ok=true;
        }

        
        /// <summary>
        /// Metodo que comprobara el numero de aciertos
        /// </summary>
        /// <param name="premi">Define el array con la combinacion ganadora</param>
        /// <returns>Se devuelve el numero de aciertos</returns>
        public int comprobar(int[] premi)
        {
            int a=0;                    // número de aciertos
            for (int i=0; i<MAX_NUMEROS; i++)
                for (int j=0; j<MAX_NUMEROS; j++)
                    if (premi[i]==Nums[j]) a++;
            return a;
        }
    }

}
