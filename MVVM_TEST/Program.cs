using System.Data;
using ConsoleX;

namespace MVVM_TEST
{
    public class Program
    {
        static void Main(string[] args)
        {
            var view = new View(new ViewModel(new Model()));
            view.Show();
        }
    }
}