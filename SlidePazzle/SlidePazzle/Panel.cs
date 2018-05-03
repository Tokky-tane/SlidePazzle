using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SlidePazzle
{
    public class Panel : Image
    {
        public int DefaultPosition { get; private set; }

        public int CurrentPositon { get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        public static readonly BindableProperty DefaultPositionProperty =
            BindableProperty.Create("DefaultPosition", typeof(int), typeof(Panel), 2,propertyChanged: OnDefaultPositionChanged);

        static void OnDefaultPositionChanged(BindableObject bindable,object oldValue,object newValue)
        {
            ((Panel)bindable).DefaultPosition = (int)newValue;
        }

        public int Row
        {
            get
            {
                return (int)((CurrentPositon + 0.2) % 4);
            }
        }

        public int Column
        {
            get
            {
                return (int)((CurrentPositon + 0.2) / 4);
            }
        }
    }
}
