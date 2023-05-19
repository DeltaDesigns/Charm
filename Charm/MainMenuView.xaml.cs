﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using Field;
using Field.Entities;
using Field.General;
using Field.Models;
using Internal.Fbx;
using SharpDX.Toolkit.Graphics;

namespace Charm;

public partial class MainMenuView : UserControl
{
    private static MainWindow _mainWindow = null;
    public string GameVersion { get; set; }

    public MainMenuView()
    {
        InitializeComponent();
    }

    private void OnControlLoaded(object sender, RoutedEventArgs routedEventArgs)
    {
        _mainWindow = Window.GetWindow(this) as MainWindow;
        DataContext = this;
        if(ConfigHandler.GetPackagesPath() != "" && File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/paths.cache"))
        {
            GameVersion = $"Game Version:\n{_mainWindow.CheckGameVersion()}";
            LoadTexture(new TextureHeader(new Field.General.TagHash("E154AE80")));
        }
    }

    private void ApiViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        // TagListViewerView apiView = new TagListViewerView();
        // apiView.LoadContent(ETagListType.ApiList);
        DareView apiView = new DareView();
        apiView.LoadContent();
        _mainWindow.MakeNewTab("api", apiView);
        _mainWindow.SetNewestTabSelected();
    }
    
    private void NamedEntitiesBagsViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.DestinationGlobalTagBagList);
        _mainWindow.MakeNewTab("destination global tag bag", tagListView);
        _mainWindow.SetNewestTabSelected();
    }
    
    private void AllEntitiesViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.EntityList);
        _mainWindow.MakeNewTab("dynamics", tagListView);
        _mainWindow.SetNewestTabSelected();
    }

    private void ActivitiesViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.ActivityList);
        _mainWindow.MakeNewTab("activities", tagListView);
        _mainWindow.SetNewestTabSelected();
    }

    private void AllStaticsViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.StaticsList);
        _mainWindow.MakeNewTab("statics", tagListView);
        _mainWindow.SetNewestTabSelected();    
    }

    private void WeaponAudioViewButton_Click(object sender, RoutedEventArgs e)
    {
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.WeaponAudioGroupList);
        _mainWindow.MakeNewTab("weapon audio", tagListView);
        _mainWindow.SetNewestTabSelected();    
    }

    private void AllAudioViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.SoundsPackagesList);
        _mainWindow.MakeNewTab("sounds", tagListView);
        _mainWindow.SetNewestTabSelected();    
    }

    private void AllStringsViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.StringContainersList);
        _mainWindow.MakeNewTab("strings", tagListView);
        _mainWindow.SetNewestTabSelected();      
    }

    private void AllTexturesViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.TextureList);
        _mainWindow.MakeNewTab("textures", tagListView);
        _mainWindow.SetNewestTabSelected();
    }

    private void GithubButton_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Not available in unofficial/experimental version");
        //Process.Start(new ProcessStartInfo { FileName = "https://github.com/MontagueM/Charm", UseShellExecute = true });
    }

    private void DiscordButton_OnClick(object sender, RoutedEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = "https://discord.com/invite/destinymodelrips", UseShellExecute = true });
    }

    private void MainMenuImage_OnClick(object sender, RoutedEventArgs e)
    {
        if (MainMenuImage.IsChecked == true)
            LoadTexture(new TextureHeader(new Field.General.TagHash("EB5AAE80"))); //9E20A080 WQ logo
        else
            LoadTexture(new TextureHeader(new Field.General.TagHash("E154AE80"))); //6A20A080 destiny logo, EB5AAE80
    }

    public void LoadTexture(TextureHeader textureHeader)
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
        Image.Source = bitmapImage;
        Image.Width = 160;
        Image.Height = 160;
    }

    private void AllCinematicsViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("ANIMATIONS ARE SUPER WIP!\nTHINGS CAN AND WILL BREAK/CRASH/NOT WORK!");
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.CinematicAnimationList);
        _mainWindow.MakeNewTab("Cinematic Animations", tagListView);
        _mainWindow.SetNewestTabSelected();
    }

    private void AnimationsButton_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("ANIMATIONS ARE SUPER WIP!\nTHINGS CAN AND WILL BREAK/CRASH/NOT WORK!\nsr_cinematics pkgs are the most reliable\n\"Compressed: True\" animations will crash");
        TagListViewerView tagListView = new TagListViewerView();
        tagListView.LoadContent(ETagListType.AnimationPackageList);
        _mainWindow.MakeNewTab("animations", tagListView);
        _mainWindow.SetNewestTabSelected();
    }
}