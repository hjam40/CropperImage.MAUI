# CropperImage.MAUI

An image cropper and portrait library (using SkiaSharp) for .NET MAUI applications.

## CropperImageView

A ContetView control for cropping images with the next properties:

|   | Android  | iOS/Mac  | Windows  |
|---|---|---|---|
| Cropper Figure (circle,square)  |  ✅ | ✅  | ✅  |
| Cropper radius  | ✅  | ✅  | ✅  |
| Croppep image format/quality settings  | ✅  | ✅  | ✅  |
| Photo transform format/quality settings  | ✅  | ✅  | ✅  |
| Edit/show mode  | ✅  | ✅  | ✅  |
| Text title over photo (show mode)  | ✅  | ✅  | ✅  |
| Zoom (with buttons and gestures)  | ✅  | ✅  | ✅  |
| Pick photo customizable  | ✅  | ✅  | ✅  |

### Install and configure CropperImageView

1. Download and Install [CropperImage.MAUI](https://www.nuget.org/packages/CropperImage.MAUI) NuGet package on your application.

1. Initialize the plugin in your `MauiProgram.cs`:

    ```csharp
    // Add the using to the top
    using CropperImage.MAUI;
    
    public static MauiApp CreateMauiApp()
    {
    	var builder = MauiApp.CreateBuilder();
    
    	builder
    		.UseMauiApp<App>()
    		.UseImageCropper(); // Add the use of the plugging
    
    	return builder.Build();
    }
    ```

### Using CropperImageView

In XAML, make sure to add the right XML namespace:

`xmlns:ci="clr-namespace:CropperImage.MAUI;assembly=CropperImage.MAUI"`

Use the control:
```xaml
            <ci:CropperImageView x:Name="cropper" HorizontalOptions="Center" WidthRequest="300" HeightRequest="300" EditMode="True" 
                                 ButtonsColor="White" CropperFigure="Circle" ShowSelectButton="False" SelectSourceOnTap="True"
                                 CroppedImageFormat="PNG" CroppedImageMaxResolution="200,200"
                                 PhotoImageFormat="JPEG" PhotoImageMaxResolution="1920,1080" />


```
Call the crop method and use the result or bind the result properties:
```csharp
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await cropper.CropImage(true);
            MemoryStream ms = new();
            ms.Write(result);
            ms.Position = 0;
            portrait.ImageSource = ImageSource.FromStream(() => ms);
        }
        private async void Button1_Clicked(object sender, EventArgs e)
        {
            await cropper.CropImageAsync(false);
            MemoryStream ms = new();
            ms.Write(cropper.CroppedImageBytes);
            ms.Position = 0;
            portrait.ImageSource = ImageSource.FromStream(() => ms);
        }
```
## PortraitView

A ContentView control for portraits visualization 

Initialize the plugin in your `MauiProgram.cs`:

    ```csharp
    // Add the using to the top
    using CropperImage.MAUI;
    
    public static MauiApp CreateMauiApp()
    {
    	var builder = MauiApp.CreateBuilder();
    
    	builder
    		.UseMauiApp<App>()
    		.UseImageCropper(); // Add the use of the plugging
    
    	return builder.Build();
    }
    ```
In XAML, make sure to add the right XML namespace:

`xmlns:ci="clr-namespace:CropperImage.MAUI;assembly=CropperImage.MAUI"`

Use the control and its bindable properties:
```xaml
            <ci:PortraitView BindingContext="{x:Reference cropper}" ImageSource="{Binding CroppedImage}" 
                         WidthRequest="90" HeightRequest="90" Text="PR" FontSize="40" Fill="blue" TextColor="White" Stroke="orange">
                <ci:PortraitView.StrokeShape>
                    <RoundRectangle CornerRadius="30,0,0,30" />
                </ci:PortraitView.StrokeShape>
            </ci:PortraitView>
<ci:PortraitView x:Name="portrait" WidthRequest="90" HeightRequest="90" Text="HA" FontSize="40"/>
```
Set the ImageSource property to replace text by the image:
```csharp
        private async void Button1_Clicked(object sender, EventArgs e)
        {
            await cropper.CropImageAsync(false);
            MemoryStream ms = new();
            ms.Write(cropper.CroppedImageBytes);
            ms.Position = 0;
            portrait.ImageSource = ImageSource.FromStream(() => ms);
        }

```