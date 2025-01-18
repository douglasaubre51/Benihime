using System;
using Benihime.Data;
using Benihime.Interfaces;
using Benihime.Models;
using Microsoft.EntityFrameworkCore;

namespace Benihime.Repository;

public class ClubRepository : IClubRepository
{
    private readonly ApplicationDBContext _context;
    public ClubRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public bool Add(Club club)
    {
        _context.Add(club);
        return Save();
    }

    public bool Update(Club club)
    {
        _context.Update(club);
        return Save();
    }

    public bool Delete(Club club)
    {
        _context.Remove(club);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public async Task<IEnumerable<Club>> GetAll()
    {
        return await _context.Clubs.Include(e => e.Address).ToListAsync();
    }

    public async Task<Club> GetByIdAsync(int id)
    {
        return await _context.Clubs.Include(e => e.Address).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Club>> GetClubByCity(string city)
    {
        return await _context.Clubs.Include(e => e.Address).Where(e => e.Address.City == city).ToListAsync();
    }
}