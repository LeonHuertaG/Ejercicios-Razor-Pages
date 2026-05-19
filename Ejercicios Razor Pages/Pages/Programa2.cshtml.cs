using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class Programa2Model : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; }

        [BindProperty]
        public int N { get; set; }

        public string Resultado { get; set; }
        public string TipoOperacion { get; set; }
        public void OnGet()
        {
        }
        public void OnPost(string accion)
        {
            if (accion == "codificar")
            {
                Resultado = ProcesarMensaje(Mensaje, N);
                TipoOperacion = "Mensaje codificado";
            }
            else if (accion == "decodificar")
            {
                Resultado = ProcesarMensaje(Mensaje, -N);
                TipoOperacion = "Mensaje decodificado";
            }
        }

        public string ProcesarMensaje(string mensaje, int desplazamiento)
        {
            string resultado = "";

            foreach (char letra in mensaje.ToUpper())
            {
                if (letra >= 'A' && letra <= 'Z')
                {
                    int posicion = letra - 'A';
                    int nuevaPosicion = (posicion + desplazamiento) % 26;

                    if (nuevaPosicion < 0)
                        nuevaPosicion += 26;

                    resultado += (char)('A' + nuevaPosicion);
                }
                else
                {
                    resultado += letra;
                }
            }

            return resultado;
        }

    }
}
