using Library.API.Dtos.ShelfDtos;
using Library.API.Entities;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShelvesController : ControllerBase
{
    private readonly IGenericService<Shelf, GetShelfResponse, CreateShelfRequest, UpdateShelfRequest> _service;

    public ShelvesController(IGenericService<Shelf, GetShelfResponse, CreateShelfRequest, UpdateShelfRequest> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> GetById(string code)
    {
        var result = await _service.GetByIdAsync(code);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShelfRequest dto)
    {
        var result = await _service.CreateAsync(dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{code}")]
    public async Task<IActionResult> Update(string code, [FromBody] UpdateShelfRequest dto)
    {
        var result = await _service.UpdateAsync(new object[] { code }, dto);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpDelete("{code}")]
    public async Task<IActionResult> Delete(string code)
    {
        var result = await _service.DeleteAsync(code);
        return result.Success ? Ok(result) : NotFound(result);
    }
}


