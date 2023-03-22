using SkiaSharp.Views.Maui.Controls;
using SkiaSharp.Views.Maui.Controls.Hosting;
using System.Reflection;
using System.Xml;

namespace CropperImage.MAUI;

public static class CropperImageExtensions
{
    public static MauiAppBuilder UseImageCropper(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.UseSkiaSharp();

        return mauiAppBuilder;
    }
}
