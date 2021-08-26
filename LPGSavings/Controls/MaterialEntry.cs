using LPGSavings.Effects;
using Xamarin.Forms;

namespace LPGSavings.Controls
{
    public sealed class MaterialEntry : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(object),
            typeof(MaterialEntry),
            default(object),
            BindingMode.TwoWay
        );
        public object Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(MaterialEntry),
            default(string),
            BindingMode.TwoWay
        );
        public string Placeholder
        {
            get => GetValue(PlaceholderProperty) as string;
            set => SetValue(PlaceholderProperty, value);
        }
        private static Color PrimaryColor = Color.FromHex("#2196F3");
        private Entry _entry;
        private Label _header;
        private Grid _grid;
        private Frame _frame;
        public MaterialEntry()
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
            _entry = new Entry() {
                Effects =
                {
                    new RemoveEntryUnderline()
                }
            };
            _entry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), source: this));
            _header.SetBinding(Label.TextProperty, new Binding(nameof(Placeholder), source: this));
            _header.SetBinding(Label.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
            _frame = new Frame
            {
                Padding = new Thickness(10,4),
                BorderColor = PrimaryColor,
                HasShadow = false,
                Content = _entry,
                CornerRadius = 10
            };
            Content = _grid= new Grid()
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