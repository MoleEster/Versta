using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using VerstaTest.Data.Data;

namespace VerstaTest.ViewModels
{
    public class HomeViewModel : PageModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
