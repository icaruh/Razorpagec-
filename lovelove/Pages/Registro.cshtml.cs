    using Microsoft.AspNetCore.Mvc.RazorPages;
    using FireSharp.Interfaces;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;



namespace lovelove.Pages
{
    public class RegistroModel : PageModel
    {

        private readonly IFirebaseClient _client;
        public RegistroModel(IFirebaseClient client)
        {
            _client = client;
        }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 letras")]
        public string Password { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostSync() //solicitação HTTP POST a pagina
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var userData = new
                {
                    Email = Email,
                    Password = Password
                };

                //Envio de dados ao firebase
                var response = await _client.SetAsync("users/" + Email.Replace(".", ","), userData);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToPage("/login");
                }
            }

            catch (Exception ex) { 
                ModelState.AddModelError(string.Empty, "Error: " + ex.Message);
            }
            return Page();
        }
    }
}