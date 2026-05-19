using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public double Peso { get; set; }

        [BindProperty]
        public double Altura { get; set; }

        public double IMC { get; set; }
        public string Clasificacion { get; set; }
        public string Recomendacion { get; set; }
        public string Imagen { get; set; }
        public bool ResultadoCalculado { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (Peso <= 0 || Altura <= 0)
            {
                Clasificacion = "Datos inválidos";
                Recomendacion = "Ingresa un peso y una altura válidos.";
                Imagen = "/images/error.png";
                ResultadoCalculado = true;
                return;
            }

            IMC = Peso / (Altura * Altura);

            if (IMC < 18)
            {
                Clasificacion = "Peso Bajo";
                Recomendacion = "Se recomienda mejorar la alimentación y acudir con un especialista.";
                Imagen = "/images/peso-bajo.png";
            }
            else if (IMC < 25)
            {
                Clasificacion = "Peso Normal";
                Recomendacion = "Mantén una alimentación balanceada y realiza actividad física.";
                Imagen = "/images/peso-normal.png";
            }
            else if (IMC < 27)
            {
                Clasificacion = "Sobrepeso";
                Recomendacion = "Se recomienda hacer ejercicio y cuidar la alimentación.";
                Imagen = "/images/sobrepeso.png";
            }
            else if (IMC < 30)
            {
                Clasificacion = "Obesidad grado I";
                Recomendacion = "Es recomendable acudir con un nutriólogo o médico.";
                Imagen = "/images/obesidad1.png";
            }
            else if (IMC < 40)
            {
                Clasificacion = "Obesidad grado II";
                Recomendacion = "Se recomienda atención médica y cambios en el estilo de vida.";
                Imagen = "/images/obesidad2.png";
            }
            else
            {
                Clasificacion = "Obesidad grado III";
                Recomendacion = "Es importante acudir con un especialista de salud.";
                Imagen = "/images/obesidad3.png";
            }

            ResultadoCalculado = true;
        }
    }
}
