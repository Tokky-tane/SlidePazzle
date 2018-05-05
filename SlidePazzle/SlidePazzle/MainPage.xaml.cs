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
        List<Panel> panels = new List<Panel>();
        ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;
        public MainPage()
        {
            InitializeComponent();
            InitializePanel();
            player.Load("cursor7.mp3");
        }

        void InitializePanel()
        {
            foreach (var panel in grid.Children)
            {
                panels.Add((Panel)panel);
            }
            panels = panels.OrderBy(i => i.Number).ToList();

            SetGrid(GetSead());
        }

        void Restart()
        {
            SetGrid(GetSead());
        }

        int[] GetSead()
        {
            int[] sead;
            do
            {
                sead = Enumerable.Range(0, 15).OrderBy(i => Guid.NewGuid()).ToArray();
            } while (!IsOposite(sead.ToArray()));

            return sead;
        }

        void SetGrid(int[] sead)
        {
            for (int i = 0; i < 15; i++)
            {
                var temp = panels[i];
                panels[i] = panels[sead[i]];
                panels[sead[i]] = temp;
            }

            grid.Children.Clear();

            grid.Children.Add(panels[0], 0, 0);
            for (int i = 1; i < 16; i++)
            {
                grid.Children.Add(panels[i], i % 4, i / 4);
            }
        }



        bool IsOposite(int[] sead)
        {
            var seadLength = sead.Length;
            int count = 0;

            for (int i = 0; i < seadLength - 1; i++)
            {
                for (int j = i + 1; j < seadLength; j++)
                {
                    if (i == sead[j])
                    {
                        int temp = sead[i];
                        sead[i] = sead[j];
                        sead[j] = temp;
                        count++;
                    }
                }
            }

            if ((count + 2) % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IsClear()
        {
            var numbers = panels.Select(x => x.Number);
            var y = Enumerable.Range(0, 16);

            if (numbers == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool CanMove(Panel tappedPanel)
        {
            var emptyLocate = panels.FindIndex(x => x.Number == 15);
            var tappedLocate = panels.FindIndex(x => x == tappedPanel);

            var RowSub = GetRow(emptyLocate) - GetRow(tappedLocate);
            var ColumnSub = GetColumn(emptyLocate) - GetColumn(tappedLocate);

            if ((Math.Abs(RowSub + ColumnSub) == 1) && (RowSub == 0 || ColumnSub == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int GetRow(int locate)
        {
            return (int)((locate + 0.2) % 4);
        }

        int GetColumn(int locate)
        {
            return (int)((locate + 0.2) / 4);
        }

        void OnPanelTapped(object sender, EventArgs eventArgs)
        {
            if (CanMove((Panel)sender))
            {
                player.Play();
            }
        }
	}
}
