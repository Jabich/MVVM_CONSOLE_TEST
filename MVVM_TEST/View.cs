using System.ComponentModel;

namespace MVVM_TEST
{
    public class View 
    {
        public object DataContext { get; }
        private string _text;

        public string Text 
        { 
            get => _text;
            set 
            {
                _text = value;
                Update();
            }
        }

        public View(ViewModel dataContext)
        {
            DataContext = dataContext;
            var binding = new Binding("Time");
            SetBinding(nameof(Text), binding);
        }

        private void SetBinding(string dependencyPropertyName, Binding binding)
        {
            var sourceProperty = DataContext.GetType().GetProperty(binding.DataContextPropertyName);
            var targetProperty = this.GetType().GetProperty(dependencyPropertyName);
            targetProperty.SetValue(this, sourceProperty.GetValue(DataContext));
            if (DataContext is INotifyPropertyChanged notify)
            {
                notify.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == binding.DataContextPropertyName)
                    {
                        var sourceProperty = DataContext.GetType().GetProperty(binding.DataContextPropertyName);
                        var targetProperty = this.GetType().GetProperty(dependencyPropertyName);
                        targetProperty.SetValue(this, sourceProperty.GetValue(DataContext));
                    }
                };
            }
        }

        internal void Show()
        {
            Update();
            Console.ReadLine();
        }

        private void Update()
        {
           Console.Clear();
            foreach(var text in Text)
            {
                Console.ForegroundColor = text == ':' ? ConsoleColor.Red : ConsoleColor.Cyan;
                
                Console.Write(text);
            }
        }
    }
}