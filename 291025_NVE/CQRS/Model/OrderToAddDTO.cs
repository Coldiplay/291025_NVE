namespace _291025_NVE.CQRS.Model
{
    public class OrderToAddDTO
    {
        public int User_Id { get; set; }
        public List<ItemsToOrder_ToAddOrderDTO> Items { get; set; }
        public ShippingAdress_ToAddOrderDTO ShippingAdress { get; set; }
        public int PaymentMethod_Id { get; set; }

        public UserAdditionalInfo UserAdditionalInfo { get; set; }

    }
}
