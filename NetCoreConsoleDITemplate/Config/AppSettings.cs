using System.Collections.Generic;

namespace NetCoreConsoleDITemplate
{
    public class AppSettings
    {
        public string KeyA { get; set; }
        public List<KeyValue> ListA { get; set; }
    }
    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}