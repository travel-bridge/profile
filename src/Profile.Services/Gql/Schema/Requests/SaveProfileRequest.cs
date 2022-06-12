namespace Profile.Services.Gql.Schema.Requests;

public class SaveProfileRequest
{
    public Optional<string?> Name { get; init; }
    
    public Optional<string?> Surname { get; init; }
    
    public Optional<string?> Description { get; init; }
    
    public Optional<bool?> IsGuide { get; init; }
    
    public Optional<bool?> IsTourist { get; init; }
}