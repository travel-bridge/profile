namespace Profile.Application.Responses;

public class ProfileResponse
{
    public string Id { get; init; } = null!;
    
    public string? Name { get; init; }
    
    public string? Surname { get; init; }
    
    public string? Description { get; init; }
    
    public bool IsGuide { get; init; }
    
    public bool IsTourist { get; init; }
}