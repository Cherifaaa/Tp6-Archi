
namespace PizzaAppBlazor.Data
{
    public class OrderState
    {
        public Order CurrentOrder { get; private set; } = new Order();

        public void AddToOrder(Pizza pizza)
        {
            CurrentOrder.Pizzas.Add(pizza);
        }

        public void ResetOrder()
        {
            CurrentOrder = new Order();
        }
    }

    public class Order
    {
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }

    public class Pizza
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
    }
}
