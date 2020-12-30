using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sesion6_EjercicioRestaurante
{
    class milestone1
    {
        public void CargarMenu()
        {

            //FASE 1
            int b1 = 1;
            int b2 = 2;
            int b5 = 5;
            int b10 = 10;
            int b20 = 20;
            int b50 = 50;
            int b100 = 100;
            int b200 = 200;
            int b500 = 500;
            int total = 0;


            string[] platos = { "Arruz cubana", "Spagueti Boloñesa", "Paella", "Marmitako", "Migas", "Jamon", "Rebollones", "Natillas", "Torrezno", "Calamares" };
            int[] precios = { 7, 8, 12, 9, 6, 7, 4, 3, 2, 7 };



            //FASE 2

            ArrayList lista = new ArrayList();
            Dictionary<string, int> dicc = new Dictionary<string, int>();
            int mas = 1;

            for (int i = 0; i <= platos.Length - 1; i++)
            {
                dicc.Add(platos[i], precios[i]);

                Console.WriteLine("- Plato {0}: {1}. {2} euros", i + 1, platos[i], precios[i]);

            }

            while (mas == 1)
            {
                Console.WriteLine("Indique que plato quiere pedir: ");

                string pedido = Console.ReadLine();
                lista.Add(pedido);
                Console.WriteLine("¿Desea elegir algo más? 1-SI | 0-NO");
                string resp = Console.ReadLine();

                if (resp == "1")
                {
                    mas = 1;
                }
                else if (resp == "0")
                {
                    mas = 0;
                }
                else
                {
                    Console.WriteLine("ERROR");
                    break;
                }
            }

            //FASE 3


            for (int i = 0; i <= lista.Count - 1; i++)
            {
                string pl = (string)lista[i];

                try
                {
                    if (dicc[pl] > 0)
                    {

                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("{0} no es un plato del menú", pl);
                    break;
                }


                total = total + dicc[pl];

            }
            Console.WriteLine("El precio total del menú es {0}", total);

            //FASE PAGAR

            Console.WriteLine("Inserte la cantidad con la que va a pagar: ");
            string pa = Console.ReadLine();
            int pagar = Convert.ToInt32(pa);


            int devolucion = pagar - total;

            int[] monedas = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
            int[] cuantas = new int[9];

            double div = 0;
            double resto = 0;

            for (int i = 0; i <= monedas.Length - 1; i++)
            {
                div = devolucion / monedas[i];
                resto = devolucion % monedas[i];
                if (div >= 1)
                {
                    cuantas[i] = (int)Math.Truncate(div);
                    devolucion = (int)resto;
                }
            }

            Console.WriteLine("Su devolución será la siguiente:");
            for (int i = 0; i <= monedas.Length - 1; i++)
            {
                Console.WriteLine("{0} billetes/monedas de {1}", cuantas[i], monedas[i]);
            }
        }
    }
}
