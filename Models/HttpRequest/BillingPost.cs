namespace Models.HttpRequest
{
    public class BillingPost
    {
        public string CPF { get; set; }
        public DateTime DueDate { get; set; }
        public decimal ChargeAmount { get; set; }
    }
}
