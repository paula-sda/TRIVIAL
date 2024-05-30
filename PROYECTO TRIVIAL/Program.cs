﻿// CLASE  PRINCIPAL: TRIVIALGAME
using System;
using System.Collections.Generic;
using Trivial_parte_2.Clases;


class Program
{
    static void Main(string[] args)
    {
        TrivialGame juego = new TrivialGame();
        juego.Start();
    }
}

class TrivialGame
{
    int puntuacion;
    List<Pregunta> preguntas;

    public TrivialGame()
    {

        // Importar preguntas desde el archivo CSV
        string filePath = @".\preguntas.csv";
        preguntas = ImportarPreguntasDesdeCSV(filePath);

        puntuacion = 0;


    }

    // lo que hará esta función es leer el contenido csv
    private List<Pregunta> ImportarPreguntasDesdeCSV(string filePath)
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

    private void ShowIntroduction()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("TRIVIAL");
        Console.WriteLine("-------\n");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("¡Bienvenidos al emocionante juego del Trivial! Prepárate para poner a prueba tus conocimientos en una variedad de temas interesantes y divertidos. En este juego, te enfrentarás a 10 desafiantes preguntas de cultura general. ¿Estás listo para demostrar cuánto sabes?\n");

        Console.WriteLine("Presiona cualquier tecla para comenzar...");
        Console.ReadKey();
        Console.Clear();
    }

    private void ShowRules()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("REGLAS DEL JUEGO:\n");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("PUNTAJE: Obtendrás 10 puntos por cada respuesta correcta.\n");
        Console.WriteLine("TIPOS DE PREGUNTAS: Las preguntas pueden ser tanto abiertas, donde tendrás que escribir tu respuesta, como de opción múltiple, donde seleccionarás la opción correcta entre varias alternativas.\n");
        Console.WriteLine("NO HAY AYUDA EXTERNA: Este es un desafío individual, así que no se permite el uso de ayudas externas, como libros, internet o consultar a otras personas.\n");
        Console.WriteLine("DIVERSIÓN: ¡Lo más importante es disfrutar del juego! No te preocupes si alguna pregunta resulta difícil, ¡siempre puedes aprender algo nuevo!\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("¿CÓMO JUGAR?:\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Espera a que se presente la pregunta en pantalla.");
        Console.WriteLine("Lee cuidadosamente la pregunta y todas las opciones de respuesta.");
        Console.WriteLine("Si es una pregunta abierta, escribe tu respuesta toda en MAYUSCULAS.");
        Console.WriteLine("Prepárate para la siguiente pregunta y dale a intro para que se muestre por pantalla.\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("¡COMENCEMOS!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Presiona cualquier tecla para comenzar...");
        Console.ReadKey();
        Console.Clear();
    }
    public void Start()
    {
        ShowIntroduction();
        ShowRules();

        // Crear dor variables, una de ellas aleatorio y la otra para poder almacenar almacenar los índices de las preguntas que serán seleccionadas para mostrar
        Random rnd = new Random();
        HashSet<int> indicesSeleccionados = new HashSet<int>(); // La función hashhset nos asegura que almacena los elementos sin generar duplicados, en relación con las preguntas

        // crear una función while, en el que haga un random de los elementos de la lista que tenemos, 10 veces

        while (indicesSeleccionados.Count < 10)
        {
            indicesSeleccionados.Add(rnd.Next(preguntas.Count)); // con esta función, coge el tamaño de la lista de preguntas, y selecciona una de manera aleatoria,y la añade en la lista de seleccionadas
        }

        foreach (int index in indicesSeleccionados) // bucle que recorre todas las preguntas (habrá que meter un bucle en el que limita el numero de preguntas a 10) 
        {
            Pregunta preguntaActual = preguntas[index];

            preguntaActual.Mostrarpregunta();
            string userAnswer = preguntaActual.Getrespuesta();

            if (preguntaActual.RespuestaEscorrecta(userAnswer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n¡Respuesta correcta! Sumas 10 puntos.\n");
                Console.ForegroundColor = ConsoleColor.White;
                puntuacion += 10;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nRespuesta incorrecta.\n");
                preguntaActual.MostrarExplicacioncorrecta();
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($"Puntuación actual: {puntuacion} puntos\n");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        Console.WriteLine("¡Juego terminado!");
        Console.WriteLine($"Tu puntuación final es: {puntuacion} puntos");
    }
}

