using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SlidePazzle
{
    public class Panel : Image
    {
        public int CurrentPositon { get; set; }

        public int Row => (int)((CurrentPositon + 0.2) % 4);

        public int Column => (int)((CurrentPositon + 0.2) / 4);



        public int DefaultPosition { get; private set; }

        public static readonly BindableProperty DefaultPositionProperty =
            BindableProperty.Create("DefaultPosition", typeof(int), typeof(Panel), -1, propertyChanged: OnDefaultPositionChanged);

        static void OnDefaultPositionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((Panel)bindable).DefaultPosition = (int)newValue;
        }

        public void Exchange(Panel panel)
        {
            var positionTemp = CurrentPositon;
            var sourceTemp = Source;

            CurrentPositon = panel.CurrentPositon;
            Source = panel.Source;

            panel.CurrentPositon = positionTemp;
            panel.Source = sourceTemp;
        }
    }
}
