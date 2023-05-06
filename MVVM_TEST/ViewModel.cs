using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_TEST
{
    public class ViewModel: INotifyPropertyChanged
    {
        public string _time;
        public string Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }
        public ViewModel(Model model)
        {
            Time = "00:00:00";
            model.TimeChanged += ModelOnTimeChanged;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        private void ModelOnTimeChanged(DateTime obj)
        {
            Time = obj.ToLongTimeString();
        }
    }
}