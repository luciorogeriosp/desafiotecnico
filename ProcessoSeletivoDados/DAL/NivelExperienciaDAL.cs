using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoDataContext.Interfaces;
using ProcessoSeletivoModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivoDataContext.DAL
{
    public class NivelExperienciaDAL : INivelExperienciaDAL
    {
        private ProcessoSeletivoContext _context;

        public NivelExperienciaDAL(ProcessoSeletivoContext context)
        {
            _context = context;
        }

        public void Add(NivelExperienciaModel entity)
        {
            _context.NivelExperiencia.Add(entity);
            _context.SaveChanges();
        }

        public void Update(NivelExperienciaModel entity)
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

        public NivelExperienciaModel GetById(int Id)
        {
            return _context.NivelExperiencia
                .AsNoTracking()
                .Where(w => w.Id == Id)
                .FirstOrDefault();
        }

        public IQueryable<NivelExperienciaModel> Query()
        {
            return _context.NivelExperiencia;
        }

        public IEnumerable<NivelExperienciaModel> ListAll()
        {
            return _context.NivelExperiencia
                .AsNoTracking();
        }
    }
}
