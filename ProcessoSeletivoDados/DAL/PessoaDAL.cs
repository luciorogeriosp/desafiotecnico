
using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoDataContext.Interfaces;
using ProcessoSeletivoModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivoDataContext.DAL
{
    public class PessoaDAL : IPessoaDAL
    {
        private ProcessoSeletivoContext _context;

        public PessoaDAL(ProcessoSeletivoContext context)
        {
            _context = context;
        }

        public void Add(PessoaModel entity)
        {
            _context.Pessoa.Add(entity);
            _context.SaveChanges();
        }

        public void Update(PessoaModel entity)
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

        public PessoaModel GetById(int Id)
        {
            return _context.Pessoa
                .AsNoTracking()
                .Where(w => w.Id == Id)
                .FirstOrDefault();
        }

        public IQueryable<PessoaModel> Query()
        {
            return _context.Pessoa;
        }

        public IEnumerable<PessoaModel> ListAll()
        {
            return _context.Pessoa
                .AsNoTracking();
        }
    }
}
