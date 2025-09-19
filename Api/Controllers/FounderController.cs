using System.Collections.Generic;
using System.Linq;
using ClientsWebApi_v2.Api.Dto;
using ClientsWebApi_v2.Application.Forms;
using ClientsWebApi_v2.Application.Interfaces.Repositories;
using ClientsWebApi_v2.Application.Interfaces.Services;
using ClientsWebApi_v2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClientsWebApi_v2.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoundersController(IFounderService founderService, IClientRepository clientRepository)
    : ControllerBase
{
    private const int PAGE_SIZE = 10;

    [HttpGet]
    public ActionResult<IEnumerable<FounderOutputDto>> GetAll(int page = 1)
    {
        if (page < 1)
            page = 1;

        return Ok(founderService.GetAll().Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).Select(GetFounderOutputDto));
    }

    [HttpGet("{id:int}")]
    public ActionResult<FounderOutputDto?> Get(int id)
    {
        var founder = founderService.GetById(id);
        return founder == null ? NotFound() : Ok(GetFounderOutputDto(founder));
    }

    [HttpPost]
    public ActionResult<FounderOutputDto> Create([FromBody] FounderInputDto dto)
    {
        var form = new FounderForm(dto.Inn!, dto.FullName!);
        var created = founderService.Create(form, dto.ClientId!.Value);

        return Created(created.Id.ToString(), GetFounderOutputDto(created));
    }

    [HttpPut("{id:int}")]
    public ActionResult<FounderOutputDto> Update(int id, [FromBody] FounderInputDto dto)
    {
        var form = new FounderForm(dto.Inn!, dto.FullName!);
        var updated = founderService.Update(id, form, dto.ClientId!.Value);

        return Ok(GetFounderOutputDto(updated));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return founderService.Delete(id) ? Ok() : NotFound();
    }

    private FounderOutputDto GetFounderOutputDto(Founder founder)
        => new(founder.Id, founder.Inn, founder.FullName, founder.ClientId);
}