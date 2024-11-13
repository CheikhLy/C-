using System;
using System.Collections.Generic;
using System.Linq;
using Cours.Core;
using Cours.Models;
using Microsoft.EntityFrameworkCore;

namespace Cours.Repository
{
    public class ClientRepositoryEfImpl : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepositoryEfImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var client = _context.Client.Find(id);
            if (client != null)
            {
                _context.Client.Remove(client);
                _context.SaveChanges();
                Console.WriteLine("Client deleted successfully.");
            }
        }

        public Client? FindBySurnam(string surnam)
        {
              return _context.Client
                .AsNoTracking()
                .FirstOrDefault(c => c.Surnom == surnam);
        }


        public void Insert(Client entity)
        {
            _context.Client.Add(entity);
            _context.SaveChanges();
            Console.WriteLine("Client added successfully.");
        }

        public List<Client> SelectAll()
        {
            return _context.Client
                .AsNoTracking()
                .ToList();
        }

        public Client? SelectById(int id)
        {
            return _context.Client
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public void Update(Client entity)
        {
            _context.Client.Update(entity);
            _context.SaveChanges();
            Console.WriteLine("Client updated successfully.");
        }
    }

}