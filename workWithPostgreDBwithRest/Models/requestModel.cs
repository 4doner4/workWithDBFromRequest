namespace workWithPostgreDBwithRest.Models
{
    public class requestModel
    {
        public string IIN { get; set; } = "";
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? MiddleName { get; set; }
        public string? Phone { get; set; }
        public string? Addres { get; set; }
    }
}
