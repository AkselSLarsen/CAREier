using CAREier.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CAREier.Pages {
    public class DetailedProductModel : PageModel {

        

        DetailedProductModel(IHandler<IProduct> handler) {
            
        }

        public void OnGet(int id) {
            
        }
    }
}