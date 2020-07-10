namespace BookingTickets.JWT
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string userEmail, string password);
    }
}