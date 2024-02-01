/*
    Proporcionar a los estudiantes una lista de ejercicios que cubran distintas operaciones en listas. 
    Ejemplos de ejercicios pueden incluir:
    Crear una lista y agregar elementos a ella.
    Eliminar elementos específicos de una lista.
    Buscar elementos en una lista y devolver su posición.
    Ordenar una lista utilizando diferentes algoritmos de ordenamiento.
    Invertir el orden de los elementos en una lista.
 */
var vault = new Vault<int>();
//Rellenamos la lista de elementos
Console.WriteLine("Rellenado de la lista:");
for (int i = 0; i < 200; i++)
{
    vault.Add(Random.Shared.Next(i));
}
Console.WriteLine(vault);

//Eliminamos los primeros 3 números
Console.WriteLine("Eliminacion de elementos:");
vault.RemoveRange(0, 3);
Console.WriteLine(vault);

//Buscamos la posicion del varios elementos al azar
Console.WriteLine($"""
                  Busquedas aleatorias
                  1:{vault[Random.Shared.Next(0, 200)]}
                  2:{vault[Random.Shared.Next(0, 200)]}
                  3:{vault[Random.Shared.Next(0, 200)]} 
                  4:{vault[Random.Shared.Next(0, 200)]} 
                  5:{vault[Random.Shared.Next(0, 200)]}
                  """);

//Buscamos elementos específicos en la lista:
Console.WriteLine("Busqueda especifica:");
Console.WriteLine(vault[4]);

//Ordenamos los elementos:
Console.WriteLine("Ordenamiento con linq:");
vault.OrderValuesLinq();
Console.WriteLine(vault);

//Invertimos el order de la lista:
Console.WriteLine("Ordenamiento inverso:");
vault.Reverse();
Console.WriteLine(vault);