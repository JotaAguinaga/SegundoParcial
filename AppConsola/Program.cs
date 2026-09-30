using AccesoDatos.Data;
using AccesoDatos.Models;
using AccesoDatos.Repositories;

class Program
{
    static void Main()
    {
        // Se asegura de crear la bd automaticamente si no existe, y si existe no hace nada
        // LO APLIQUE PARA QUE NO HAYA QUE CREAR LA BD MANUALMENTE PORQUE HAY VECES QUE ME GENERA ERROR DE CREACION DE MIGRACIONES Y ME ACOSTUMBRE ASI, LO SAQUE DE LA IA A ESTA SOLUCION
        using var context = new AplicationDbContext();
        context.Database.EnsureCreated();

        var repoArtistas = new GenericRepository<Artista>(context);
        var repoCanciones = new GenericRepository<Cancion>(context);

        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Alta artista");
            Console.WriteLine("2. Alta canción");
            Console.WriteLine("3. Ver canciones");
            Console.WriteLine("4. Mostrar canciones más largas");
            Console.WriteLine("5. Cantidad total de canciones");
            Console.WriteLine("6. Mostrar canciones ordenadas alfabéticamente");
            Console.WriteLine("7. Verificar si existen canciones registradas");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre del artista: ");
                    var nombre = Console.ReadLine();
                    repoArtistas.Agregar(new Artista { Nombre = nombre });
                    break;

                case 2:
                    Console.Write("Título de la canción: ");
                    var titulo = Console.ReadLine();
                    Console.Write("Duración en segundos: ");
                    var duracion = int.Parse(Console.ReadLine());
                    Console.Write("Id del artista: ");
                    var artistaId = int.Parse(Console.ReadLine());
                    repoCanciones.Agregar(new Cancion { Titulo = titulo, DuracionSeg = duracion, ArtistaId = artistaId });
                    break;

                case 3:
                    foreach (var c in repoCanciones.Listar())
                        Console.WriteLine($"{c.Titulo} - {c.DuracionSeg}s");
                    break;

                case 4:
                    var largas = repoCanciones.Listar().OrderByDescending(c => c.DuracionSeg).Take(5);
                    foreach (var c in largas)
                        Console.WriteLine($"{c.Titulo} - {c.DuracionSeg}s");
                    break;

                case 5:
                    Console.WriteLine($"Total canciones: {repoCanciones.Listar().Count}");
                    break;

                case 6:
                    var ordenadas = repoCanciones.Listar().OrderBy(c => c.Titulo);
                    foreach (var c in ordenadas)
                        Console.WriteLine(c.Titulo);
                    break;

                case 7:
                    Console.WriteLine(repoCanciones.Listar().Any() ? "Existen canciones registradas." : "No hay canciones registradas.");
                    break;
            }

        } while (opcion != 0);
    }
}

