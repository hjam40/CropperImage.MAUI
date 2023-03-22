using SkiaSharp.Views.Maui;
using SkiaSharp;
using Microsoft.Maui.Controls.Shapes;

namespace CropperImage.MAUI;

public partial class CropperImageView : ContentView
{
    //Default buttons data
    private const string PLUSBUTTONDATA = "M12 6C12.5523 6 13 6.44772 13 7V11H17C17.5523 11 18 11.4477 18 12C18 12.5523 17.5523 13 17 13H13V17C13 17.5523 12.5523 18 12 18C11.4477 18 11 17.5523 11 17V13H7C6.44772 13 6 12.5523 6 12C6 11.4477 6.44772 11 7 11H11V7C11 6.44772 11.4477 6 12 6Z M1 12C1 5.92487 5.92487 1 12 1C18.0751 1 23 5.92487 23 12C23 18.0751 18.0751 23 12 23C5.92487 23 1 18.0751 1 12ZM12 3C7.02944 3 3 7.02944 3 12C3 16.9706 7.02944 21 12 21C16.9706 21 21 16.9706 21 12C21 7.02944 16.9706 3 12 3Z";
    private const string LESSBUTTONDATA = "M7 11C6.44772 11 6 11.4477 6 12C6 12.5523 6.44772 13 7 13H17C17.5523 13 18 12.5523 18 12C18 11.4477 17.5523 11 17 11H7Z M12 1C5.92487 1 1 5.92487 1 12C1 18.0751 5.92487 23 12 23C18.0751 23 23 18.0751 23 12C23 5.92487 18.0751 1 12 1ZM3 12C3 7.02944 7.02944 3 12 3C16.9706 3 21 7.02944 21 12C21 16.9706 16.9706 21 12 21C7.02944 21 3 16.9706 3 12Z";
    private const string PICKBUTTONDATA = "M9.15023 3.01742C9.13605 3.03985 9.12278 3.0676 9.11298 3.09958C9.11044 3.10789 9.10778 3.11617 9.10502 3.12442L8.36963 5.31787C8.23301 5.72537 7.85129 6 7.4215 6H3C2.44772 6 2 6.44772 2 7V20C2 20.5523 2.44771 21 3 21H21C21.5523 21 22 20.5523 22 20V7C22 6.44771 21.5523 6 21 6H16.331C15.9011 6 15.5194 5.72528 15.3828 5.31769L14.6479 3.12423C14.6452 3.11605 14.6425 3.10783 14.64 3.09958C14.6302 3.0676 14.6169 3.03985 14.6027 3.01742C14.5986 3.01089 14.5946 3.00509 14.5908 3H9.16221C9.1584 3.00509 9.15437 3.01089 9.15023 3.01742ZM7.20525 2.49911C7.43535 1.76672 8.10563 1 9.06392 1H14.6891C15.6474 1 16.3177 1.76679 16.5478 2.49922L17.0506 4H21C22.6569 4 24 5.34315 24 7V20C24 21.6569 22.6569 23 21 23H3C1.34315 23 0 21.6569 0 20V7C0 5.34315 1.34315 4 3 4H6.70206L7.20525 2.49911ZM7 13C7 10.2386 9.23858 8 12 8C14.7614 8 17 10.2386 17 13C17 15.7614 14.7614 18 12 18C9.23858 18 7 15.7614 7 13ZM12 10C10.3431 10 9 11.3431 9 13C9 14.6569 10.3431 16 12 16C13.6569 16 15 14.6569 15 13C15 11.3431 13.6569 10 12 10Z";
    private const string SELECTBUTTONDATA = "M9.15023 3.01742C9.13605 3.03985 9.12278 3.0676 9.11298 3.09958C9.11044 3.10789 9.10778 3.11617 9.10502 3.12442L8.36963 5.31787C8.23301 5.72537 7.85129 6 7.4215 6H3C2.44772 6 2 6.44772 2 7V20C2 20.5523 2.44771 21 3 21H21C21.5523 21 22 20.5523 22 20V7C22 6.44771 21.5523 6 21 6H16.331C15.9011 6 15.5194 5.72528 15.3828 5.31769L14.6479 3.12423C14.6452 3.11605 14.6425 3.10783 14.64 3.09958C14.6302 3.0676 14.6169 3.03985 14.6027 3.01742C14.5986 3.01089 14.5946 3.00509 14.5908 3H9.16221C9.1584 3.00509 9.15437 3.01089 9.15023 3.01742ZM7.20525 2.49911C7.43535 1.76672 8.10563 1 9.06392 1H14.6891C15.6474 1 16.3177 1.76679 16.5478 2.49922L17.0506 4H21C22.6569 4 24 5.34315 24 7V20C24 21.6569 22.6569 23 21 23H3C1.34315 23 0 21.6569 0 20V7C0 5.34315 1.34315 4 3 4H6.70206L7.20525 2.49911ZM7 13C7 10.2386 9.23858 8 12 8C14.7614 8 17 10.2386 17 13C17 15.7614 14.7614 18 12 18C9.23858 18 7 15.7614 7 13ZM12 10C10.3431 10 9 11.3431 9 13C9 14.6569 10.3431 16 12 16C13.6569 16 15 14.6569 15 13C15 11.3431 13.6569 10 12 10Z";
    //Default styles
    private static bool STYLESINITIATED = false;
    private static readonly Style TITLESTYLE = new(typeof(Label));
    //General properties
    public static readonly BindableProperty CropperRadiusPerProperty = BindableProperty.Create(nameof(CropperRadiusPer), typeof(float), typeof(CropperImageView), 80f, propertyChanged: (b, o, n) => { ((CropperImageView)b).skCanvas?.InvalidateSurface(); });
    public static readonly BindableProperty CropperFigureProperty = BindableProperty.Create(nameof(CropperFigure), typeof(GeometryType), typeof(CropperImageView), GeometryType.Circle, propertyChanged: (b, o, n) => { ((CropperImageView)b).skCanvas?.InvalidateSurface(); });
    public static readonly BindableProperty EditModeProperty = BindableProperty.Create(nameof(EditMode), typeof(bool), typeof(CropperImageView), false, propertyChanged: EditModeChanged);
    public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(CropperImageView), null, propertyChanged: SourceChanged);
    public static readonly BindableProperty DefaultImageSourceProperty = BindableProperty.Create(nameof(DefaultImageSource), typeof(string), typeof(CropperImageView), null, propertyChanged: DefaultSourceChanged);
    public static readonly BindableProperty ImageChangedProperty = BindableProperty.Create(nameof(ImageChanged), typeof(bool), typeof(CropperImageView), false);
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CropperImageView), string.Empty);
    public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(CropperImageView), TITLESTYLE);
    public static readonly BindableProperty ShowTitleProperty = BindableProperty.Create(nameof(ShowTitle), typeof(bool), typeof(CropperImageView), true);
    public static readonly BindableProperty SelectSourceOnTapProperty = BindableProperty.Create(nameof(SelectSourceOnTap), typeof(bool), typeof(CropperImageView), false);
    public static readonly BindableProperty CroppedImageFormatProperty = BindableProperty.Create(nameof(CroppedImageFormat), typeof(ImageFormat), typeof(PortraitView), ImageFormat.PNG);
    public static readonly BindableProperty PhotoImageFormatProperty = BindableProperty.Create(nameof(PhotoImageFormat), typeof(ImageFormat), typeof(PortraitView), ImageFormat.PNG);
    public static readonly BindableProperty CroppedImageQualityProperty = BindableProperty.Create(nameof(CroppedImageQuality), typeof(int), typeof(PortraitView), 100);
    public static readonly BindableProperty PhotoImageQualityProperty = BindableProperty.Create(nameof(PhotoImageQuality), typeof(int), typeof(PortraitView), 100);
    public static readonly BindableProperty CroppedImageMaxResolutionProperty = BindableProperty.Create(nameof(CroppedImageMaxResolution), typeof(Size), typeof(PortraitView), new Size(0, 0));
    public static readonly BindableProperty PhotoImageMaxResolutionProperty = BindableProperty.Create(nameof(PhotoImageMaxResolution), typeof(Size), typeof(PortraitView), new Size(0, 0));

    //Buttons properties
    public static readonly BindableProperty PlusButtonDataProperty = BindableProperty.Create(nameof(PlusButtonData), typeof(string), typeof(CropperImageView), PLUSBUTTONDATA);
    public static readonly BindableProperty LessButtonDataProperty = BindableProperty.Create(nameof(LessButtonData), typeof(string), typeof(CropperImageView), LESSBUTTONDATA);
    public static readonly BindableProperty PickButtonDataProperty = BindableProperty.Create(nameof(PickButtonData), typeof(string), typeof(CropperImageView), PICKBUTTONDATA);
    public static readonly BindableProperty SelectButtonDataProperty = BindableProperty.Create(nameof(SelectButtonData), typeof(string), typeof(CropperImageView), SELECTBUTTONDATA);
    public static readonly BindableProperty ButtonsColorProperty = BindableProperty.Create(nameof(ButtonsColor), typeof(Color), typeof(CropperImageView), Colors.Black);
    public static readonly BindableProperty ButtonsScaleProperty = BindableProperty.Create(nameof(ButtonsScale), typeof(double), typeof(CropperImageView), 1d);
    public static readonly BindableProperty SelectButtonColorProperty = BindableProperty.Create(nameof(SelectButtonColor), typeof(Color), typeof(CropperImageView), Colors.Black);
    public static readonly BindableProperty SelectButtonScaleProperty = BindableProperty.Create(nameof(SelectButtonScale), typeof(double), typeof(CropperImageView), 1d);
    public static readonly BindableProperty ShowSelectButtonProperty = BindableProperty.Create(nameof(ShowSelectButton), typeof(bool), typeof(CropperImageView), true, propertyChanged: (b, o, n) => { if (o != n && n is bool value) ((CropperImageView)b).SetButtonsVisibility(); });
    public static readonly BindableProperty ShowPickButtonProperty = BindableProperty.Create(nameof(ShowPickButton), typeof(bool), typeof(CropperImageView), true, propertyChanged: (b, o, n) => { if (o != n && n is bool value) ((CropperImageView)b).SetButtonsVisibility(); });
    public static readonly BindableProperty ShowZoomButtonsProperty = BindableProperty.Create(nameof(ShowZoomButtons), typeof(bool), typeof(CropperImageView), (DeviceInfo.Current.Platform == DevicePlatform.WinUI), propertyChanged: (b, o, n) => { if (o != n && n is bool value) ((CropperImageView)b).SetButtonsVisibility(); });

    /// <summary>
    /// Sets the crop radius based on control's width/height percentage
    /// </summary>
    public float CropperRadiusPer
    {
        get => (float)GetValue(CropperRadiusPerProperty);
        set => SetValue(CropperRadiusPerProperty, value);
    }
    /// <summary>
    /// Sets the geometry figure for cropping
    /// </summary>
    public GeometryType CropperFigure
    {
        get => (GeometryType)GetValue(CropperFigureProperty);
        set => SetValue(CropperFigureProperty, value);
    }
    /// <summary>
    /// Sets work mode for the control. If true, the image can be manipulated
    /// </summary>
    public bool EditMode
    {
        get => (bool)GetValue(EditModeProperty);
        set => SetValue(EditModeProperty, value);
    }
    /// <summary>
    /// True if user manipulates or change the image
    /// </summary>
    public bool ImageChanged
    {
        get => (bool)GetValue(ImageChangedProperty);
        private set => SetValue(ImageChangedProperty, value);
    }
    /// <summary>
    /// Sets the source for the image to manipulate. This property only can be a file path or a Url
    /// </summary>
    public string Source
    {
        get => (string)GetValue(EditModeProperty);
        set => SetValue(EditModeProperty, value);
    }
    /// <summary>
    /// Sets the source for the image to show as background when no image source assigned. This property only can be a file path or a Url
    /// </summary>
    public string DefaultImageSource
    {
        get => (string)GetValue(DefaultImageSourceProperty);
        set => SetValue(DefaultImageSourceProperty, value);
    }
    /// <summary>
    /// Sets the title text to show over the image when no edit mode
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    /// <summary>
    /// Style Target Type Label. Define the aspect for the title.
    /// </summary>
    public Style TitleStyle
    {
        get => (Style)GetValue(TitleStyleProperty);
        set => SetValue(TitleStyleProperty, value);
    }
    /// <summary>
    /// Sets Title label visibility
    /// </summary>
    public bool ShowTitle
    {
        get => (bool)GetValue(ShowTitleProperty);
        set => SetValue(ShowTitleProperty, value);
    }
    /// <summary>
    /// If true, when user tap the control without a source image, image selection is invoked
    /// </summary>
    public bool SelectSourceOnTap
    {
        get => (bool)GetValue(SelectSourceOnTapProperty);
        set => SetValue(SelectSourceOnTapProperty, value);
    }
    /// <summary>
    /// Sets the function to use when the user wants to choose an image instead of the one in control
    /// </summary>
    public Func<Stream> CustomImageSelection { get; set; } = null;
    /// <summary>
    /// When the CropImage method is invoked, this property is refreshed
    /// </summary>
    public ImageSource CroppedImage { get; private set; }
    /// <summary>
    /// When the CropImage method is invoked, this property is refreshed
    /// </summary>
    public byte[] CroppedImageBytes { get; private set; }
    /// <summary>
    /// Photo selected by the user
    /// </summary>
    public ImageSource Photo { get; private set; }
    /// <summary>
    /// Bytes from Photo selected by the user
    /// </summary>
    public byte[] PhotoBytes { get; private set; }
    private SKEncodedImageFormat croppedImageFormat = SKEncodedImageFormat.Png;
    private SKEncodedImageFormat photoImageFormat = SKEncodedImageFormat.Png;
    /// <summary>
    /// Sets the image format for the cropped image result.
    /// </summary>
    public ImageFormat CroppedImageFormat
    {
        get => (ImageFormat)GetValue(CroppedImageFormatProperty);
        set
        {
            croppedImageFormat = value switch
            {
                ImageFormat.BMP => SKEncodedImageFormat.Bmp,
                ImageFormat.JPEG => SKEncodedImageFormat.Jpeg,
                _ => SKEncodedImageFormat.Png
            };
            SetValue(CroppedImageFormatProperty, value);
        }
    }
    /// <summary>
    /// Sets the image format transformation for the photo selected by the user.
    /// </summary>
    public ImageFormat PhotoImageFormat
    {
        get => (ImageFormat)GetValue(PhotoImageFormatProperty);
        set
        {
            croppedImageFormat = value switch
            {
                ImageFormat.BMP => SKEncodedImageFormat.Bmp,
                ImageFormat.JPEG => SKEncodedImageFormat.Jpeg,
                _ => SKEncodedImageFormat.Png
            };
            SetValue(PhotoImageFormatProperty, value);
        }
    }
    /// <summary>
    /// Sets the quality for the cropped image result.
    /// </summary>
    public int CroppedImageQuality
    {
        get => (int)GetValue(CroppedImageQualityProperty);
        set => SetValue(CroppedImageQualityProperty, value);
    }
    /// <summary>
    /// Sets the quality transformation for the photo selected by the user.
    /// </summary>
    public int PhotoImageQuality
    {
        get => (int)GetValue(PhotoImageQualityProperty);
        set => SetValue(PhotoImageQualityProperty, value);
    }
    /// <summary>
    /// Sets the max resolution for the cropped image result.
    /// </summary>
    public Size CroppedImageMaxResolution
    {
        get => (Size)GetValue(CroppedImageMaxResolutionProperty);
        set => SetValue(CroppedImageMaxResolutionProperty, value);
    }
    /// <summary>
    /// Sets the max resolution transformation for the photo selected by the user.
    /// </summary>
    public Size PhotoImageMaxResolution
    {
        get => (Size)GetValue(PhotoImageMaxResolutionProperty);
        set => SetValue(PhotoImageMaxResolutionProperty, value);
    }
    /// <summary>
    /// String markup data for plus zoom button icon
    /// </summary>
    public string PlusButtonData
    {
        get => (string)GetValue(PlusButtonDataProperty);
        set
        {
            SetValue(PlusButtonDataProperty, value);
            try
            {
                PlusPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(value);
            }
            catch
            {
                PlusPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(PLUSBUTTONDATA);
            }
        }
    }
    /// <summary>
    /// String markup data for less zoom button icon
    /// </summary>
    public string LessButtonData
    {
        get => (string)GetValue(LessButtonDataProperty);
        set
        {
            SetValue(LessButtonDataProperty, value);
            try
            {
                LessPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(value);
            }
            catch
            {
                LessPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(LESSBUTTONDATA);
            }
        }
    }
    /// <summary>
    /// String markup data for pick photo button icon
    /// </summary>
    public string PickButtonData
    {
        get => (string)GetValue(PickButtonDataProperty);
        set
        {
            SetValue(PickButtonDataProperty, value);
            try
            {
                PickPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(value);
            }
            catch
            {
                PickPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(PICKBUTTONDATA);
            }
        }
    }
    /// <summary>
    /// String markup data for select photo button icon
    /// </summary>
    public string SelectButtonData
    {
        get => (string)GetValue(SelectButtonDataProperty);
        set
        {
            SetValue(SelectButtonDataProperty, value);
            try
            {
                SelectPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(value);
            }
            catch
            {
                SelectPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(SELECTBUTTONDATA);
            }
        }
    }
    /// <summary>
    /// Color for zoom and pick buttons
    /// </summary>
    public Color ButtonsColor { get => (Color)GetValue(ButtonsColorProperty); set => SetValue(ButtonsColorProperty, value); }
    /// <summary>
    /// Scale for zoom and pick buttons
    /// </summary>
    public double ButtonsScale { get => (double)GetValue(ButtonsScaleProperty); set => SetValue(ButtonsScaleProperty, value); }
    /// <summary>
    /// Color for select button
    /// </summary>
    public Color SelectButtonColor { get => (Color)GetValue(SelectButtonColorProperty); set => SetValue(SelectButtonColorProperty, value); }
    /// <summary>
    /// Scale for select button
    /// </summary>
    public double SelectButtonScale { get => (double)GetValue(SelectButtonScaleProperty); set => SetValue(SelectButtonScaleProperty, value); }
    /// <summary>
    /// Show/hide Select button
    /// </summary>
    public bool ShowSelectButton { get => (bool)GetValue(ShowSelectButtonProperty); set => SetValue(ShowSelectButtonProperty, value); }
    /// <summary>
    /// Show/hide Pick button
    /// </summary>
    public bool ShowPickButton { get => (bool)GetValue(ShowPickButtonProperty); set => SetValue(ShowPickButtonProperty, value); }
    /// <summary>
    /// Show/hide Pick button
    /// </summary>
    public bool ShowZoomButtons { get => (bool)GetValue(ShowZoomButtonsProperty); set => SetValue(ShowZoomButtonsProperty, value); }

    public Command MoreZoom { get; set; }
    public Command LessZoom { get; set; }
    public Command SelectCommand { get; set; }
    private bool cropping = false;
    private byte[] imageData;
    private bool cropRect = false;
    private SKImage image, croppedImage, defaultImage;
    private bool hasImage = false;

    private float imageX = 0;
    private float imageY = 0;
    private float imageScale = 1;
    private float x, y, scale;
    public CropperImageView()
    {
        DefineDefaultStyles();
        MoreZoom = new Command(() => { moreZoom(); });
        LessZoom = new Command(() => { lessZoom(); });
        SelectCommand = new Command(() => { SelectImage(); });
        InitializeComponent();
        skCanvas.PaintSurface += SkCanvas_PaintSurface;
        PanGestureRecognizer panGesture = new PanGestureRecognizer();
        panGesture.PanUpdated += OnPanUpdated;
        skCanvas.GestureRecognizers.Add(panGesture);
        skCanvas.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => { if (SelectSourceOnTap) SelectImage(); }) });
        PinchGestureRecognizer pinchGesture = new PinchGestureRecognizer();
        pinchGesture.PinchUpdated += OnPinchUpdated;
        skCanvas.GestureRecognizers.Add(pinchGesture);
        SetButtonsVisibility();
        PlusPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(PLUSBUTTONDATA);
        LessPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(LESSBUTTONDATA);
        SelectPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(SELECTBUTTONDATA);
        PickPath.Data = (Geometry)new PathGeometryConverter().ConvertFromInvariantString(PICKBUTTONDATA);
    }
    /// <summary>
    /// Execute the image crop async. Refresh CroppedImage and CroppedImageBytes properties at ends.
    /// </summary>
    /// <param name="CropRect">Indicates if you want a cropped square image as cropped result</param>
    /// <returns></returns>
    public Task CropImageAsync(bool CropRect = false)
    {
        return Task.Run(async () =>
        {
            var result = await CropImage(CropRect);
        });
    }

    /// <summary>
    /// Execute the image crop async. Refresh CroppedImage and CroppedImageBytes properties at ends.
    /// </summary>
    /// <param name="CropRect"></param>
    /// <returns>Cropped image bytes</returns>
    public async Task<byte[]> CropImage(bool CropRect = false)
    {
        imageData = null;
        if (hasImage)
        {
            cropRect = CropRect;
            cropping = true;
            skCanvas.InvalidateSurface();
            while (imageData == null)
                await Task.Delay(TimeSpan.FromMilliseconds(10));
            cropping = false;
            skCanvas.InvalidateSurface();
            var transformSize = GetResultSize(CroppedImageMaxResolution, croppedImage.Width, croppedImage.Height);
            if (transformSize.Width != croppedImage.Width || transformSize.Height != croppedImage.Height)
            {
                var bmp = SKBitmap.FromImage(croppedImage);
                bmp = bmp.Resize(new SKImageInfo((int)transformSize.Width, (int)transformSize.Height), SKFilterQuality.High);

                CroppedImageBytes = bmp.Encode(croppedImageFormat, Math.Min(100, CroppedImageQuality)).ToArray();
            }
            else
                CroppedImageBytes = croppedImage.Encode(croppedImageFormat, Math.Min(100, CroppedImageQuality)).ToArray();

            MemoryStream ms = new MemoryStream();
            ms.Write(CroppedImageBytes);
            ms.Position = 0;
            CroppedImage = ImageSource.FromStream(() => ms);
            OnPropertyChanged(nameof(CroppedImage));
            OnPropertyChanged(nameof(CroppedImageBytes));
        }
        return imageData;
    }

    private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (hasImage && EditMode)
        {
            switch (e.Status)
            {
                case GestureStatus.Started:
                    scale = imageScale;
                    break;
                case GestureStatus.Running:
                    imageScale += scale * ((float)e.Scale - 1f);
                    imageScale = Math.Max(0.3f, imageScale);
                    break;
            }
            skCanvas.InvalidateSurface();
            ImageChanged = true;
        }
    }

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (hasImage && EditMode)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    x = imageX = imageX + (float)e.TotalX;
                    y = imageY = imageY + (float)e.TotalY;
                    break;
                case GestureStatus.Running:
                    imageX = x + (float)e.TotalX;
                    imageY = y + (float)e.TotalY;
                    break;
            }
            skCanvas.InvalidateSurface();
            ImageChanged = true;
        }
    }
    private void moreZoom()
    {
        if (hasImage && imageScale < 3f)
        {
            imageScale += 0.05f;
            skCanvas.InvalidateSurface();
            ImageChanged = true;
        }
    }
    private void lessZoom()
    {
        if (hasImage && imageScale > 0.2f)
        {
            imageScale -= 0.05f;
            skCanvas.InvalidateSurface();
            ImageChanged = true;
        }
    }
    private void SetButtonsVisibility()
    {
        selectButton.IsVisible = ShowSelectButton && !hasImage && EditMode;
        changeButton.IsVisible = ShowPickButton && hasImage && EditMode;
        zoomButtons.IsVisible = ShowZoomButtons && hasImage && EditMode;
    }
    private Size GetResultSize(Size max, double width, double height)
    {
        if (max.Width > 0 && max.Height > 0)
        {
            double fwidth = Math.Min(max.Width, width);
            double fheight = Math.Min(max.Height, height);
            double wFactor = fwidth / width;
            double hFactor = fheight / height;
            if (wFactor > hFactor && height * wFactor <= max.Height)
                return new Size(fwidth, height * wFactor);
            else
                return new Size(width * hFactor, fheight);
        }
        else
            return new Size(width, height);
    }
    private async void SelectImage()
    {
        Stream stream = null;
        if (CustomImageSelection != null)
            stream = CustomImageSelection.Invoke();
        else
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync();
            if (photo != null) stream = await photo.OpenReadAsync();
        }
        if (stream != null)
        {
            try
            {
                image = SKImage.FromEncodedData(stream);
                hasImage = image != null;
                imageX = imageY = 0;
                imageScale = 1;
                SetButtonsVisibility();
                skCanvas.InvalidateSurface();
                ImageChanged = true;
                _ = Task.Run(() =>
                {
                    var transformSize = GetResultSize(PhotoImageMaxResolution, image.Width, image.Height);
                    if (transformSize.Width != image.Width || transformSize.Height != image.Height)
                    {
                        var bmp = SKBitmap.FromImage(image);
                        bmp = bmp.Resize(new SKImageInfo((int)transformSize.Width, (int)transformSize.Height), SKFilterQuality.High);

                        PhotoBytes = bmp.Encode(photoImageFormat, Math.Min(100, PhotoImageQuality)).ToArray();
                    }
                    else
                        PhotoBytes = image.Encode(photoImageFormat, Math.Min(100, PhotoImageQuality)).ToArray();
                    MemoryStream ms = new MemoryStream();
                    ms.Write(PhotoBytes);
                    ms.Position = 0;
                    Photo = ImageSource.FromStream(() => ms);
                    OnPropertyChanged(nameof(Photo));
                    OnPropertyChanged(nameof(PhotoBytes));
                });
            }
            catch { }
        }
    }
    private static void EditModeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ((bool)oldValue != (bool)newValue)
        {
            CropperImageView iView = bindable as CropperImageView;
            bool value = (bool)newValue;
            iView.SetButtonsVisibility();
            iView.skCanvas.InvalidateSurface();
        }
    }
    private SKImage GetImage(string value)
    {
        SKImage image = null;

        if (Uri.TryCreate(value, UriKind.Absolute, out Uri uri))
        {
            try
            {
                var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
                var st = httpClient.GetByteArrayAsync(uri).Result;
                image = SKImage.FromEncodedData(st);
                httpClient.Dispose();
            }
            catch { }
        }
        else if (File.Exists(value))
        {
            try
            {
                image = SKImage.FromEncodedData(value);
            }
            catch { }
        }

        return image;
    }
    private static void SourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue != null && oldValue != newValue)
        {
            CropperImageView iView = bindable as CropperImageView;
            string value = newValue as string;
            iView.hasImage = false;
            var image = iView.GetImage(value);

            if (image != null)
            {
                iView.image = image;
                iView.hasImage = true;
                iView.imageX = iView.imageY = 0;
                iView.imageScale = 1;
                iView.SetButtonsVisibility();
            }
            iView.skCanvas.InvalidateSurface();
        }
    }
    public void SetSource(Stream imageStream)
    {
        try
        {
            image = SKImage.FromEncodedData(imageStream);
        }
        catch { }
        if (image != null)
        {
            hasImage = true;
            imageX = imageY = 0;
            imageScale = 1;
            SetButtonsVisibility();
        }
        skCanvas.InvalidateSurface();
    }
    public void SetSource(byte[] imageBytes)
    {
        try
        {
            image = SKImage.FromEncodedData(imageBytes);
        }
        catch { }
        if (image != null)
        {
            hasImage = true;
            imageX = imageY = 0;
            imageScale = 1;
            SetButtonsVisibility();
        }
        skCanvas.InvalidateSurface();
    }
    private static void DefaultSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue != null && oldValue != newValue)
        {
            CropperImageView iView = bindable as CropperImageView;
            string value = newValue as string;
            iView.hasImage = false;
            var image = iView.GetImage(value);

            if (image != null)
            {
                iView.defaultImage = image;
            }
            iView.skCanvas.InvalidateSurface();
        }
    }
    public void SetDefaultImageSource(Stream imageStream)
    {
        try
        {
            defaultImage = SKImage.FromEncodedData(imageStream);
        }
        catch { }
        skCanvas.InvalidateSurface();
    }
    public void SetDefaultImageSource(byte[] imageBytes)
    {
        try
        {
            defaultImage = SKImage.FromEncodedData(imageBytes);
        }
        catch { }
        skCanvas.InvalidateSurface();
    }
    private void SkCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        if (EditMode)
            canvas.Clear(BackgroundColor != null ? BackgroundColor.ToSKColor() : SKColors.White);
        else
            canvas.Clear();
        if (hasImage)
        {
            if (cropping)
            {
                canvas.Clear();
                if (CropperRadiusPer > 0)
                {
                    float CropRadius = Math.Min(e.Info.Width, e.Info.Height) / 2 * CropperRadiusPer / 100f;
                    if (!cropRect && CropperFigure == GeometryType.Circle)
                        canvas.ClipRoundRect(new SKRoundRect(SKRect.Create(e.Info.Width / 2 - CropRadius, e.Info.Height / 2 - CropRadius, CropRadius * 2, CropRadius * 2), CropRadius * 2));
                    var pictureFrameCrop = SKRect.Create(imageX, imageY, e.Info.Width * imageScale, e.Info.Height * imageScale);
                    var destCrop = pictureFrameCrop.AspectFit(new SKSize(image.Width, image.Height));
                    canvas.DrawImage(image, destCrop);
                    var snap = e.Surface.Snapshot(SKRectI.Create((int)(e.Info.Width / 2 - CropRadius), (int)(e.Info.Height / 2 - CropRadius), (int)(CropRadius * 2), (int)(CropRadius * 2)));
                    croppedImage = snap;
                    imageData = snap.Encode().ToArray();
                }
                else
                {
                    var pictureFrameCrop = SKRect.Create(imageX, imageY, e.Info.Width * imageScale, e.Info.Height * imageScale);
                    var destCrop = pictureFrameCrop.AspectFit(new SKSize(image.Width, image.Height));
                    canvas.DrawImage(image, destCrop);
                    var snap = e.Surface.Snapshot();
                    croppedImage = snap;
                    imageData = snap.Encode().ToArray();
                }
                if (EditMode)
                    canvas.Clear(BackgroundColor != null ? BackgroundColor.ToSKColor() : SKColors.White);
                else
                    canvas.Clear();
            }
            var pictureFrame = SKRect.Create(imageX, imageY, e.Info.Width * imageScale, e.Info.Height * imageScale);
            var dest = pictureFrame.AspectFit(new SKSize(image.Width, image.Height));
            canvas.DrawImage(image, dest);
        }
        else if (defaultImage != null)
        {
            var pictureFrame = SKRect.Create(0, 0, e.Info.Width, e.Info.Height);
            var dest = pictureFrame.AspectFit(new SKSize(defaultImage.Width, defaultImage.Height));
            canvas.DrawImage(defaultImage, dest);
        }
        if (CropperRadiusPer > 0 && EditMode)
        {
            float CropRadius = Math.Min(e.Info.Width, e.Info.Height) / 2 * CropperRadiusPer / 100f;
            SKPath maskPath = new SKPath { FillType = SKPathFillType.InverseWinding };
            maskPath.AddRect(SKRect.Create(e.Info.Size));
            //maskPath.AddCircle(e.Info.Width / 2, e.Info.Height / 2, CropRadius);
            SKPaint cropPaint = new SKPaint { Style = SKPaintStyle.Fill, Color = Color.FromRgba(0, 0, 0, 0.5).ToSKColor() };
            maskPath.Close();
            if (CropperFigure == GeometryType.Circle)
                canvas.ClipRoundRect(new SKRoundRect(SKRect.Create(e.Info.Width / 2 - CropRadius, e.Info.Height / 2 - CropRadius, CropRadius * 2, CropRadius * 2), CropRadius * 2), SKClipOperation.Difference);
            else
                canvas.ClipRect(SKRect.Create(e.Info.Width / 2 - CropRadius, e.Info.Height / 2 - CropRadius, CropRadius * 2, CropRadius * 2), SKClipOperation.Difference);
            canvas.DrawPaint(cropPaint);
        }
    }
    private static void DefineDefaultStyles()
    {
        if (!STYLESINITIATED)
        {

            TITLESTYLE.Setters.Add(HorizontalOptionsProperty, LayoutOptions.Start);
            TITLESTYLE.Setters.Add(VerticalOptionsProperty, LayoutOptions.Start);
            TITLESTYLE.Setters.Add(Label.FontSizeProperty, 11d);
            TITLESTYLE.Setters.Add(Label.FontAttributesProperty, FontAttributes.Bold);
            TITLESTYLE.Setters.Add(Label.TextColorProperty, Colors.White);
            TITLESTYLE.Setters.Add(MarginProperty, new Thickness(3, 2, 3, 5));

            STYLESINITIATED = true;
        }
    }
}