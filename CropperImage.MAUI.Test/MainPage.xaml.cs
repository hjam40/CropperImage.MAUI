using System.Diagnostics;
using System.Reflection;

namespace CropperImage.MAUI.Test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            cropper.DefaultImageSource = "https://github.githubassets.com/images/modules/logos_page/GitHub-Mark.png";
        }

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
    }
}