using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core;
using TaskManagement.Service.GenericService;
using System.Data.Entity;
using TaskManagement.Core.DomainEntity;

namespace TaskManagement.Service.DomainService
{
    public interface IIterationOrSprintService : IEntityService<IterationOrSprint>
    {
        Task<IterationOrSprint> GetById(int Id);
    }

    public class IterationOrSprintService : EntityService<IterationOrSprint>, IIterationOrSprintService
    {
        public IterationOrSprintService(IContext context): base(context)
        {
            _dbSet = _context.Set<IterationOrSprint>();
        }
        
        public async Task<IterationOrSprint> GetById(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == Id);
        }

        //public override async Task<IEnumerable<IterationOrSprint>> GetAll()
        //{
        //    return await _context.IterationOrSprints.Include(x => x.LineItems).ToListAsync();
        //}

    }
}
