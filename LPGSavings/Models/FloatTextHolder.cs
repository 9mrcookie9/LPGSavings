namespace LPGSavings.Models
{
    public sealed class FloatTextHolder : NotifyPropertyChanged, ITextValueHolder<float>
    {
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                SetProperty(ref _text, value);
                try
                {
                    Value = float.Parse(value);
                }
                catch
                {
                    Value = 0;
                }
            }
        }

        private float _value;
        public float Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
    }
}
