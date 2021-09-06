using System.Windows.Input;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace LPGSavings.Controls
{
    public sealed class MaterialButtonWithIcon : PancakeView
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
          nameof(Command),
          typeof(ICommand),
          typeof(MaterialButtonWithIcon),
          default(ICommand),
          BindingMode.TwoWay,
           propertyChanged: (view, a, b) =>
           {
               if (view is MaterialButtonWithIcon mtb)
               {
                   TouchEffect.SetCommand(view, mtb.Command);

               }
           }
      );
        public ICommand Command
        {
            get => GetValue(CommandProperty) as ICommand;
            set
            {
                SetValue(CommandProperty, value);
                TouchEffect.SetCommand(this, Command);
            }
        }
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
           nameof(CommandParameter),
           typeof(object),
           typeof(MaterialButtonWithIcon),
           default(object),
           BindingMode.TwoWay,
           propertyChanged: (view, a, b) =>
           {
               if (view is MaterialButtonWithIcon mtb)
               {
                   TouchEffect.SetCommandParameter(view, mtb.CommandParameter);

               }
           }
       );
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set
            {
                SetValue(CommandParameterProperty, value);
                TouchEffect.SetCommandParameter(this, CommandParameter);
            }
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
           nameof(Text),
           typeof(object),
           typeof(MaterialButtonWithIcon),
           default(object),
           BindingMode.TwoWay
       );
        public object Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly BindableProperty IconFontFamilyProperty = BindableProperty.Create(
           nameof(IconFontFamily),
           typeof(string),
           typeof(MaterialButtonWithIcon),
           "fas",
           BindingMode.TwoWay
       );
        public string IconFontFamily
        {
            get => GetValue(IconFontFamilyProperty) as string;
            set => SetValue(IconFontFamilyProperty, value);
        }
        public static readonly BindableProperty IconProperty = BindableProperty.Create(
          nameof(Icon),
          typeof(object),
          typeof(MaterialButtonWithIcon),
          ''.ToString(), // xf054
          BindingMode.TwoWay
      );
        public object Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
          nameof(Color),
          typeof(Color),
          typeof(MaterialButtonWithIcon),
          (Color)App.Current.Resources["PrimaryColorDark"],
          BindingMode.TwoWay
      );
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public MaterialButtonWithIcon()
        {
            var primaryDark = (Color)App.Current.Resources["PrimaryColorDark"];
            CornerRadius = 25;
            Border = new Border()
            {
                Thickness = 1,
                Color = primaryDark
            };
            Padding = new Thickness(14, 8);
            Label buttonText = new Label()
            {
                FontSize = 13,
                TextColor = primaryDark,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold
            };
            Label buttonChevron = new Label()
            {
                FontSize = 15,
                TextColor = primaryDark,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Content = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    buttonText,
                    buttonChevron
                }
            };
            TouchEffect.SetNativeAnimation(this, true);
            buttonChevron.SetBinding(Label.TextProperty, new Binding(nameof(Icon), source: this));
            buttonChevron.SetBinding(Label.FontFamilyProperty, new Binding(nameof(IconFontFamily), source: this));
            buttonChevron.SetBinding(Label.TextColorProperty, new Binding(nameof(Color), source: this));
            Border.SetBinding(Border.ColorProperty, new Binding(nameof(Color), source: this));
            buttonText.SetBinding(Label.TextColorProperty, new Binding(nameof(Color), source: this));
            buttonText.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));
        }
    }
}