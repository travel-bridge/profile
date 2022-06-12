namespace Profile.Domain.Aggregates.ProfileAggregate;

public class Profile : EntityBase<string>, IAggregateRoot
{
    private static readonly ProfileValidator Validator = new();
    
    protected Profile(
        string id,
        string? name,
        string? surname,
        string? description,
        bool isGuide,
        bool isTourist,
        DateTime createDateTimeUtc)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Description = description;
        IsGuide = isGuide;
        IsTourist = isTourist;
        CreateDateTimeUtc = createDateTimeUtc;
    }
    
    public string? Name { get; private set; }
    
    public string? Surname { get; private set; }
    
    public string? Description { get; private set; }
    
    public bool IsGuide { get; private set; }
    
    public bool IsTourist { get; private set; }
    
    public DateTime CreateDateTimeUtc { get; private set; }

    public DateTime? UpdateDateTimeUtc { get; private set; }

    public static Profile Create(
        string id,
        string? name,
        string? surname,
        string? description,
        bool? isGuide,
        bool? isTourist)
    {
        var profile = new Profile(
            id,
            name,
            surname,
            description,
            isGuide ?? false,
            isTourist ?? false,
            DateTime.UtcNow);
        Validator.ValidateEntityAndThrow(profile);
        return profile;
    }

    public void Update(
        Optional<string?> name,
        Optional<string?> surname,
        Optional<string?> description,
        Optional<bool?> isGuide,
        Optional<bool?> isTourist)
    {
        if (name.HasValue)
            Name = name.Value;

        if (surname.HasValue)
            Surname = surname.Value;

        if (description.HasValue)
            Description = description.Value;

        if (isGuide.HasValue && isGuide.Value.HasValue)
            IsGuide = isGuide.Value.Value;

        if (isTourist.HasValue && isTourist.Value.HasValue)
            IsTourist = isTourist.Value.Value;
        
        UpdateDateTimeUtc = DateTime.UtcNow;
        
        Validator.ValidateEntityAndThrow(this);
    }
}