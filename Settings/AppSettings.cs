namespace Settings
{
    public class AppSettings
    {
        private static string _defCn = "";

        public static string DefaultConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_defCn))
                    _defCn =
                        "data source=.;initial catalog=AradRealStatedb;integrated security=True;MultipleActiveResultSets=True;";
                return _defCn;
            }
            set => _defCn = value;
        }
    }
}
