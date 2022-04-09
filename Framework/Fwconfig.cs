namespace Framework
{
    public class Fwconfig
    {
        public DriverSettings Driver { get; set; }
        public TestSettings Test { get; set; }
    }

    public class DriverSettings
    {
        public string Browser { get; set; }
        public int Wait { get; set; }
    }

    public class TestSettings
    {
        public string Url { get; set; }
    }
}
