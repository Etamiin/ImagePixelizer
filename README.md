ImagePixelizer
========
**Simply pixelize your images.**


### Result example

![Sample image](https://i.ibb.co/mBZL1G5/Sample-Image.png)
![Sample image - Normal](https://i.ibb.co/wBJmQSy/transformed-Image-Low-Level.png)
![Sample image - High](https://i.ibb.co/G915ry0/transformed-Image-High-Level.png)

Different levels are available, you can add new levels of transformations:
> In PixelImageLevel.cs

```csharp
public enum PixelImageLevel : byte
{
  Low = 3,
  Normal = 4,
  High = 5,
  VeryHigh = 6,
  Ultra = 7,
  VeryUltra = 8,
  YourLevel = 999
}
```

> Utilization examples - Program.cs

```csharp
//output files are in 'bin/Debug/Sample' folder

//You can add levels on the PixelImageLevel enum object with different value for less or more pixelization
//The more the value is low, the less it will be pixelized

//103x139 PNG Image take 100-150ms to be transformed
Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.VeryUltra, "Sample", "transformedImageVeryUltraLevel.png");
Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.Ultra, "Sample", "transformedImageUltraLevel.png");
Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.VeryHigh, "Sample", "transformedImageVeryHighLevel.png");
Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.High, "Sample", "transformedImageHighLevel.png");
Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.Normal, "Sample", "transformedImageNormalLevel.png");
Pixelizer.TransformAndSave("Sample/SampleImage.png", PixelImageLevel.Low, "Sample", "transformedImageLowLevel.png");

//1150x699 JPG Image take 5-10 seconds to be transformed
Pixelizer.TransformAndSave("Sample/Landscape.jpg", PixelImageLevel.VeryUltra, "Sample", "TransformedLandscape.png");

//Get transformed Bitmap object and do stuff with it
var output = Pixelizer.TransformBitmap("Sample/SampleImage.jpg", PixelImageLevel.Normal);

```