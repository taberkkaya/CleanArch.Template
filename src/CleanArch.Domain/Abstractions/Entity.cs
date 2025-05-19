namespace CleanArch.Domain.Abstractions;

public class Entity
{
    public Guid Id { get; set; }

    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public DateTimeOffset CreatedAt { get; set; } = default!;
    public Guid CreatedBy { get; set; } = default!;

    public DateTimeOffset? UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
}
