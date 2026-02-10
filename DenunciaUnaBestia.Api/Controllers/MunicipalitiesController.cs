using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DenunciaUnaBestia.Api.Data;
using DenunciaUnaBestia.Api.Models.Entities;
using DenunciaUnaBestia.Api.Models.Dtos;

namespace DenunciaUnaBestia.Api.Controllers;

[ApiController]
[Route("api/municipalities")]
public class MunicipalitiesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MunicipalitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MunicipalityDto>>> GetAll()
    {
        var municipalities = await _context.Municipalities.ToListAsync();
        var dtos = municipalities.Select(m => new MunicipalityDto
        {
            Id = m.Id,
            Name = m.Name,
            PostalCode = m.PostalCode,
            IsActive = m.IsActive
        }).ToList();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MunicipalityDto>> GetById(int id)
    {
        var municipality = await _context.Municipalities.FindAsync(id);
        if (municipality == null) return NotFound();
        var dto = new MunicipalityDto
        {
            Id = municipality.Id,
            Name = municipality.Name,
            PostalCode = municipality.PostalCode,
            IsActive = municipality.IsActive
        };
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<MunicipalityDto>> Create([FromBody] CreateMunicipalityDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return BadRequest("El nombre del municipio es obligatorio.");

        var entity = new Municipality
        {
            Name = dto.Name,
            PostalCode = dto.PostalCode,
            IsActive = true
        };

        _context.Municipalities.Add(entity);
        await _context.SaveChangesAsync();

        var responseDto = new MunicipalityDto
        {
            Id = entity.Id,
            Name = entity.Name,
            PostalCode = entity.PostalCode,
            IsActive = entity.IsActive
        };

        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, responseDto);
    }
}





