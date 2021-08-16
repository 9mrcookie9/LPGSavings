using System;
using LPGSavings.Controls;
using LPGSavings.iOS.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(OutlinedEntry),typeof(OutlinedEntryRenderer))]
namespace LPGSavings.iOS.Controls
{
    public class OutlinedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //Configure Native control (UITextField)
            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
}
