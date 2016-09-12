//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;


namespace Rock.Client
{
    /// <summary>
    /// Base client model for BackgroundCheck that only includes the non-virtual fields. Use this for PUT/POSTs
    /// </summary>
    public partial class BackgroundCheckEntity
    {
        /// <summary />
        public int Id { get; set; }

        /// <summary />
        public Guid? ForeignGuid { get; set; }

        /// <summary />
        public string ForeignKey { get; set; }

        /// <summary />
        public int PersonAliasId { get; set; }

        /// <summary />
        public bool? RecordFound { get; set; }

        /// <summary />
        public DateTime RequestDate { get; set; }

        /// <summary />
        public DateTime? ResponseDate { get; set; }

        /// <summary />
        public int? ResponseDocumentId { get; set; }

        /// <summary />
        public string ResponseXml { get; set; }

        /// <summary />
        public int? WorkflowId { get; set; }

        /// <summary />
        public DateTime? CreatedDateTime { get; set; }

        /// <summary />
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary />
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary />
        public int? ModifiedByPersonAliasId { get; set; }

        /// <summary />
        public Guid Guid { get; set; }

        /// <summary />
        public int? ForeignId { get; set; }

        /// <summary>
        /// Copies the base properties from a source BackgroundCheck object
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyPropertiesFrom( BackgroundCheck source )
        {
            this.Id = source.Id;
            this.ForeignGuid = source.ForeignGuid;
            this.ForeignKey = source.ForeignKey;
            this.PersonAliasId = source.PersonAliasId;
            this.RecordFound = source.RecordFound;
            this.RequestDate = source.RequestDate;
            this.ResponseDate = source.ResponseDate;
            this.ResponseDocumentId = source.ResponseDocumentId;
            this.ResponseXml = source.ResponseXml;
            this.WorkflowId = source.WorkflowId;
            this.CreatedDateTime = source.CreatedDateTime;
            this.ModifiedDateTime = source.ModifiedDateTime;
            this.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            this.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            this.Guid = source.Guid;
            this.ForeignId = source.ForeignId;

        }
    }

    /// <summary>
    /// Client model for BackgroundCheck that includes all the fields that are available for GETs. Use this for GETs (use BackgroundCheckEntity for POST/PUTs)
    /// </summary>
    public partial class BackgroundCheck : BackgroundCheckEntity
    {
    }
}
