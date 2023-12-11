namespace OnlineProductStore.Shared
{
    public class APIEndpoints
    {
        public const string AddNewProductEndpoint = "/api/Products/add-new";
        public const string AddNewCategorytEndpoint = "/api/Categories/add-new";
        public static string EmailUniqueCheckEndpoind(string email)
        {
            return $"/api/User/unique-user-email?email={email}";
        }
    }
}
