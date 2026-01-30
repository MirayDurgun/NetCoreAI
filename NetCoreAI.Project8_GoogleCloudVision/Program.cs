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

using Google.Cloud.Vision.V1;

class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Görsel yolu giriniz: ");
        string imagePath = Console.ReadLine();
        Console.WriteLine();
        string credentialPath = @"json doyası";
        // Google Cloud API kimlik doğrulama dosyasının yolu
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
        // Google Cloud kütüphanelerinin kimlik doğrulama için bu ortam değişkenini kullanması gerekir
        try
        {
            var client = ImageAnnotatorClient.Create();
            //Google Cloud Vision istemcisi oluşturuluyor. Bu istemci API ile iletişim kurar. JSON kimlik doğrulama dosyası okunur

            var image = Image.FromFile(imagePath);
            //Görseli dosya yolundan belleğe yüklüyor
            var response = client.DetectText(image);
            //Görsel üzerindeki metinleri algılar ve okur. OCR işlemi yapılır. 
            Console.WriteLine("Görseldeki metin: ");
            Console.WriteLine();

            foreach (var annotation in response)
            {
                //Algılanan her metin parçası için döngü
                if (!string.IsNullOrEmpty(annotation.Description))
                {
                    //Boş olmayan metin parçalarını ekrana yazdır
                    Console.WriteLine(annotation.Description);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu : {ex.Message}");
            throw;
        }
    }
}