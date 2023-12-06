using System;
//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdminDAL.Entities;

[Index("EntityName", Name = "IX_Features_EntityName")]
public class Feature
{
    [Key]
    [Column("FeatureID")]
    public int FeatureId { get; set; }

    public string FeatureName { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string FeatureDataType { get; set; } = null!;
     
    public DateTime CreatedAt { get; set; }

    public byte ApprovalStatus { get; set; }

    public string AdminComments { get; set; } = null!;

    [Column("UserName")]
    public string UserName { get; set; }

    public string EntityName { get; set; } = null!;

    [ForeignKey("EntityName")]
    [InverseProperty("Features")] 
    public virtual EntityTbl EntityNameNavigation { get; set; } = null!;
}
