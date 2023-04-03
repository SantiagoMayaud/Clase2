using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace clase2.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    [BindProperty] //Lo que llega de un formulario, si tiene las mismas propiedades, se ingresa
    public Form Data {get; set;}

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var parametro = Request.Query["parametrox"];
        Data = new Form();
        Data.Mail = parametro;
        Data.Password = "12345";
    }

    public IActionResult OnPost(){ //Este código revisa que el pedido de información siga el modelo
        if(!ModelState.IsValid){ //Este código significa "Si el modelo no es correcto"
            return Page();
        }
        // else, guardar en base de datos, procesar información, etc
        var formValues = Data;
        
        return RedirectToAction("Get");
    }
}

