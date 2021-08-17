using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace LPGSavings.Effects
{
    public class RemoveEntryBordersEffect : RoutingEffect
    {
        public RemoveEntryBordersEffect()
            : base($"{nameof(LPGSavings)}.{nameof(Effects)}.{nameof(RemoveEntryBordersEffect)}")
        {
        }
    }
}
