using System;
using Benihime.Models;
using Benihime.Data;
using Microsoft.EntityFrameworkCore;
using Benihime.Interfaces;

namespace Benihime.Repository;

public class RaceRepository : IRaceRepository
{
    private readonly ApplicationDBContext _context;
    public RaceRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public bool Add(Race race)
    {
        _context.Add(race);
        return Save();
    }

    public bool Update(Race race)
    {
        _context.Update(race);
        return Save();
    }

    public bool Delete(Race race)
    {
        _context.Remove(race);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public async Task<IEnumerable<Race>> GetAll()
    {
        return await _context.Races.Include(e => e.Address).ToListAsync();
    }

    public async Task<Race> GetByIdAsync(int id)
    {
        return await _context.Races.Include(e => e.Address).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
    {
        return await _context.Races.Where(e => e.Address.City == city).ToListAsync();
    }
}