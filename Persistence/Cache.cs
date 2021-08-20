namespace Persistence
{
    public class Cache
    {
        public static string ConnectionString { get; set; } =
            @"Data Source=.;Initial Catalog=Arad1;Integrated Security=True;Asynchronous Processing=True";
        public static string HardSerial { get; set; }
        public static bool IsSendToServer { get; set; } = false;
        public static string Path { get; set; }
        public static bool IsClient { get; set; } = false;
    }
}
