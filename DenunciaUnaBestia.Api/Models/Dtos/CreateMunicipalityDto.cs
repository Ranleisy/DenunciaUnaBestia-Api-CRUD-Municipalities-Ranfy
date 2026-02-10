namespace DenunciaUnaBestia.Api.Models.Dtos;

public class CreateMunicipalityDto
{
    public string Name { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
}