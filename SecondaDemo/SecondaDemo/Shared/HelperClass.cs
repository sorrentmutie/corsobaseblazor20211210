using Microsoft.JSInterop;

namespace SecondaDemo.Shared
{
    public class HelperClass
    {
        public string Name { get; set; }

        public HelperClass(string name)
        {
            Name = name; 
        }

        [JSInvokable]
        public string SayHello()
        {
            return $"Hello, {Name}";
        }

    }
}
