namespace WebApp1.Models
{
    public static class CustomerContext
    {
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer{Id = 1,FirstName = "Ahmet",LastName = "Ahmetoglu",Age = 34},
            new Customer{Id = 2,FirstName = "Murat",LastName = "Demir",Age = 60},
            new Customer{Id = 3,FirstName = "Cengiz",LastName = "Cemal",Age = 24}
        };
    }
}
