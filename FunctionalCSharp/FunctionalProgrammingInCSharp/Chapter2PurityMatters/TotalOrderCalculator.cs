namespace FunctionalCSharp.FunctionalProgrammingInCSharp.Chapter2PurityMatters
{
    public static class TotalOrderCalculator
    {
        public static decimal RecomputeTotal(Order order, List<OrderLine> linesToDelete)
        {
            var result = 0m;
            foreach (var line in order.OrderLines)
                if (line.Quantity == 0) linesToDelete.Add(line);
                else
                    result += line.Product.Price * line.Quantity;
            return result;
        }


        public static (decimal total, IEnumerable<OrderLine>lines2delete) RecomputeTotal(Order order) =>
            (order.OrderLines.Sum(l => l.Product.Price * l.Quantity),
                order.OrderLines.Where(l => l.Quantity == 0));
    }

    public class OrderLine

    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }

    public class Product
    {
        public decimal Price { get; set; }
    }

    public class Order
    {
        public List<OrderLine> OrderLines = new();
    }
}