﻿using System;
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
            player.Load("cursor7.mp3");
        }

        void OnPanelTapped(object sender, EventArgs eventArgs)
        {
            player.Play();
        }

        void InitializePanel()
        {
            Panel[] panels = new Panel[15];
            var array = Enumerable.Range(0, 15).OrderBy(i => Guid.NewGuid()).ToArray();
        }
	}
}
