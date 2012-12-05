//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// WorkflowActivity Service class
    /// </summary>
    public partial class WorkflowActivityService : Service<WorkflowActivity, WorkflowActivityDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowActivityService"/> class
        /// </summary>
        public WorkflowActivityService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowActivityService"/> class
        /// </summary>
        public WorkflowActivityService(IRepository<WorkflowActivity> repository) : base(repository)
        {
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        public override WorkflowActivity CreateNew()
        {
            return new WorkflowActivity();
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public override IQueryable<WorkflowActivityDto> QueryableDto( )
        {
            return QueryableDto( this.Queryable() );
        }

        /// <summary>
        /// Query DTO objects
        /// </summary>
        /// <returns>A queryable list of DTO objects</returns>
        public IQueryable<WorkflowActivityDto> QueryableDto( IQueryable<WorkflowActivity> items )
        {
            return items.Select( m => new WorkflowActivityDto()
                {
                    WorkflowId = m.WorkflowId,
                    ActivityTypeId = m.ActivityTypeId,
                    ActivatedDateTime = m.ActivatedDateTime,
                    LastProcessedDateTime = m.LastProcessedDateTime,
                    CompletedDateTime = m.CompletedDateTime,
                    Id = m.Id,
                    Guid = m.Guid,
                });
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( WorkflowActivity item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }
}
