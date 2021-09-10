using System;
using LPGSavings.Controls;
using Xamarin.Forms;

namespace LPGSavings.Behaviours
{
    public class InteagerValidationBehavior : Behavior<MaterialEntry>
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
            bool isValid = int.TryParse (args.NewTextValue, out int result);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
