using ges_dette.Data;
using ges_dette.Models.entities;
using Microsoft.EntityFrameworkCore;

namespace ges_dette.Service
{

    public class ClientService(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public List<Client> GetAllClients()
        {
            return _context.Client.Include(c => c.Dettes).ToList();
        }
    }
}