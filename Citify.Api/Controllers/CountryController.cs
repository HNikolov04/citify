using Citify.Application.Dtos.Country.Requests;
using Citify.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Citify.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CountryController : ControllerBase
{
    private readonly ICountryService _service;

    public CountryController(ICountryService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _service.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        var result = await _service.GetPagedAsync(page, size);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CountryCreateRequest request)
    {
        var result = await _service.CreateAsync(request);

        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(CountryUpdateRequest request)
    {
        var result = await _service.UpdateAsync(request);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
