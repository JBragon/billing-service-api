namespace Models.HttpResponse
{
    public class BillingResponse
    {
        public string Id { get; set; }
        public string CPF { get; set; }
        public DateTime DueDate { get; set; }
        public decimal ChargeAmount { get; set; }
    }
}
