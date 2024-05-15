//MOSTRAR INTRODUCCÍON DEL JUEGO, REGLAS Y COMO JUGAR.
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("TRIVIAL");
Console.WriteLine("-------\n");
Console.ForegroundColor = ConsoleColor.White;


Console.WriteLine("¡Bienvenidos al emocionante juego del Trivial! Prepárate para poner a prueba tus conocimientos en una variedad de temas interesantes y divertidos. En este juego, te enfrentarás a 10 desafiantes preguntas de cultura general. ¿Estás listo para demostrar cuánto sabes?\n");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("REGLAS DEL JUEGO:\n");
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine("PUNTAJE: Obtendrás 10 puntos por cada respuesta correcta.\n");
Console.WriteLine("TIPOS D EPREGUNTAS: Las preguntas pueden ser tanto abiertas, donde tendrás que escribir tu respuesta, como de tipo test, donde seleccionarás la opción correcta entre varias alternativas.\n");
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
//Limpia la pantalla
Console.Clear();

//PREGUNTAS
// Inicializar la puntuación
int puntuacion = 0;

// Recolectar la respuesta del usuario
string respuestaAbierta;
ConsoleKey respuestaTest = ConsoleKey.Y;

// Mostrar la primera pregunta
Console.WriteLine("PREGUNTA 1: ¿En qué año el hombre pisó la Luna por primera vez?");
respuestaAbierta = Console.ReadLine();

// Verificar si la respuesta es correcta
if (respuestaAbierta == "1969")
{
    // Actualizar la puntuación
    puntuacion += 10;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n¡Respuesta correcta! Sumas 10 puntos.");
    Console.ForegroundColor = ConsoleColor.White;

}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nRespuesta incorrecta.\n");
    Console.WriteLine("La nave Apolo 11 llegó a la Luna en el año 1969, siendo ese año cuando Neil Armstrong dió “un pequeño paso para el hombre, un gran paso para la humanidad”.\n");
    Console.ForegroundColor = ConsoleColor.White;

}

// Mostrar la puntuación actual
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n\nPuntuación actual: " + puntuacion + " puntos");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("¡Presiona cualquier tecla para CONTINUAR!");
Console.ForegroundColor = ConsoleColor.White;
Console.ReadKey();

// Limpia la pantalla
Console.Clear();

// Mostrar la SEGUNDA pregunta abierta
Console.WriteLine("PREGUNTA 2:¿En qué ciudad se celebró la primera Semana de la Moda?");
Console.WriteLine("a) Milan");
Console.WriteLine("b) Paris");
Console.WriteLine("c) Nueva York");
respuestaTest = Console.ReadKey().Key;


//comprobar que la respuesta sea valida
while (respuestaTest != ConsoleKey.A && respuestaTest != ConsoleKey.B && respuestaTest != ConsoleKey.C)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nEsa respuesta no es valida. Por favor haz click en las tecla A/B/C");
    Console.ForegroundColor = ConsoleColor.White;
    respuestaTest = Console.ReadKey().Key;
}
Console.Clear();
if (respuestaTest == ConsoleKey.C)
{
    // Respuesta correcta
    puntuacion += 10;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n¡Respuesta correcta! Sumas 10 puntos.");
    Console.ForegroundColor = ConsoleColor.White;
}
else if (respuestaTest == ConsoleKey.A || respuestaTest == ConsoleKey.B)
{
    // Respuesta incorrecta
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nRespuesta incorrecta.\n");
    Console.WriteLine("Se celebró en Nueva York en el año 1943, con el objetivo de desviar la atención que acaparaba la moda francesa durante la Segunda Guerra Mundial\n");
}

// Mostrar la puntuación actual
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n\nPuntuación actual: " + puntuacion + " puntos");

Console.WriteLine("¡Presiona cualquier tecla para CONTINUAR!");
Console.ReadKey();
Console.Clear();

// Mostrar la TERCERA pregunta abierta
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("PREGUNTA 3:¿Cuál es el tenista que ha ganado en más ocasiones el título de Roland Garros? (hasta 2024)");
Console.WriteLine("a) Roger Federer");
Console.WriteLine("b) Rafa Nadal");
Console.WriteLine("c) Novak Dokovic");
respuestaTest = Console.ReadKey().Key;


//comprobar que la respuesta sea valida
while (respuestaTest != ConsoleKey.A && respuestaTest != ConsoleKey.B && respuestaTest != ConsoleKey.C)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nEsa respuesta no es valida. Por favor haz click en las tecla A/B/C");
    Console.ForegroundColor = ConsoleColor.White;
    respuestaTest = Console.ReadKey().Key;
}
Console.Clear();
if (respuestaTest == ConsoleKey.B)
{
    // Respuesta correcta
    puntuacion += 10;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n¡Respuesta correcta! Sumas 10 puntos.");
    Console.ForegroundColor = ConsoleColor.White;
}
else if (respuestaTest == ConsoleKey.A || respuestaTest == ConsoleKey.C)
{
    // Respuesta incorrecta
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nRespuesta incorrecta.\n");
    Console.WriteLine("Rafa Nadal es el máximo ganador del Abierto de Francia con 14 victorias\n");
}

// Mostrar la puntuación actual
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n\nPuntuación actual: " + puntuacion + " puntos");
Console.WriteLine("¡Presiona cualquier tecla para CONTINUAR!");
Console.ReadKey();
Console.Clear();

// Mostrar la CUARTA pregunta
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("PREGUNTA 4: ¿Cómo se llama la protagonista de la saga de videojuegos \"The Legend of Zelda\"?");
respuestaAbierta = Console.ReadLine();

// Verificar si la respuesta es correcta
if (respuestaAbierta == "LINK")
{
    // Actualizar la puntuación
    puntuacion += 10;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n¡Respuesta correcta! Sumas 10 puntos.");
    Console.ForegroundColor = ConsoleColor.White;

}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nRespuesta incorrecta.\n");
    Console.WriteLine("El protagonista de la serie de videojuegos “The Legend of Zelda” se llama Link.\n");
    Console.ForegroundColor = ConsoleColor.White;

}

// Mostrar la puntuación actual
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n\nPuntuación actual: " + puntuacion + " puntos");

Console.WriteLine("¡Presiona cualquier tecla para CONTINUAR!");
Console.ReadKey();

// Limpia la pantalla
Console.Clear();

// Mostrar la QUINTA pregunta
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("PREGUNTA 5: ¿Cuánto duró la Guerra de los Cien Años?");
respuestaAbierta = Console.ReadLine();

// Verificar si la respuesta es correcta
if (respuestaAbierta == "116")
{
    // Actualizar la puntuación
    puntuacion += 10;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n¡Respuesta correcta! Sumas 10 puntos.");
    Console.ForegroundColor = ConsoleColor.White;

}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nRespuesta incorrecta.\n");
    Console.WriteLine("A pesar de que el nombre de esta guerra parece indicar que ocurrió un siglo entre su inicio y su final, en realidad tuvo una duración de 116 años.\n");
    Console.ForegroundColor = ConsoleColor.White;

}

// Mostrar la puntuación actual
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\n\nPuntuación actual: " + puntuacion + " puntos");

Console.WriteLine("¡Presiona cualquier tecla para CONTINUAR!");
Console.ReadKey();

// Limpia la pantalla
Console.Clear();