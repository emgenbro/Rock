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
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Data Transfer Object for Activity object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class ActivityDto : IDto, DotLiquid.ILiquidizable
    {
        /// <summary />
        [DataMember]
        public int WorkflowId { get; set; }

        /// <summary />
        [DataMember]
        public int ActivityTypeId { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? ActivatedDateTime { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? LastProcessedDateTime { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? CompletedDateTime { get; set; }

        /// <summary />
        [DataMember]
        public int Id { get; set; }

        /// <summary />
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public ActivityDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="activity"></param>
        public ActivityDto ( WorkflowActivity activity )
        {
            CopyFromModel( activity );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add( "WorkflowId", this.WorkflowId );
            dictionary.Add( "ActivityTypeId", this.ActivityTypeId );
            dictionary.Add( "ActivatedDateTime", this.ActivatedDateTime );
            dictionary.Add( "LastProcessedDateTime", this.LastProcessedDateTime );
            dictionary.Add( "CompletedDateTime", this.CompletedDateTime );
            dictionary.Add( "Id", this.Id );
            dictionary.Add( "Guid", this.Guid );
            return dictionary;
        }

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        public virtual dynamic ToDynamic()
        {
            dynamic expando = new ExpandoObject();
            expando.WorkflowId = this.WorkflowId;
            expando.ActivityTypeId = this.ActivityTypeId;
            expando.ActivatedDateTime = this.ActivatedDateTime;
            expando.LastProcessedDateTime = this.LastProcessedDateTime;
            expando.CompletedDateTime = this.CompletedDateTime;
            expando.Id = this.Id;
            expando.Guid = this.Guid;
            return expando;
        }

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyFromModel( IEntity model )
        {
            if ( model is WorkflowActivity )
            {
                var activity = (WorkflowActivity)model;
                this.WorkflowId = activity.WorkflowId;
                this.ActivityTypeId = activity.ActivityTypeId;
                this.ActivatedDateTime = activity.ActivatedDateTime;
                this.LastProcessedDateTime = activity.LastProcessedDateTime;
                this.CompletedDateTime = activity.CompletedDateTime;
                this.Id = activity.Id;
                this.Guid = activity.Guid;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyToModel ( IEntity model )
        {
            if ( model is WorkflowActivity )
            {
                var activity = (WorkflowActivity)model;
                activity.WorkflowId = this.WorkflowId;
                activity.ActivityTypeId = this.ActivityTypeId;
                activity.ActivatedDateTime = this.ActivatedDateTime;
                activity.LastProcessedDateTime = this.LastProcessedDateTime;
                activity.CompletedDateTime = this.CompletedDateTime;
                activity.Id = this.Id;
                activity.Guid = this.Guid;
            }
        }

        /// <summary>
        /// Converts to liquidizable object for dotLiquid templating
        /// </summary>
        /// <returns></returns>
        public object ToLiquid()
        {
            return this.ToDictionary();
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public static class ActivityDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static WorkflowActivity ToModel( this ActivityDto value )
        {
            WorkflowActivity result = new WorkflowActivity();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<WorkflowActivity> ToModel( this List<ActivityDto> value )
        {
            List<WorkflowActivity> result = new List<WorkflowActivity>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<ActivityDto> ToDto( this List<WorkflowActivity> value )
        {
            List<ActivityDto> result = new List<ActivityDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static ActivityDto ToDto( this WorkflowActivity value )
        {
            return new ActivityDto( value );
        }

    }
}