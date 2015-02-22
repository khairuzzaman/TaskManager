using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.DomainEntity;

namespace TaskManagement.Core
{
    public class TaskManagementDBInitializer : DropCreateDatabaseIfModelChanges<TaskManagementContext>
    {
        protected override void Seed(TaskManagementContext context)
        {

            var iterations = new List<IterationOrSprint>();
            iterations.Add(new IterationOrSprint() { Name = "Iteration1", Scope = "Initial Settings", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(20) });
            iterations.Add(new IterationOrSprint() { Name = "Iteration2", Scope = "Framework Development", StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(20) });

            foreach (var item in iterations)
                context.IterationOrSprints.Add(item);
            context.SaveChanges();
            //var lineItems = new List<LineItem>();
            //lineItems.Add(new LineItem() { Name = "Item 1", Details = "Create Service", DevTime = 2.0f, QATime = 0.0f, Status = LineItemStatus.None, IterationOrSprintId = iterations.FirstOrDefault().Id });
            //lineItems.Add(new LineItem() { Name = "Item 2", Details = "Create Controller", DevTime = 2.0f, QATime = 0.0f, Status = LineItemStatus.None, IterationOrSprintId = iterations.FirstOrDefault().Id });
            //lineItems.Add(new LineItem() { Name = "Item 3", Details = "Create View", DevTime = 2.0f, QATime = 0.0f, Status = LineItemStatus.None, IterationOrSprintId = iterations.FirstOrDefault().Id });
            //lineItems.Add(new LineItem() { Name = "Item 4", Details = "Write OData Service", DevTime = 2.0f, QATime = 0.0f, Status = LineItemStatus.None, IterationOrSprintId = iterations.FirstOrDefault().Id });
            //lineItems.Add(new LineItem() { Name = "Item 5", Details = "Create Unit test", DevTime = 2.0f, QATime = 0.0f, Status = LineItemStatus.None, IterationOrSprintId = iterations.FirstOrDefault().Id });

            //foreach (var item in lineItems)
            //    context.LineItems.Add(item);
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
