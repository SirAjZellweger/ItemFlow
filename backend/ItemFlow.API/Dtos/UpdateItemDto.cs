namespace ItemFlow.API.Dtos;

public record UpdateItemDto(string Name, string? Description) : ItemBaseDto(Name, Description);

