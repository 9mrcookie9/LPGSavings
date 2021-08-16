using System;
using Android.Content;
using LPGSavings.Controls;
using LPGSavings.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(OutlinedEntry),typeof(OutlinedEntryRenderer))]
namespace LPGSavings.Droid.Controls
{

    public class OutlinedEntryRenderer : EntryRenderer
    {
        public OutlinedEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //Configure native control (TextBox)
            if (Control != null)
            {
                Control.Background = null;
            }

            // Configure Entry properties
            if (e.NewElement != null)
            {

            }
        }
    }
}
