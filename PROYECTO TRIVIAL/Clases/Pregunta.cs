
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trivial_parte_2.Clases
{
    // Crear una clase que sea pregunta
    public class Pregunta
    {
        // añadir variable de tipo texto en el que habrá que decir si es pública o privada
        public string Texto { get; set; }
        public string Respuestacorrecta { get; set; }
        public string Explicacioncorrecta { get; set; }

        public List<string> Opcionespregunta;

        // hacer un contructor para que se pueda instanciar la pregunta
        public Pregunta(string texto, string respuestacorrecta, string explicacioncorrecta, List<string> opcion = null)
        {
            Texto = texto;

            Respuestacorrecta = respuestacorrecta;

            Explicacioncorrecta = explicacioncorrecta;

            Opcionespregunta = opcion;
        }

        // Añadir método para mostrar la pregunta  y las opciones, si las hay. (bien sea con opciones o sin opciones)
        public void Mostrarpregunta()
        {
            Console.WriteLine(Texto);
            if (Opcionespregunta != null)
            {
                foreach (string s in Opcionespregunta)
                {
                    Console.WriteLine(s);

                }
            }
        }

        // Añadir método para leer las respuestas del usuario
        public string Getrespuesta()
        {
            return Console.ReadLine();
        }
        // Añadir método para comprobar que es correcta la respuesta
        public bool RespuestaEscorrecta(string respuestausuario)
        {
            return respuestausuario.Equals(Respuestacorrecta, StringComparison.OrdinalIgnoreCase);
        }
        // Añadir método que muestre la explicación de la respuesta
        public void MostrarExplicacioncorrecta()
        {
            Console.WriteLine(Explicacioncorrecta);
        }
        // lo que hará esta función es leer el contenido csv
        public static List<Pregunta> ImportarPreguntasDesdeCSV(string filePath)
        {
            var preguntas = new List<Pregunta>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                bool isFirstLine = true;
                while ((line = reader.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    var values = line.Split(';');

                    var texto = values[0].Trim('"');
                    var respuestacorrecta = values[1].Trim('"');
                    var explicacioncorrecta = values[2].Trim('"');
                    List<string> opcionesLista = null;

                    if (values.Length > 3)
                    {
                        opcionesLista = new List<string>(values[3].Trim('"').Split('|'));
                    }

                    preguntas.Add(new Pregunta(texto, respuestacorrecta, explicacioncorrecta, opcionesLista));
                }
            }
            return preguntas;
        }
    }
}