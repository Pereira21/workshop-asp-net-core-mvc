﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService 
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(p => p.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(p => p.Date <= maxDate.Value);
            }

            return await result.Include(x => x.Seller)
                .Include(x => x.Seller.Departamento)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(p => p.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(p => p.Date <= maxDate.Value);
            }

            return await result.Include(x => x.Seller)
                .Include(x => x.Seller.Departamento)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Departamento)
                .ToListAsync();
        }
    }
}
