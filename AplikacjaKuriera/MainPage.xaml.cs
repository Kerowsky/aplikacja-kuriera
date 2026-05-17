using ZXing.Net.Maui;
using System.Net.Http;

namespace AplikacjaKuriera
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonBoxClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                OpenBox.Text = $"Clicked {count} time";
            else
                OpenBox.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(OpenBox.Text);
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
}
