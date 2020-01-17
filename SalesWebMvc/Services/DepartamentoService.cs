using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly SalesWebMvcContext _context;

        public DepartamentoService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(p => p.Name).ToList();
        }
    }
}
