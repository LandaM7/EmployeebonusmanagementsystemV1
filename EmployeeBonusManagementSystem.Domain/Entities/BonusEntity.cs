﻿using EmployeeBonusManagementSystem.Domain.Common;

namespace EmployeeBonusManagementSystem.Domain.Entities;

public class BonusEntity : BaseEntity
{
    public int EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public bool RecommenderBonus { get; set; }
    public int RecommendationLevel { get; set; }
    public string Reason { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public int CreateByUserId { get; set; }

}
