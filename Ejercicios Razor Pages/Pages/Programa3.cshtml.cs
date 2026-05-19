using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class Programa3Model : PageModel
    {
        [BindProperty]
        public int A { get; set; }

        [BindProperty]
        public int B { get; set; }

        [BindProperty]
        public int X { get; set; }

        [BindProperty]
        public int Y { get; set; }

        [BindProperty]
        public int N { get; set; }

        public double Resultado { get; set; }
        public bool Calculado { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Resultado = 0;

            for (int k = 0; k <= N; k++)
            {
                double combinacion = Factorial(N) / (Factorial(k) * Factorial(N - k));
                double termino = combinacion *
                                 Math.Pow(A * X, N - k) *
                                 Math.Pow(B * Y, k);

                Resultado += termino;
            }

            Calculado = true;
        }

        public double Factorial(int numero)
        {
            double factorial = 1;

            for (int i = 1; i <= numero; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
