namespace AplikacjaKuriera
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SkanerQR), typeof(SkanerQR));
        }
    }
}
