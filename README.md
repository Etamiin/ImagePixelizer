ImagePixelizer
========
**Simply pixelize your images.**

>The only files you need to use it on your projects are the files in the 'Pixelizer' folders.

### Result example

![Sample image](https://i.ibb.co/mBZL1G5/Sample-Image.png)
![Sample image 2](https://i.ibb.co/wBJmQSy/transformed-Image-Low-Level.png)
![Sample image 3](https://i.ibb.co/G915ry0/transformed-Image-High-Level.png)

> Program.cs (sample)

```csharp
var targetImagePath = @"Sample/achievement.png";
var outputDirPath = @"Sample";
var outputName = @"achievement_icon.png";

Pixelizer.TransformAndSave(targetImagePath, PixelImageLevel.One, outputDirPath, outputName);

//Get transformed Bitmap object and do stuff with it
//var output = Pixelizer.TransformBitmap("Sample/SampleImage.jpg", PixelImageLevel.Two);

Console.WriteLine("Finished.");
Console.ReadKey();
```

> Problem to fix

```
An grey outline is added on the output image if the image is small
```