namespace KitchenAPI
{
    public class ProductHandler
    {
        public KitchenIO.Objects.Product testProduct()
        {
            KitchenIO.Objects.Product product = new KitchenIO.Objects.Product();
            product.Id = Guid.NewGuid();
            product.name = "test";
            product.barcode = Convert.ToInt32(product.name);
            product.amount = 5;
            product.price = 12.50;
            product.weight = 120;

            return product;
        }
    }
}
