using Domain.Interfaces;
using Infrastruct.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudyContext _context;
        public UnitOfWork(StudyContext context)
        {
            _context = context;
        }
        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
