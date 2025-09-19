using System.Collections.Generic;
using System.Linq;
using ClientsWebApi_v2.Api.Dto;
using ClientsWebApi_v2.Application.Forms;
using ClientsWebApi_v2.Application.Interfaces.Services;
using ClientsWebApi_v2.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClientsWebApi_v2.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(IClientService clientService)
    : ControllerBase
{
    private const int PAGE_SIZE = 10;

    [HttpGet]
    public ActionResult<IEnumerable<ClientOutputDto>> GetAll(int page = 1)
    {
        if (page < 1)
            page = 1;

        return Ok(clientService.GetAll().Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE).Select(GetClientOutputDto));
    }

    [HttpGet("{id:int}")]
    public ActionResult<ClientOutputDto?> Get(int id)
    {
        var client = clientService.GetById(id);

        return client == null ? NotFound() : Ok(GetClientOutputDto(client));
    }

    [HttpPost]
    public ActionResult<ClientOutputDto> Create([FromBody] ClientInputDto clientDto)
    {
        var form = new ClientForm(clientDto.Inn!, clientDto.Name!, clientDto.Type!.Value,
            clientDto.Founders?.Select(f => new FounderForm(f.Inn!, f.FullName!)));

        var created = clientService.Create(form);

        return Created(created.Id.ToString(), GetClientOutputDto(created));
    }

    [HttpPut("{id:int}")]
    public ActionResult<ClientOutputDto> Update(int id, [FromBody] ClientInputDto clientDto)
    {
        var form = new ClientForm(clientDto.Inn!, clientDto.Name!, clientDto.Type!.Value,
            clientDto.Founders?.Select(f => new FounderForm(f.Inn!, f.FullName!)));

        var updated = clientService.Update(id, form);

        return Ok(GetClientOutputDto(updated));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return clientService.Delete(id) ? Ok() : NotFound();
    }

    private ClientOutputDto GetClientOutputDto(Client client)
        => new(client.Id, client.Inn, client.Name, client.Type,
            client.Founders?.Select(f => new FounderOutputDto(f.Id, f.Inn, f.FullName, f.ClientId)).ToArray());
}