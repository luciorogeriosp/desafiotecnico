using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoDataContext.Interfaces;
using ProcessoSeletivoModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivoDataContext.DAL
{
    public class CandidaturaDAL : ICandidaturaDAL
    {
        private ProcessoSeletivoContext _context;

        public CandidaturaDAL(ProcessoSeletivoContext context)
        {
            _context = context;
        }

        public void Add(CandidaturaModel entity)
        {
            _context.Candidatura.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CandidaturaModel entity)
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

        public CandidaturaModel GetById(int Id)
        {
            return _context.Candidatura
                .AsNoTracking()
                .Where(w => w.Id == Id)
                .FirstOrDefault();
        }

        public IQueryable<CandidaturaModel> Query()
        {
            return _context.Candidatura;
        }

        public IEnumerable<CandidaturaModel> ListAll()
        {
            return _context.Candidatura
                .AsNoTracking();
        }
    }
}
