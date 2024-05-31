// CLASE  PRINCIPAL: TRIVIALGAME
using Trivial_parte_2.Clases;


class Program
{
    static void Main(string[] args)
    {
        bool jugarDeNuevo = true;

        while (jugarDeNuevo)
        {
            TrivialGame juego = new TrivialGame();
            juego.Start();

            // Crear variable response e inicializar a ""
            ConsoleKey response = ConsoleKey.Y;

            // Mover la línea para preguntar si quieren jugar de nuevo
            string preguntaOtraVez = "¿Quieres jugar otra vez? (Y/N): ";
            int xPregunta = (Console.WindowWidth - preguntaOtraVez.Length) / 2;
            int yPregunta = (Console.WindowHeight / 2) ; // Tres líneas por debajo del medio
            Console.SetCursorPosition(xPregunta, yPregunta);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(preguntaOtraVez);
            Console.ForegroundColor = ConsoleColor.White;

            response = Console.ReadKey().Key;

            // Crear bucle while con la condición de que response != "N"
            while (response != ConsoleKey.N && response != ConsoleKey.Y)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEsa respuesta no es valida. Por favor haz click en la tecla Y/N");
                Console.ForegroundColor = ConsoleColor.White;
                response = Console.ReadKey().Key;
            }
            Console.Clear();
            if (response == ConsoleKey.N)
            {
                // Mostrar "Gracias por jugar. ¡Hasta la próxima!" en el centro de la pantalla
                string farewellMessage = "Gracias por jugar. ¡Hasta la próxima!";
                Console.SetCursorPosition((Console.WindowWidth - farewellMessage.Length) / 2, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.White;
                foreach (char c in farewellMessage)
                {
                    Console.Write(c);
                    Thread.Sleep(100); // Ajusta el tiempo para la velocidad de tipeo
                }
                Thread.Sleep(1000); // Pausa antes de limpiar la pantalla

                Console.Clear(); // Limpiar la pantalla

                // Efecto de parpadeo para "TRIVIAL FINALIZADO"
                string finalMessage = "TRIVIAL FINALIZADO";
                int centerX = (Console.WindowWidth - finalMessage.Length) / 2;
                int centerY = Console.WindowHeight / 2;

                for (int i = 0; i < 10; i++) // 10 parpadeos
                {
                    Console.SetCursorPosition(centerX, centerY);
                    Console.ForegroundColor = ConsoleColor.Cyan; // Cambiar a color cyan
                    Console.Write(i % 2 == 0 ? finalMessage : new string(' ', finalMessage.Length));
                    Thread.Sleep(500); // Ajusta el tiempo de parpadeo
                }
                break;
            }


            
        }
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

            Console.WriteLine($"\nPuntuación actual: {puntuacion} puntos\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        // Animación de confeti durante 5 segundos
        ShowConfetti();

        // Limpiar la pantalla después del confeti
        Console.Clear();

        /// Mostrar "¡JUEGO TERMINADO!" centrado en la línea 5 de la pantalla en color azul
        string mensaje = "¡JUEGO TERMINADO!";
        int xMensaje = (Console.WindowWidth - mensaje.Length) / 2;
        int yMensaje = 5; // Línea 5
        Console.SetCursorPosition(xMensaje, yMensaje);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(mensaje);
        Console.ForegroundColor = ConsoleColor.White;

        // Mostrar la puntuación final en un cuadro unas líneas más abajo
        string puntuacionTexto = $"Tu puntuación final es: {puntuacion} puntos";
        int xPuntuacion = (Console.WindowWidth - puntuacionTexto.Length) / 2;
        int yPuntuacion = 10; // 3-4 líneas por debajo del mensaje

        DrawBox(xPuntuacion - 2, yPuntuacion - 1, puntuacionTexto.Length + 4, 3);
        Console.SetCursorPosition(xPuntuacion, yPuntuacion);
        Console.WriteLine(puntuacionTexto);
    }

    private void ShowConfetti()
    {
        Random rnd = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(3); // Durar 5 segundos
        while (DateTime.Now < endTime)
        {
            int x = rnd.Next(Console.WindowWidth);
            int y = rnd.Next(Console.WindowHeight); // Confeti cae en cualquier lugar de la pantalla
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = GetRandomConsoleColor();
            Console.Write("*");
            Thread.Sleep(20); // Ajusta la velocidad de caída del confeti
            Console.SetCursorPosition(x, y);
            Console.Write(" "); // Borra el confeti
        }
    }

    private ConsoleColor GetRandomConsoleColor()
    {
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor)consoleColors.GetValue(new Random().Next(consoleColors.Length));
    }

    private void DrawBox(int x, int y, int width, int height)
    {

        // Dibujar la parte superior del cuadro
        Console.SetCursorPosition(x, y);
        Console.Write("┌" + new string('─', width - 2) + "┐");

        // Dibujar los lados del cuadro
        for (int i = 1; i < height - 1; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write("│" + new string(' ', width - 2) + "│");
        }

        // Dibujar la parte inferior del cuadro
        Console.SetCursorPosition(x, y + height - 1);
        Console.Write("└" + new string('─', width - 2) + "┘");
    }
}

