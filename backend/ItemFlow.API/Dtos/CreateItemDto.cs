namespace ItemFlow.API.Dtos;

public record CreateItemDto(string Name, string? Description) : ItemBaseDto(Name, Description);
