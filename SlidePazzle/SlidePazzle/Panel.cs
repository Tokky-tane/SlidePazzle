using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SlidePazzle
{
    public class Panel : Image
    {
        public int Number { get; set; }

        public static readonly BindableProperty NumberProperty =
            BindableProperty.Create("Position", typeof(int), typeof(Panel), -1, propertyChanged: OnNumberChanged);

        static void OnNumberChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((Panel)bindable).Number = (int)newValue;
        }
    }
}
