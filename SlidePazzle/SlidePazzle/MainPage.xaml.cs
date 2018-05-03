using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;

namespace SlidePazzle
{
    public partial class MainPage : ContentPage
    {
        ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;
        public MainPage()
        {
            InitializeComponent();
            InitializePanel();
            player.Load("cursor7.mp3");
        }

        void OnPanelTapped(object sender, EventArgs eventArgs)
        {
            player.Play();
        }

        void InitializePanel()
        {
            var panels = new List<Panel>();

            foreach (var panel in grid.Children)
            {
                panels.Add((Panel)panel); 
            }
            panels.OrderBy(i => i.DefaultPosition);

            var sead = Enumerable.Range(0, 15).OrderBy(i => Guid.NewGuid()).ToArray();

            for (int i = 0; i < 15; i++)
            {
                panels[i].Exchange(panels[sead[i]]);
            }
        }
	}
}
