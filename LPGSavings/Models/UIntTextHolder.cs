namespace LPGSavings.Models
{
    public sealed class UIntTextHolder : NotifyPropertyChanged, ITextValueHolder<uint>
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
                    Value = uint.Parse(value);
                }
                catch
                {

                }
            }
        }

        private uint _value;
        public uint Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }
    }
}
