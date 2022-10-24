using IDGS903_Resistencias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace IDGS903_Resistencias.Service
{
    public class ServiceResistencia
    {

        public void GuardarArchivoResistencia(Resistencia r)
        {
            var color1 = r.Banda1;
            var color2 = r.Banda2;
            var color3 = r.Banda3;
            var tolerancia = r.Tolerancia;

            var res = color1 + "," + color2 + "," + color3 + "," + tolerancia + Environment.NewLine;
            var archivoResistencia = HttpContext.Current.Server.MapPath("~/App_Data/resistencia.txt");
            File.AppendAllText(archivoResistencia, res);
        }

        public List<Resistencia> MostrarResistencias()
        {
            Array userData = null;
            List<Resistencia> lista = new List<Resistencia>();
         

            var dataFile = HttpContext.Current.Server.MapPath("~/App_Data/resistencia.txt");
            if (File.Exists(dataFile))
            {
                userData = File.ReadAllLines(dataFile);

                using (StreamReader sr = new StreamReader(dataFile))
                {
                    string linea;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] infousu = linea.Split(',');
                        Resistencia re = new Resistencia(infousu[0], infousu[1],infousu[2],infousu[3]
                          );
                        lista.Add(re);
                    }
           
                }

            }
            return lista;
        }



        // Se crea el metodo de tipo Lista cuyo nombre es ValoresColres dicha lista es de tipo AlmacenResultados,
        // en ese metodo recibirá como parametros la lista de tipo Resistencia, la variable se llama total y es una lista.
        public List<AlmacenResultados> ValoresColores (List<Resistencia> total) 
        {

            //Se crea una lista de tipo AlmacenResultados
            List<AlmacenResultados> listaAlmacenRes = new List<AlmacenResultados>();

            Dictionary<string, int> B1 = new Dictionary<string, int>
            {
                {"Negro",0 },
                {"Cafe",1 },
                {"Rojo",2 },
                {"Naranja",3 },
                { "Amarillo", 4},
                {"Verde" , 5},
                {"Azul",6 },
                {"Violeta",7 },
                {"Gris",8 },
                {"Blanco",9 }

            };

            Dictionary<string, Int32> B2 = new Dictionary<string, Int32>
            {
                {"Negro",0 },
                {"Cafe",1 },
                {"Rojo",2 },
                {"Naranja",3 },
                { "Amarillo", 4},
                {"Verde" , 5},
                {"Azul",6 },
                {"Violeta",7 },
                {"Gris",8 },
                {"Blanco",9 }

            };

            Dictionary<string, Int32> B3 = new Dictionary<string, Int32>
            {
                {"Negro",1 },
                {"Cafe",10},
                {"Rojo",100 },
                {"Naranja",1000 },
                { "Amarillo", 10000},
                {"Verde" , 100000},
                {"Azul",1000000},
                {"Violeta",10000000 },
                {"Gris",100000000},
                {"Blanco",100000000 }

            };




            Dictionary<string, double> TorelanciaDic = new Dictionary<string, double>
            {
                {"Oro",0.05 },
                {"Plata",0.1}


            };


            double banda1;
            double banda2;
            double banda3;
            double tolerancia;

            int valor = B1["Naranja"];

            foreach(var i in total) // hacemos el barrido en la lista de total en la cual es la lista de tipo Resistencia
            {
                if (i.Banda1=="" || i.Banda2=="" || i.Banda3=="" || i.Tolerancia=="")// si es igual a vacio se rompe el if
                {

                    break;
                }
                else
                {
                    banda1 = B1[i.Banda1];
                    banda2 = B2[i.Banda2];
                    banda3 = B3[i.Banda3];
                    tolerancia = TorelanciaDic[i.Tolerancia];

                    AlmacenResultados al = new AlmacenResultados(
                        banda1,banda2,banda3,tolerancia
                        );
                    al.CalcularValor();
                    al.CalcularMax();
                    al.CalcularMin();

                    listaAlmacenRes.Add(al);
                }
            }


            return listaAlmacenRes;
        }


    }
}