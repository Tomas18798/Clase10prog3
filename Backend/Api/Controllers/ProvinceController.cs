using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvinceController : ControllerBase
{
    private readonly Context _context;

    public ProvinceController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProvinceModel>>> Get(int? countryId)
    {
        Expression<Func<Province, bool>> provincePredicate = x => true;
        if(countryId.HasValue)
        {
            provincePredicate = x => x.CountryId.Equals(countryId.Value);
        }
        var provinces = await _context.Provinces
            .Include(x => x.Country)
            .Where(provincePredicate)
            .Select(x => new ProvinceModel { Id = x.Id, Name = x.Name, CountryName = x.Country.Name })
            .ToListAsync();
        
        return Ok(provinces);
    }

    [HttpPost]
    public async Task<ActionResult<Province>> Create(ProvinceCreateModel province)
    {
        var newProvice = new Province { Name = province.Name, CountryId = province.CountryId };
        _context.Provinces.Add(newProvice);
        await _context.SaveChangesAsync();
        return Ok(newProvice);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var province = await _context.Provinces.SingleOrDefaultAsync(x => x.Id == id);
        if(province == null)
        {
            return NotFound($"No se encontró la province con el id {id}");
        }

        _context.Provinces.Remove(province);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
}