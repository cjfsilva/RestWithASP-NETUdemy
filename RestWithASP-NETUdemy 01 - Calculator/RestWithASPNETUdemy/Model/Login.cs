using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Model
{
    public class Login
    {
        public long? Id { get; set; }
        public string Logins { get; set; }
        public string AccessKey { get; set; }
    } 
}
