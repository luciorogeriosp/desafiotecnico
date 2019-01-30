using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoDataContext.Interfaces;
using ProcessoSeletivoModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivoDataContext.DAL
{
    public class DistanciaDAL : IDistanciaDAL
    {
        private ProcessoSeletivoContext _context;

        public DistanciaDAL(ProcessoSeletivoContext context)
        {
            _context = context;
        }

        public void Add(DistanciaModel entity)
        {
            _context.Distancia.Add(entity);
            _context.SaveChanges();
        }

        public void Update(DistanciaModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entidade");
            }

            var source = GetById(entity.Id);

            _context.Entry(source).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {

            var source = GetById(Id);

            _context.Remove(source);
            _context.SaveChanges();
        }

        public DistanciaModel GetById(int Id)
        {
            return _context.Distancia
                .AsNoTracking()
                .Where(w => w.Id == Id)
                .FirstOrDefault();
        }

        public IQueryable<DistanciaModel> Query()
        {
            return _context.Distancia;
        }

        public IEnumerable<DistanciaModel> ListAll()
        {
            return _context.Distancia
                .AsNoTracking();
        }
    }
}
