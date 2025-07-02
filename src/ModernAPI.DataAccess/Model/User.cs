namespace ModernAPI.DataAccess.Model
{
    public class User
    {
        public uint Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
