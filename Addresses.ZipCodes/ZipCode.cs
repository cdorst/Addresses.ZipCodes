// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using DevOps.Code.Entities.Interfaces.StaticEntity;
using Position = ProtoBuf.ProtoMemberAttribute;
using ProtoBufSerializable = ProtoBuf.ProtoContractAttribute;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Addresses.ZipCodes
{
    /// <summary>Contains US ZIP Plus4 component of addresses</summary>
    [ProtoBufSerializable]
    [Table("ZipCodes", Schema = "Addresses")]
    public class ZipCode : IStaticEntity<ZipCode, int>
    {
        public ZipCode()
        {
        }

        public ZipCode(string zip, string plusFour)
        {
            PlusFour = plusFour;
            Zip = zip;
        }

        /// <summary>Contains PlusFour value</summary>
        [Position(2)]
        public string PlusFour { get; set; }

        /// <summary>Contains Zip value</summary>
        [Position(3)]
        public string Zip { get; set; }

        /// <summary>ZipCode unique identifier (primary key)</summary>
        [Key]
        [Position(1)]
        public int ZipCodeId { get; set; }

        /// <summary>Returns a value that uniquely identifies this entity type. Each entity type in the model has a unique identifier</summary>
        public int GetEntityType() => 2;

        /// <summary>Returns the entity's unique identifier</summary>
        public int GetKey() => ZipCodeId;

        /// <summary>Returns an expression defining this entity's unique index (alternate key)</summary>
        public Expression<Func<ZipCode, object>> GetUniqueIndex() => entity => new { entity.PlusFour, entity.Zip };
    }
}
