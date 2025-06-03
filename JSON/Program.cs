using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace JSON
{
    public class Person
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Age")]
        public int Age { get; set; }

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Luis\source\repos\JSON\JSON\bin\Debug";
            string jsonString = "";
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El archivo '{filePath}' no se encontro");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return;
            }
            try
            {
                Person person = JsonSerializer.Deserialize<Person>(jsonString);

                //3.Imprimir los valores del objeto
                Console.WriteLine($"Nombre: {person.FirstName}");
                Console.WriteLine($"Apellido: {person.LastName}");
                Console.WriteLine($"Edad: {person.Age}");
                Console.ReadKey();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error de deserializacion:{ex.Message}");

            }

        }
    }
}
