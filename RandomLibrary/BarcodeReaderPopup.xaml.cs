namespace RandomLibrary;

public partial class BarcodeReaderPopup
{
	private void scanner_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		scanner.IsDetecting = false;
		Close(e.Results[0].Value);
	}
	public BarcodeReaderPopup()
	{
		InitializeComponent();
	}
}