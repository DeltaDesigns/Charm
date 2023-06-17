﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Field;
using Field.General;

namespace Charm;

public partial class ActivityPatrolView : UserControl
{
    public TextureHeader PatrolIcon = null;
    public ActivityPatrolView()
    {
        InitializeComponent();
    }

    public void LoadUI(Activity activity)
    {
        if (activity.Header.Unk20.Header.Patrols is null)
            return;

        var tag = PackageHandler.GetTag<D2Class_75988080>(activity.Header.Unk20.Header.Patrols.Hash);
        if (tag.Header.PatrolTable is not null)
        {
            ListView.ItemsSource = GetPatrolItems(tag.Header.PatrolTable?.Header.Unk28);
            PatrolTablePath.Text = $"{activity.Header.Unk20.Header.LocationName}: {tag.Header.PatrolTablePath}";
        }
    }

    public List<PatrolItem> GetPatrolItems(List<D2Class_B4418080> patrolTable)
    {
        // List to maintain order of patrols
        var items = new List<PatrolItem>();

        foreach (var patrol in patrolTable)
        {
            if (patrol.Unk50.Header.UnkC.Header.Unk08[0].Unk04.Header.Unk10 is D2Class_CD3E8080 a) //Probably a better way of doing this
            {
                PatrolIcon = a.Unk00[0].TextureList[0].IconTexture;
            }
            else if (patrol.Unk50.Header.UnkC.Header.Unk08[0].Unk04.Header.Unk10 is D2Class_CB3E8080 b)
            {
                PatrolIcon = b.Unk00[0].TextureList[0].IconTexture;
            }

            items.Add(new PatrolItem
            {
                Name = patrol.PatrolNameString,
                Description = patrol.PatrolDescriptionString,
                Objective = $"{patrol.PatrolObjectiveString} 0/{patrol.Unk148}",
                Hash = patrol.PatrolHash,
                DialogueHash = (patrol.DialogueTable is null ? "No Dialogue" : patrol.DialogueTable.Hash),
                Icon = LoadTexture(PatrolIcon)
            });
        }

        return items;
    }

    public async void LoadPatrolDialogue(object sender, RoutedEventArgs e)
    {
        var s = sender as Button;
        var dc = s.DataContext as PatrolItem;

        if(dc.DialogueHash != "No Dialogue")
        {
            var tagHash = new TagHash(dc.DialogueHash);
            MainWindow.Progress.SetProgressStages(new List<string> { $"Loading Dialogue {tagHash}" });
            await Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    DialogueControl.Load(tagHash);
                    MainWindow.Progress.CompleteStage();
                });
            });
        }
    }

    public BitmapImage LoadTexture(TextureHeader textureHeader)
    {
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = textureHeader.GetTexture();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        // Divide aspect ratio to fit 960x1000
        float widthDivisionRatio = (float)textureHeader.Header.Width / 960;
        float heightDivisionRatio = (float)textureHeader.Header.Height / 1000;
        float transformRatio = Math.Max(heightDivisionRatio, widthDivisionRatio);
        int imgWidth = (int)Math.Floor(textureHeader.Header.Width / transformRatio);
        int imgHeight = (int)Math.Floor(textureHeader.Header.Height / transformRatio);
        bitmapImage.DecodePixelWidth = imgWidth;
        bitmapImage.DecodePixelHeight = imgHeight;
        bitmapImage.EndInit();
        bitmapImage.Freeze();
        return bitmapImage;
    }
}

public class PatrolItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Objective { get; set; }

    public string Hash { get; set; }
    public string DialogueHash { get; set; }

    public BitmapImage Icon { get; set; }
}