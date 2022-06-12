namespace Profile.Domain.Aggregates;

public record struct Optional<TValue>(TValue? Value, bool HasValue);