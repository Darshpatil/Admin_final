using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdminDAL.Entities2;

[Table("EntityTbl")]
public partial class EntityTbl
{
    [Key]
    public string EntityName { get; set; } = null!;

    public string Description { get; set; } = null!;

    [InverseProperty("EntityNameNavigation")]
    public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
}
