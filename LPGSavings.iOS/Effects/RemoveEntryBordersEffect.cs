using Foundation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: Xamarin.Forms.ResolutionGroupName("LPGSavings.Effects")]
[assembly: Xamarin.Forms.ExportEffect(typeof(LPGSavings.iOS.Effects.RemoveEntryBordersEffect), nameof(LPGSavings.iOS.Effects.RemoveEntryBordersEffect))]
namespace LPGSavings.iOS.Effects
{
    public class RemoveEntryBordersEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var textField = this.Control as UITextField;

            if (textField is null)
                throw new NotImplementedException();

            textField.BorderStyle = UITextBorderStyle.None;
            textField.BackgroundColor = Color.Transparent.ToUIColor();
        }

        protected override void OnDetached()
        {
        }
    }
}