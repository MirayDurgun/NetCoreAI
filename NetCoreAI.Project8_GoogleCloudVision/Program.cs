/*
GOOGLE CLOUD VISION NEDİR?

Google Cloud Vision, Google’ın bulut tabanlı görsel analiz ve OCR servisidir.

- Görsellerdeki yazıları (OCR) yüksek doğrulukla okur
- El yazısı dahil olmak üzere metin tanıma yapabilir
- Nesne, yüz, logo, etiket ve metin algılama sağlar
- Tesseract’tan farklı olarak yapay zeka (ML) modelleri kullanır
- İnternet bağlantısı ve Google Cloud API anahtarı gerektirir
- Ücretlidir (belirli bir kullanım kotası sonrası)

Kısaca:
Yerel OCR = Tesseract  
Bulut + AI + yüksek doğruluk = Google Cloud Vision
*/

class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Görsel yolu giriniz: ");
        Console.WriteLine();
        string imagePath = Console.ReadLine();
        string credentialPath = @"jason doyası";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath) ;

        try
        {
            var client=ImageAnnatatorClient
        }
        catch (Exception)
        {

            throw;
        }
    }
}