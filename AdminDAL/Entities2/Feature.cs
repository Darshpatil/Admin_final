using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdminDAL.Entities2;

[Index("EntityName", Name = "IX_Features_EntityName")]
public partial class Feature
{
    [Key]
    [Column("FeatureID")]
    public int FeatureId { get; set; }

    public string FeatureName { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string FeatureDataType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public byte? ApprovalStatus { get; set; }

    public string? AdminComments { get; set; }

    public string EntityName { get; set; } = null!;

    public string? UserName { get; set; }

    [ForeignKey("EntityName")]
    [InverseProperty("Features")]
    public virtual EntityTbl EntityNameNavigation { get; set; } = null!;
}
