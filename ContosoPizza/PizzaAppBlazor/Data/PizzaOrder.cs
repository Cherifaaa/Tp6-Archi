namespace PizzaAppBlazor.Data;

public class PizzaOrder
{
    public string CustomerName { get; set; } = "";
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public List<PizzaSpecial> Pizzas { get; set; } = new();
}
