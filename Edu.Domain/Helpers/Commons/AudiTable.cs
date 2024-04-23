namespace Edu.Domain.Helpers.Commons;

public class Auditable : Entity
{
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
}
