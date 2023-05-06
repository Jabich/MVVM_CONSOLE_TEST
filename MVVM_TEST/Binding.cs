namespace MVVM_TEST
{
    internal class Binding
    {
        public string DataContextPropertyName { get; }

        public Binding(string dataContextPropertyNamev)
        {
           DataContextPropertyName = dataContextPropertyNamev;
        }
    }
}