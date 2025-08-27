using System.ComponentModel.DataAnnotations;

namespace ItemFlow.API.Dtos;

public record ItemBaseDto
(
    [Required(ErrorMessage = "Name ist erforderlich.")]
    [StringLength(100, ErrorMessage = "Name darf maximal 100 Zeichen lang sein.")]
    string Name,

    [StringLength(500, ErrorMessage = "Beschreibung darf maximal 500 Zeichen lang sein.")]
    string? Description
);
