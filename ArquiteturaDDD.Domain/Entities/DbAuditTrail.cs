using ArquiteturaDDD.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
namespace ArquiteturaDDD.Domain.Entities
{
    [ScaffoldTable(false)]
    public abstract class DbAuditTrail
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DtInc { get; private set; }

        [DataType(DataType.DateTime)]
        public DateTime? DtAlt { get; private set; }

        public StatusDbAuditTrail? StatusDbAuditTrail { get; set; }



    }
}
