using Microsoft.JSInterop;

namespace SecondaDemo.Shared
{
    public class MyJavascriptInterop: IDisposable   
    {
        private readonly IJSRuntime jsRuntime;
        private DotNetObjectReference<HelperClass> reference;

        public MyJavascriptInterop(IJSRuntime jsruntime)
        {
            this.jsRuntime = jsruntime;
        }

        public ValueTask<int> MiaPrimaFunzione(int a, int b)
        {
            return jsRuntime.InvokeAsync<int>("miaPrimaFunzione", a, b);
        }

        public ValueTask<int> MiaSecondaFunzione(int a)
        {
            return jsRuntime.InvokeAsync<int>("miaSecondaFunzione", a);
        }

        public Task MiaTerzaFunzione()
        {
             jsRuntime.InvokeVoidAsync("miaTerzaFunzione");
            return Task.CompletedTask;
        }

        public ValueTask<string> CallSayHello(string name)
        {
            var helper = new HelperClass(name);
            reference = DotNetObjectReference.Create(helper);
            return jsRuntime.InvokeAsync<string>("sayHello", reference);
        }

        public void Dispose()
        {
            reference?.Dispose();
        }
    }
}
