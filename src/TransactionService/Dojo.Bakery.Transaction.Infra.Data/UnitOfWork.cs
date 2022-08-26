using Dojo.Bakery.BuildingBlocks.Commons.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Dojo.Bakery.Transaction.Infra.Data
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, IDisposable
    {
        private readonly ILogger<UnitOfWork<TContext>> _logger;
        private readonly IMediator _mediator;
        public UnitOfWork(TContext context, IMediator mediator, ILogger<UnitOfWork<TContext>> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }
        public TContext Context { get; }
        public async Task CommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"{nameof(UnitOfWork<TContext>)}: Error trying to update database on commit async: {ex.Message}, {ex.StackTrace} at {DateTime.Now}");
                StringBuilder error = new StringBuilder(ex.Message);
                try
                {
                    foreach (EntityEntry entry in ex.Entries)
                    {
                        error.AppendFormat("- Type: {0} was part of the problem, State:{1}. ",
                            entry.Entity.GetType().Name, entry.State);
                    }
                }
                catch (Exception e)
                {
                    error.Append("- Error parsing DbUpdateException: " + e.ToString());
                }
                throw new Exception(error.ToString(), ex);
            }
        }
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}

