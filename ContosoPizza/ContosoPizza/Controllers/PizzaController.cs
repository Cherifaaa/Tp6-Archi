using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Services;
using ContosoPizza.Models;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaService _service;

    public PizzaController(PizzaService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Pizza> GetAll() => _service.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id)
    {
        var pizza = _service.GetById(id);
        return pizza == null ? NotFound() : pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        var created = _service.Create(pizza);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}/addtopping")]
    public IActionResult AddTopping(int id, [FromQuery] int toppingId)
    {
        _service.AddTopping(id, toppingId);
        return NoContent();
    }

    [HttpPut("{id}/updatesauce")]
    public IActionResult UpdateSauce(int id, [FromQuery] int sauceId)
    {
        _service.UpdateSauce(id, sauceId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteById(id);
        return NoContent();
    }
}
