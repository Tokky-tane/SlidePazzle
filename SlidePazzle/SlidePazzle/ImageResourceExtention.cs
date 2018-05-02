using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SlidePazzle
{
    [ContentProperty ("Source")]
    class ImageResource : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProovider)
        {
            if (Source == null)
                return null;

            return ImageSource.FromResource(Source);
        }
    }
}
