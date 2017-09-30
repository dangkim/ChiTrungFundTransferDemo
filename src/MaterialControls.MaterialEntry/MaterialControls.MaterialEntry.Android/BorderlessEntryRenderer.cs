using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MaterialControls.MaterialEntry;
using MaterialControls.MaterialEntry.Droid;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]

namespace MaterialControls.MaterialEntry.Droid
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;

                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }
}