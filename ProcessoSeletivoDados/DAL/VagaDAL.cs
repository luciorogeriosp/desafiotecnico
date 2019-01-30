using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoDataContext.Interfaces;
using ProcessoSeletivoModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivoDataContext.DAL
{
    public class VagaDAL : IVagaDAL
    {
        private ProcessoSeletivoContext _context;

        public VagaDAL(ProcessoSeletivoContext context)
        {
            _context = context;
        }

        public void Add(VagaModel entity)
        {
            _context.Vaga.Add(entity);
            _context.SaveChanges();
        }

        public void Update(VagaModel entity)
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

        public VagaModel GetById(int Id)
        {
            return _context.Vaga
                .AsNoTracking()
                .Where(w => w.Id == Id)
                .FirstOrDefault();
        }

        public IQueryable<VagaModel> Query()
        {
            return _context.Vaga;
        }

        public IEnumerable<VagaModel> ListAll()
        {
            return _context.Vaga
                .AsNoTracking();
        }
    }
}
