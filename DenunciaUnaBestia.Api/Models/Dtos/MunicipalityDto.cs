namespace DenunciaUnaBestia.Api.Models.Dtos;

public class MunicipalityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public bool IsActive { get; set; }
}