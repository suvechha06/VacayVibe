using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VacayVibe.Application.Common.Interfaces;
using VacayVibe.Domain.Entities;
using VacayVibe.Infrastructure.Data;

namespace VacayVibe.Infrastructure.Repository
{
    public class AmenityRepository : Repository<Amenity>, IAmenityRepository
    {
        private readonly ApplicationDbContext _context;
        public AmenityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }   
        public void Update(Amenity entity)
        {
            _context.Amenities.Update(entity);
        }
    }
}
