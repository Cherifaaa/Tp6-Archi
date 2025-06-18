namespace PizzaAppBlazor.Data;

public class OrderState
{
    public PizzaOrder CurrentOrder { get; set; } = new();

    public void ResetOrder() => CurrentOrder = new PizzaOrder();
}
