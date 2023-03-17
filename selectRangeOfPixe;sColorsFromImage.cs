using System.Drawing;
using System.Drawing.Imaging;

Bitmap image = new Bitmap("image.jpg");
Color lowerBound = Color.FromArgb(0, 0, 0);
Color upperBound = Color.FromArgb(255, 255, 255);

for (int x = 0; x < image.Width; x++)
{
    for (int y = 0; y < image.Height; y++)
    {
        Color pixelColor = image.GetPixel(x, y);
        if (pixelColor.R >= lowerBound.R && pixelColor.G >= lowerBound.G && pixelColor.B >= lowerBound.B &&
            pixelColor.R <= upperBound.R && pixelColor.G <= upperBound.G && pixelColor.B <= upperBound.B)
        {
            // This pixel is within the specified color range
            // Do something with it here
        }
    }
}