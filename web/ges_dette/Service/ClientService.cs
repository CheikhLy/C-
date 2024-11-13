using Cours.Models;
using Microsoft.EntityFrameworkCore;

public class ClientService
{
    private readonly ApplicationDbContext _context;

    public ClientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Client> GetAllClients()
    {
        return _context.Client.Include(c => c.Dettes).ToList();
    }
}
