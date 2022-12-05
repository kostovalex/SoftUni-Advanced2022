namespace CommandPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Bozichka", 1.50m);
            ModifyPrice modifyPrice = new ModifyPrice();

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 1m));
        }
        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
