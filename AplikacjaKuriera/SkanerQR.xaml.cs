using ZXing.Net.Maui;
using System.Net.Http;

namespace AplikacjaKuriera;

public partial class SkanerQR : ContentPage
{
	public SkanerQR()
	{
		InitializeComponent();
	}
    private void CameraBarcodeReaderView_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        // Pobierz pierwszy znaleziony kod
        var firstBarcode = e.Results?.FirstOrDefault();

        if (firstBarcode != null)
        {
            // Pamiętaj! Zdarzenie z aparatu działa w tle. 
            // Aby zaktualizować UI, musisz wrócić do Głównego Wątku (Main Thread).
            Dispatcher.Dispatch(() =>
            {
                resultLabel.Text = $"Zeskanowano: {firstBarcode.Value}";

                // Jeśli chcesz zatrzymać skanowanie po pierwszym odczycie:
                // barcodeReader.IsDetecting = false;
            });
        }
    }
}