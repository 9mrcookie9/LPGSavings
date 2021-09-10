using System.ComponentModel;

namespace LPGSavings.Models
{
    public interface ITextValueHolder<T> : INotifyPropertyChanged
    {
        public string Text { get; set; }
        public T Value { get; set; }
    }
}
