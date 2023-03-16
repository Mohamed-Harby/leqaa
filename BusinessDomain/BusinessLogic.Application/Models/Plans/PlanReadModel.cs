namespace BusinessLogic.Application.Models.Plans;
public record PlanReadModel(
    Guid Id,
    string Type,
    DateTime CreationDate
) : BaseReadModel(Id, CreationDate);