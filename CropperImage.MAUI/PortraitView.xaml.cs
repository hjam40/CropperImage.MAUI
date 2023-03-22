using Microsoft.Maui.Controls.Shapes;

namespace CropperImage.MAUI;

public partial class PortraitView : ContentView
{
    //General properties
    public static readonly BindableProperty StrokeShapeProperty = BindableProperty.Create(nameof(StrokeShape), typeof(IShape), typeof(PortraitView), new RoundRectangle { CornerRadius = new CornerRadius(20) });
    public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create(nameof(StrokeThickness), typeof(double), typeof(PortraitView), 2d);
    public static readonly BindableProperty StrokeProperty = BindableProperty.Create(nameof(Stroke), typeof(Brush), typeof(PortraitView), Brush.Black);
    public static readonly BindableProperty FillProperty = BindableProperty.Create(nameof(Fill), typeof(Brush), typeof(PortraitView), Brush.White);
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(PortraitView), string.Empty);
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(PortraitView), Colors.Black);
    public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(PortraitView), FontAttributes.Bold);
    public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(PortraitView), string.Empty);
    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(PortraitView), 20d);
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(PortraitView), null, propertyChanged:ImageChanged);


    /// <summary>
    /// Sets the border shape
    /// </summary>
    public IShape StrokeShape
    {
        get => (IShape)GetValue(StrokeShapeProperty);
        set => SetValue(StrokeShapeProperty, value);
    }
    /// <summary>
    /// Sets the border stroke thickness
    /// </summary>
    public double StrokeThickness
    {
        get => (double)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }
    /// <summary>
    /// Sets the border stroke color
    /// </summary>
    public Brush Stroke
    {
        get => (Brush)GetValue(StrokeProperty);
        set => SetValue(StrokeProperty, value);
    }
    /// <summary>
    /// Sets the border shape fill color
    /// </summary>
    public Brush Fill
    {
        get => (Brush)GetValue(FillProperty);
        set => SetValue(FillProperty, value);
    }    /// <summary>
         /// Text to show if no image available
         /// </summary>
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    /// <summary>
    /// Sets text color
    /// </summary>
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }
    /// <summary>
    /// Sets text font attributes
    /// </summary>
    public FontAttributes FontAttributes
    {
        get => (FontAttributes)GetValue(FontAttributesProperty);
        set => SetValue(FontAttributesProperty, value);
    }
    /// <summary>
    /// Sets text font family
    /// </summary>
    public string FontFamily
    {
        get => (string)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }
    /// <summary>
    /// Sets text font size
    /// </summary>
    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }
    /// <summary>
    /// Sets the image to show
    /// </summary>
    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
    public PortraitView()
	{
		InitializeComponent();
        SizeChanged += PortraitView_SizeChanged;
	}

    private void PortraitView_SizeChanged(object sender, EventArgs e)
    {
        if (Width > 0 && Height > 0)
        {
            border.WidthRequest = border.HeightRequest = Math.Min(Width, Height);
            if (StrokeShape is RoundRectangle rr && rr.CornerRadius.TopLeft == rr.CornerRadius.TopRight && rr.CornerRadius.TopRight == rr.CornerRadius.BottomLeft && rr.CornerRadius.BottomLeft == rr.CornerRadius.BottomRight)
            {
                rr.CornerRadius = new CornerRadius(border.WidthRequest / 2);
                OnPropertyChanged(nameof(StrokeShape));
            }
        }
    }
    private static void ImageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (oldValue != newValue) 
        {
            var portrait = bindable as PortraitView;
            if (newValue == null)
            {
                portrait.textLabel.IsVisible = true;
                portrait.border.SetBinding(BackgroundProperty, nameof(Fill));
            }
            else
            {
                portrait.textLabel.IsVisible = false;
                portrait.border.RemoveBinding(BackgroundProperty);
                portrait.border.Background = Brush.Transparent;
            }
        }
    }
}