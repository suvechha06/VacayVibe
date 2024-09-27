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
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _context;
        public VillaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }   
        public void Update(Villa entity)
        {
            _context.Villas.Update(entity);
        }
    }
}
