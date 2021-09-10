using System.Collections.Generic;
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

        public static readonly BindableProperty ErrorsProperty = BindableProperty.Create(
            nameof(Errors),
            typeof(List<string>),
            typeof(MaterialEntry),
            default(List<string>),
            BindingMode.TwoWay,
            propertyChanged: (view, oldValue, newValue) => {
                if (view is MaterialEntry entry && newValue is ICollection<string> values)
                {
                    entry.DisplayErrors(values);
                }
            }
        );
        public List<string> Errors
        {
            get => GetValue(ErrorsProperty) as List<string>;
            set => SetValue(ErrorsProperty, value);
        }



        private Entry _entry;
        private Label _header;
        private Grid _grid;
        private Frame _frame;
        private StackLayout _stackLayout;
        public MaterialEntry()
        {
            Margin = new Thickness(20, 5);

            _header = new Label
            {
                FontSize = 15,
                TextColor = (Color)App.Current.Resources["PrimaryColor"],
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(20, -10, 0, 0),
            };
            _entry = new Entry()
            {
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
                Padding = new Thickness(10, 4),
                BorderColor = (Color)App.Current.Resources["PrimaryColor"],
                HasShadow = false,
                Content = _entry,
                CornerRadius = 10,
                BackgroundColor = Color.Transparent
            };
            _grid = new Grid()
            {
                RowSpacing = 0,
                Children = {
                    _frame,
                    _header
                },
                BackgroundColor = Color.Transparent
            };
            _stackLayout = new StackLayout
            {
                Spacing = 0,
                Children = { _grid }
            };
            Content = _stackLayout;

            _frame.SetBinding(Frame.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
            _grid.SetBinding(Grid.BackgroundColorProperty, new Binding(nameof(BackgroundColor), source: this));
        }

        public void DisplayErrors(ICollection<string> errors)
        {
            while(_stackLayout.Children.Count > 1)
            {
                _stackLayout.Children.RemoveAt(1);
            }
            foreach (var error in errors)
            {
                _stackLayout.Children.Add(new Label()
                {
                    Style = (Style)App.Current.Resources["ErrorLabel"],
                    Text = error
                });
            }
        }
    }
}