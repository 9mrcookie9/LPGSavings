using LPGSavings.Controls;
using Xamarin.Forms;

namespace LPGSavings.Behaviours
{
    public class DecimalValidationBehavior : Behavior<MaterialEntry>
    {
        protected override void OnAttachedTo(MaterialEntry entry)
        {
            //entry.GetEntry().TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(MaterialEntry entry)
        {
            //entry.GetEntry().TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = decimal.TryParse(args.NewTextValue, out decimal result);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
