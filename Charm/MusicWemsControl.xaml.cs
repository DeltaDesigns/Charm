﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tiger;
using Tiger.Schema.Activity.DESTINY2_BEYONDLIGHT_3402;
using Tiger.Schema.Audio;
using Tiger.Schema.Entity;

namespace Charm;

public partial class MusicWemsControl : UserControl
{
    public MusicWemsControl()
    {
        InitializeComponent();
    }

    private ConcurrentBag<WemItem> GetWemItems(WwiseSound tag)
    {
        var items = new ConcurrentBag<WemItem>();
        Parallel.ForEach(tag.TagData.Wems, wem =>
        {
            items.Add(new WemItem
            {
                Name = wem.Hash,
                Hash = wem.Hash.GetReferenceHash(),
                Duration = wem.Duration,
                Wem = wem,
            });
        });

        return items;
    }

    private void Play_OnClick(object sender, RoutedEventArgs e)
    {
        WemItem item = (WemItem)(sender as Button).DataContext;
        PlayWem(item.Wem);
    }

    public void PlaySound(WwiseSound sound)
    {
        MusicPlayer.SetSound(sound);
        MusicPlayer.Play();
    }

    public void PlayWem(Wem wem)
    {
        if (MusicPlayer.SetWem(wem))
            MusicPlayer.Play();
    }

    public void Load(D2Class_F5458080 res)
    {
        WwiseSound loop = res.MusicLoopSound;
        WemList.ItemsSource = GetWemItems(loop);
    }

    public void Load(List<D2Class_40668080> res)
    {
        var sounds = new ConcurrentBag<WemItem>(
            res.SelectMany(x => GetWemItems(x.GetSound()))
        );

        WemList.ItemsSource = sounds;
    }

    public void Load(List<WwiseSound> res)
    {
        var sounds = new ConcurrentBag<WemItem>(
            res.SelectMany(x => GetWemItems(x))
        );

        WemList.ItemsSource = sounds;
    }

    public async void Load(D2Class_F7458080 res)
    {
        if (res.AmbientMusicSet == null)
            return;
        // ambient_music_set instead of wwise_loop
        MainWindow.Progress.SetProgressStages(res.AmbientMusicSet.TagData.Unk08.Select((x, i) => $"Loading ambient music {i + 1}/{res.AmbientMusicSet.TagData.Unk08.Count}").ToList());

        ConcurrentBag<WemItem> wemItems = new ConcurrentBag<WemItem>();
        await Task.Run(() =>
        {
            Parallel.ForEach(res.AmbientMusicSet.TagData.Unk08, entry =>
            {
                var items = GetWemItems(entry.MusicLoopSound);
                foreach (var wemItem in items)
                {
                    wemItem.Name += $" (Ambient group {entry.MusicLoopSound.Hash})";
                    wemItems.Add(wemItem);
                }
                MainWindow.Progress.CompleteStage();
            });
        });

        WemList.ItemsSource = wemItems;
    }
}

public class WemItem
{
    public string Name { get; set; }
    public string Duration { get; set; }
    public string Hash { get; set; }
    public Wem Wem { get; set; }
}
