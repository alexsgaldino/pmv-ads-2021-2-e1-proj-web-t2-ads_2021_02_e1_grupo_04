using System.Threading.Tasks;
using JitResidencial.Persistence.Contratos;
using JitResidencial.Persistence.Contextos;

namespace JitResidencial.Persistence
{
    public class GlobalPersist : IGlobalPersist
    {
        private readonly JitResidencialContext _context;
        public GlobalPersist(JitResidencialContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }        
        
    }
}