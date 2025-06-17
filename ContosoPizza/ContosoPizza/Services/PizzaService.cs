using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PizzaService
{
    private readonly PizzaContext _context;

    public PizzaService(PizzaContext context)
    {
        _context = context;
    }

    public IEnumerable<Pizza> GetAll() =>
        _context.Pizzas.AsNoTracking().ToList();

    public Pizza? GetById(int id) =>
        _context.Pizzas.Include(p => p.Toppings).Include(p => p.Sauce)
        .AsNoTracking().SingleOrDefault(p => p.Id == id);

    public Pizza Create(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        _context.SaveChanges();
        return pizza;
    }

    public void AddTopping(int pizzaId, int toppingId)
    {
        var pizza = _context.Pizzas.Find(pizzaId);
        var topping = _context.Toppings.Find(toppingId);
        if (pizza == null || topping == null) throw new InvalidOperationException("Not found");
        pizza.Toppings ??= new List<Topping>();
        pizza.Toppings.Add(topping);
        _context.SaveChanges();
    }

    public void UpdateSauce(int pizzaId, int sauceId)
    {
        var pizza = _context.Pizzas.Find(pizzaId);
        var sauce = _context.Sauces.Find(sauceId);
        if (pizza == null || sauce == null) throw new InvalidOperationException("Not found");
        pizza.Sauce = sauce;
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var pizza = _context.Pizzas.Find(id);
        if (pizza != null)
        {
            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
        }
    }
}
