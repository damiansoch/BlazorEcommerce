namespace BlazorEcommerce.Client.Shared.HelpersFunctions
{
    public static class Functions
    {
        public static string PriceToFixedString(this decimal price)
        {
            var priceString = price.ToString("0.00");
            return priceString;
        }
    }
}
