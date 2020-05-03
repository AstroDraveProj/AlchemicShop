namespace AlchemicShop.WEB.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserRoleId { get; set; }

        public UserRoleViewModel UserRoleViewModel { get; set; }
    }
}