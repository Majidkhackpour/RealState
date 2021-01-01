namespace Persistence
{
    public class Cache
    {
        public static string ConnectionString { get; set; } =
            @"Data Source=.;Initial Catalog=Arad1;Integrated Security=True;Asynchronous Processing=True";
        public static string HardSerial { get; set; }
    }
}
