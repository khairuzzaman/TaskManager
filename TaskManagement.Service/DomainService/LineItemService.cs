using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.DomainEntity;
using TaskManagement.Service.GenericService;
using System.Data.Entity;
using TaskManagement.Core;

namespace TaskManagement.Service.DomainService
{
    public interface ILineItemService : IEntityService<LineItem>
    {
        Task<LineItem> GetById(int Id);
    }
    
    public class LineItemService : EntityService<LineItem>, ILineItemService
    {

        public LineItemService(IContext context):base(context)
        {
            //_context = 
            _dbSet = _context.Set<LineItem>();
        }
        public async Task<LineItem> GetById(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
