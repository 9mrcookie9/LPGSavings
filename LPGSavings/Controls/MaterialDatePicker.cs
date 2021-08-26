using LPGSavings.Effects;
using Xamarin.Forms;

namespace LPGSavings.Controls
{
    public sealed class MaterialDatePicker : ContentView
    {
        public static readonly BindableProperty DateProperty = BindableProperty.Create(
            nameof(Date),
            typeof(object),
            typeof(MaterialDatePicker),
            default(object),
            BindingMode.TwoWay
        );
        public object Date
        {
            get => GetValue(DateProperty);

            set => SetValue(DateProperty, value);
        }
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(MaterialDatePicker),
            default(string),
            BindingMode.TwoWay
        );
        public string Placeholder
        {
            get => GetValue(PlaceholderProperty) as string;
            set => SetValue(PlaceholderProperty, value);
        }
        public static readonly BindableProperty FormatProperty = BindableProperty.Create(
            nameof(Format),
            typeof(string),
            typeof(MaterialDatePicker),
            default(string),
            BindingMode.TwoWay
        );
        public string Format
        {
            get => GetValue(FormatProperty) as string;
            set => SetValue(FormatProperty, value);
        }
        private static Color PrimaryColor = Color.FromHex("#2196F3");
        private DatePicker _datePicker;
        private Label _header;
        private Grid _grid;
        private Frame _frame;
        public MaterialDatePicker()
        {
            Margin = new Thickness(20, 5);

            _header = new Label
            {
                FontSize = 15,
                TextColor = PrimaryColor,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(20, -10, 0, 0),
            };
            _datePicker = new DatePicker()
            {
                TextColor = Color.Black,
                Effects =
                {
                    new RemoveEntryUnderline()
                }
            };
            _datePicker.SetBinding(DatePicker.FormatProperty, new Binding(nameof(Format),source: this));
            _datePicker.SetBinding(DatePicker.DateProperty, new Binding(nameof(Date), source: this));
            _header.SetBinding(Label.TextProperty, new Binding(nameof(Placeholder), source: this));
            _header.SetBinding(Label.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
            _frame = new Frame
            {
                Padding = new Thickness(10, 4),
                BorderColor = PrimaryColor,
                HasShadow = false,
                Content = _datePicker,
                CornerRadius = 10
            };
            Content = _grid = new Grid()
            {
                RowSpacing = 0,
                Children = {
                    _frame,
                    _header
                }
            };

            _frame.SetBinding(Frame.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
            _grid.SetBinding(Grid.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
        }
    }
}