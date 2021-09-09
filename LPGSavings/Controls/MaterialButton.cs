using System.Windows.Input;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace LPGSavings.Controls
{
    public sealed class MaterialButton : PancakeView
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
           nameof(Command),
           typeof(ICommand),
           typeof(MaterialButton),
           default(ICommand),
           BindingMode.TwoWay,
           propertyChanged: (view,a,b) =>
           {
               if(view is MaterialButton mtb)
               {
                   TouchEffect.SetCommand(view, mtb.Command);

               }
           }
       );
        public ICommand Command
        {
            get => GetValue(CommandProperty) as ICommand;
            set {
                SetValue(CommandProperty, value);
                TouchEffect.SetCommand(this, Command);
            }
        }
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
           nameof(CommandParameter),
           typeof(object),
           typeof(MaterialButton),
           default(object),
           BindingMode.TwoWay,
           propertyChanged: (view, a, b) =>
           {
               if (view is MaterialButton mtb)
               {
                   TouchEffect.SetCommandParameter(view, mtb.CommandParameter);

               }
           }
       );
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set {
                SetValue(CommandParameterProperty, value);
                TouchEffect.SetCommandParameter(this, CommandParameter);
            }
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
           nameof(Text),
           typeof(object),
           typeof(MaterialButton),
           default(object),
           BindingMode.TwoWay
       );
        public object Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
          nameof(Color),
          typeof(Color),
          typeof(MaterialButton),
          (Color)App.Current.Resources["PrimaryColorDark"],
          BindingMode.TwoWay
      );
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public MaterialButton()
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
                FontSize = 15,
                TextColor = primaryDark,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold
            };
            Content = buttonText;
            TouchEffect.SetNativeAnimation(this, true);
            Border.SetBinding(Border.ColorProperty, new Binding(nameof(Color), source: this));
            buttonText.SetBinding(Label.TextColorProperty, new Binding(nameof(Color), source: this));
            buttonText.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));
        }
    }
}