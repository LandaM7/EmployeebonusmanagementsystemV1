namespace EmployeeBonusManagementSystem.Application.DTO;

public class RecommenderBonusDto
{
    public required string RecommenderName { get; set; }
    public int TotalRecommendedBonuses { get; set; }
    public decimal TotalBonusAmount { get; set; }
}
