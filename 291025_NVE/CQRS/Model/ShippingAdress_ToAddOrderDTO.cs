namespace _291025_NVE.CQRS.Model
{
    public class ShippingAdress_ToAddOrderDTO
    {
        public string House { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public int PostalCode { get; set; }

        public static explicit operator DB.ShippingAdress(ShippingAdress_ToAddOrderDTO adress) =>
            new DB.ShippingAdress { Street = adress.Street, City = adress.City, PostalCode = adress.PostalCode, House = adress.House };
    }
}
