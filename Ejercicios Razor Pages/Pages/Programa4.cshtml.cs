using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class Programa4Model : PageModel
    {
        public List<int> Numeros { get; set; } = new();
        public List<int> NumerosOrdenados { get; set; } = new();
        public List<int> Moda { get; set; } = new();

        public int Suma { get; set; }
        public double Promedio { get; set; }
        public double Mediana { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                Numeros.Add(random.Next(0, 101));
            }

            Suma = Numeros.Sum();

            Promedio = Numeros.Average();

            NumerosOrdenados = Numeros.OrderBy(x => x).ToList();

            int maxFrecuencia = Numeros
                .GroupBy(x => x)
                .Max(g => g.Count());

            Moda = Numeros
                .GroupBy(x => x)
                .Where(g => g.Count() == maxFrecuencia)
                .Select(g => g.Key)
                .ToList();

            int mitad = NumerosOrdenados.Count / 2;

            Mediana = (NumerosOrdenados[mitad - 1] + NumerosOrdenados[mitad]) / 2.0;
        }
    }
}
