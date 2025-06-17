using ContosoPizza.Models;

namespace ContosoPizza.Data;

public static class DbInitializer
{
    public static void Initialize(PizzaContext context)
    {
        if (context.Pizzas.Any() && context.Toppings.Any() && context.Sauces.Any()) return;

        var pepperoni = new Topping { Name = "Pepperoni", Calories = 130 };
        var ham = new Topping { Name = "Ham", Calories = 70 };
        var pineapple = new Topping { Name = "Pineapple", Calories = 75 };
        var chicken = new Topping { Name = "Chicken", Calories = 50 };
        var tomato = new Sauce { Name = "Tomato", IsVegan = true };
        var alfredo = new Sauce { Name = "Alfredo", IsVegan = false };

        var pizzas = new Pizza[]
        {
            new Pizza { Name = "Meat Lovers", Sauce = tomato, Toppings = new List<Topping> { pepperoni, chicken } },
            new Pizza { Name = "Hawaiian", Sauce = tomato, Toppings = new List<Topping> { ham, pineapple } },
            new Pizza { Name = "Alfredo Chicken", Sauce = alfredo, Toppings = new List<Topping> { chicken } }
        };

        context.Pizzas.AddRange(pizzas);
        context.SaveChanges();
    }
}
