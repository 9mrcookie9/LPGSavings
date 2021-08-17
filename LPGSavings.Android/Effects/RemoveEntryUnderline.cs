using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.ResolutionGroupName("LPGSavings.Effects")]
[assembly: Xamarin.Forms.ExportEffect (typeof(LPGSavings.Droid.Effects.RemoveEntryUnderline),nameof(LPGSavings.Droid.Effects.RemoveEntryUnderline))]
namespace LPGSavings.Droid.Effects
{
    public class RemoveEntryUnderline : Xamarin.Forms.Platform.Android.PlatformEffect
    {
        protected override void OnAttached()
        {
            var editText = this.Control as EditText;

            if (editText is null)
                throw new NotImplementedException();

            editText.SetBackgroundColor(Color.Transparent);
        }

        protected override void OnDetached()
        {
        }
    }
}