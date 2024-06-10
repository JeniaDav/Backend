using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string MessageText { get; set; }

        public Message LastMessage { get; set; }

        public async Task OnGetAsync()
        {
            LastMessage = await _context.Messages.OrderByDescending(m => m.Id).FirstOrDefaultAsync();
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!string.IsNullOrEmpty(MessageText))
            {
                var message = new Message { Text = MessageText };
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostLoadAsync()
        {
            LastMessage = await _context.Messages.OrderByDescending(m => m.Id).FirstOrDefaultAsync();
            return Page();
        }
    }
}