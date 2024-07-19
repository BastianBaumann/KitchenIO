namespace KitchenAPI
{
    public class ProductHandler
    {
        public KitchenIO.Objects.Product testProduct()
        {
            KitchenIO.Objects.Product product = new KitchenIO.Objects.Product();
            product.Id = Guid.NewGuid();
            product.name = "test";
            product.barcode = 12345;
            product.amount = 5;
            product.price = 12.50;
            product.weight = 120;

            return product;
        }

        public KitchenIO.Objects.Product testProduct2()
        {
            KitchenIO.Objects.Product product = new KitchenIO.Objects.Product();
            product.Id = Guid.NewGuid();
            product.name = "test2";
            product.barcode = 12345;
            product.amount = 5;
            product.price = 12.50;
            product.weight = 120;

            return product;
        }
    }
}
