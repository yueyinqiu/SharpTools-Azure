﻿using SptlServices.GradedLocalStoraging;
using System.Text.Json.Serialization;

namespace SptlWebsite.Layout;

partial class MainLayout
{
    [JsonSerializable(typeof(int))]
    partial class MainLayoutSerializerContext : JsonSerializerContext { }

    private ILocalStorageEntry<int> NavMenuSizeStorageEntry => 
        this.LocalStorage.GetEntry(
            "MainLayout.NavMenuSize", 1000,
            MainLayoutSerializerContext.Default.Int32);

    private string navMenuSize = "250px";
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if(this.NavMenuSizeStorageEntry.TryGet(out var navMenuSize))
        {
            this.navMenuSize = $"{navMenuSize}px";
            this.StateHasChanged();
        }
    }

    private void SaveNavMenuSize(int navMenuSize)
    {
        this.NavMenuSizeStorageEntry.Set(navMenuSize);
    }
}