namespace Domain.Models.Identity
{
    public class Address
    {

        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;


        public string Country { get; set; } = null!;

        //we will make as relation as one to one 

        public ApplicationUser User { get; set; } = null!;

        public string UserId { get; set; } = null!; //as forign key






    }
}