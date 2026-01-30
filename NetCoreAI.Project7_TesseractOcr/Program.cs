using Tesseract;

/*TESSERACT NEDİR?

Tesseract, görüntüler (resimler, taranmış belgeler, fotoğraflar) üzerindeki
yazıları otomatik olarak tanıyıp metne çeviren açık kaynaklı bir
OCR (Optical Character Recognition - Optik Karakter Tanıma) motorudur.
Tesseract NE YAPAR?
- JPG, PNG, TIFF, BMP gibi görsellerdeki yazıları okur
- PDF dosyalarındaki taranmış metinleri metne dönüştürebilir
- Okuduğu metnin güven oranını hesaplayabilir*/

class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Karakter okuması için görsel yolu giriniz:");
        string imagePath = Console.ReadLine();
        string tessDataPath = @"C:\tessdata";
        //tessdata klasörünün yolu

        try
        {
            //Tesseract motoru başlatılıyor
            //İngilizce dil desteği ile varsayılan motor modu kullanılıyor 
            using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
            {
                //Görsel dosyası yükleniyor ve işleniyor. Pix formatı kullanılıyor
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    //Görsel üzerindeki metin tanımlanıyor ve okunuyor. OCR işlemi yapılıyor
                    using (var page = engine.Process(img))
                    {
                        //Okunan metin ve güven skoru ekrana yazdırılıyor
                        string text = page.GetText();
                        float confidence = page.GetMeanConfidence() * 100;
                        //güven skoru yüzdeye çevriliyor
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
        Console.ReadLine();
    }
}