

using Tesseract;

static void Main(string[] args)
{
    Console.WriteLine("Karakter okuması için görsel yolu giriniz:");
    string imagePath = Console.ReadLine();
    string tessDataPath = @"C:\tessdata";

    try
    {
        using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default)
        {
            using (var img = Pix.LoadFromFile(imagePath))
        {
            using (var page = engine.Process(img))
            {
                using (var page = engine.Process(img))
                {
                    string text = page.GetText();
                    float confidence = page.GetMeanConfidence() * 100;
                    Console.WriteLine("Okunan Metin:\n" + text);
                    Console.WriteLine($"Güven Skoru: {confidence:F2}%");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Hata oluştu: " + ex.Message);
    }
}