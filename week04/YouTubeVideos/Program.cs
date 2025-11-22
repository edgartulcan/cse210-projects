using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List of videos 
        List<Video> videos = new List<Video>();

        // ---- VIDEO 1 ----
        Video video1 = new Video
        {
            Title = "Aprendiendo C# desde cero",
            Author = "CodeMaster",
            Length = 600
        };

        video1.AddComment(new Comment("Ana", "Excelente explicación, gracias!"));
        video1.AddComment(new Comment("Luis", "Me ayudó mucho este video."));
        video1.AddComment(new Comment("Julia", "¿Harás un tutorial de clases?"));

        videos.Add(video1);

        // ---- VIDEO 2 ----
        Video video2 = new Video
        {
            Title = "Top 10 trucos de Visual Studio",
            Author = "DevWizard",
            Length = 450
        };

        video2.AddComment(new Comment("Carlos", "No conocía el truco #3, genial."));
        video2.AddComment(new Comment("Marta", "Muy útil, gracias."));
        video2.AddComment(new Comment("Pedro", "¡Más contenido así por favor!"));

        videos.Add(video2);

        // ---- VIDEO 3 ----
        Video video3 = new Video
        {
            Title = "Cómo crear una API en .NET",
            Author = "BackendPro",
            Length = 900
        };

        video3.AddComment(new Comment("Diego", "Perfecto para mi proyecto."));
        video3.AddComment(new Comment("Sandra", "Explicado de forma clara."));
        video3.AddComment(new Comment("Roberto", "¿Puedes subir el código?"));

        videos.Add(video3);

        // Mostrar información de cada video
        foreach (var video in videos)
        {
            Console.WriteLine($"\n=================================================");
            Console.WriteLine($"📌 Título: {video.Title}");
            Console.WriteLine($"👤 Autor: {video.Author}");
            Console.WriteLine($"⏱️ Duración: {video.Length} segundos");
            Console.WriteLine($"💬 Comentarios: {video.GetCommentCount()}");

            Console.WriteLine("\n--- Lista de comentarios ---");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"🗣️ {comment.CommenterName}: {comment.Text}");
            }
        }
    }
}
