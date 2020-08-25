namespace Settings
{
    public class AppSettings
    {
        private static string _defCn = "";

        public static string DefaultConnectionString
        {
            get
            {
                var res = clsRegistery.GetRegistery("BuildingCn");
                _defCn = string.IsNullOrEmpty(res.value)
                    ? "data source=.;initial catalog=AradRealStatedb;integrated security=True;MultipleActiveResultSets=True;"
                    : res.value;


                return _defCn;
            }
            set => _defCn = value;
        }
    }
}
