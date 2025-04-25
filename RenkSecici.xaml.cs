using System;

namespace AhmedGamal_Odev2;

public partial class RenkSecici : ContentPage
{
    bool isRandom;
    string hexValue;

    public RenkSecici()
    {
        InitializeComponent();
        UpdateColor(); // إعداد اللون الافتراضي
    }

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            UpdateColor();
        }
    }

    private void UpdateColor()
    {
        var red = (int)sldRed.Value;
        var green = (int)sldGreen.Value;
        var blue = (int)sldBlue.Value;

        Color color = Color.FromRgb(red, green, blue);
        ApplyColor(color);
    }

    private void ApplyColor(Color color)
    {
        ColorBox.BackgroundColor = color;   // ✅ اللون يتغير فقط في BoxView
        hexValue = color.ToHex();
        lblHex.Text = hexValue;
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        var random = new Random();
        int r = random.Next(0, 256);
        int g = random.Next(0, 256);
        int b = random.Next(0, 256);

        Color color = Color.FromRgb(r, g, b);
        ApplyColor(color);

        sldRed.Value = r;
        sldGreen.Value = g;
        sldBlue.Value = b;

        isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        await DisplayAlert("Kopyalandı", $"{hexValue}", "OK");
    }
}
