namespace OnlineProductStore.Shared
{
    public class APIEndpoints
    {
        public static string EmailUniqueCheckEndpoind(string email)
        {
            return $"/api/User/unique-user-email?email={email}";
        }
    }
}
