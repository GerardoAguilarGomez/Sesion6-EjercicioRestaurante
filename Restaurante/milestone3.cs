using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sesion6_EjercicioRestaurante
{
    class milestone3
    {
        public void CargarMenu()
        {

            int total = 0;
            string[] platos = { "Arruz cubana", "Spagueti Boloñesa", "Paella", "Marmitako", "Migas", "Jamon", "Rebollones", "Natillas", "Torrezno", "Calamares" };
            int[] precios = { 7, 8, 12, 9, 6, 7, 4, 3, 2, 7 };

            ArrayList lista = new ArrayList();
            Dictionary<string, int> dicc = new Dictionary<string, int>();

            for (int i = 0; i <= platos.Length - 1; i++)
            {
                dicc.Add(platos[i], precios[i]);

                Console.WriteLine("- Plato {0}: {1}. {2} euros", i + 1, platos[i], precios[i]);

            }

            int controlador = 1;

            while (controlador == 1)
            {

                string Plato_Pedido = Preguntar();

                try
                {
                    int precio = dicc[Plato_Pedido];
                }
                catch (KeyNotFoundException)
                {
                    throw new KeyNotFoundException("Ese plato no está en el menú");
                }

                lista.Add(Plato_Pedido);

                string respuesta = Elegir_Mas();
                try
                {
                    int respuesta_int = Convert.ToInt32(respuesta);
                    if (respuesta_int == 1)
                    {

                        controlador = 1;
                    }
                    else if (respuesta_int == 0)
                    {
                        controlador = 0;
                    }
                }
                catch (FormatException)
                {
                    throw new FormatException("Debe responder con un valor entero");
                }
            }

            for (int i = 0; i <= lista.Count - 1; i++)
            {
                string pl = (string)lista[i];

                total = total + dicc[pl];

            }
            Console.WriteLine("El precio total del menú es {0}", total);


            Pagar(total);
        }

        public string Preguntar()
        {
            Console.WriteLine("Indique que plato quiere pedir: ");
            string pedido = Console.ReadLine();
            return pedido;
        }

        public string Elegir_Mas()
        {
            Console.WriteLine("¿Desea elegir algo más? 1-SI | 0-NO");
            string respuesta = Console.ReadLine();
            return respuesta;
        }

        public void Pagar(int total)
        {
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