namespace AhmedGamal_Odev2
{
    public partial class KrediHesaplama : ContentPage
    {
        double KKDF = 0;
        double BSMV = 0;

        public KrediHesaplama()
        {
            InitializeComponent();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                switch (picker.Items[selectedIndex])
                {
                    case "İhtiyaç Kredisi":
                        KKDF = 15;
                        BSMV = 10;
                        break;
                    case "Konut Kredisi":
                        KKDF = 0;
                        BSMV = 0;
                        break;
                    case "Taşıt Kredisi":
                        KKDF = 15;
                        BSMV = 5;
                        break;
                    case "Ticari Kredisi":
                        KKDF = 0;
                        BSMV = 5;
                        break;
                }
            }
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            TermValueLabel.Text = ((int)e.NewValue).ToString();
        }

        async void OnCalculateClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AmountEntry.Text) ||
                string.IsNullOrWhiteSpace(InterestRateEntry.Text))
            {
                await DisplayAlert("Uyarı", "Lütfen tüm alanları doldurunuz.", "Tamam");
                return;
            }

            double amount = Convert.ToDouble(AmountEntry.Text);
            double interestRate = Convert.ToDouble(InterestRateEntry.Text); // Yıllık faiz
            int termInMonths = (int)TermSlider.Value; // استخدم الـ Slider بدل الـ Entry

            double monthlyRate = interestRate / 12;
            double brutFaiz = (monthlyRate + (monthlyRate * BSMV / 100) + (monthlyRate * KKDF / 100)) / 100;

            double taksit = ((Math.Pow(1 + brutFaiz, termInMonths) * brutFaiz) /
                            (Math.Pow(1 + brutFaiz, termInMonths) - 1)) * amount;

            double toplam = taksit * termInMonths;
            double toplamFaiz = toplam - amount;

            taksit = Math.Round(taksit, 2);
            toplam = Math.Round(toplam, 2);
            toplamFaiz = Math.Round(toplamFaiz, 2);

            MonthlyPaymentLabel.Text = $"Aylık Taksit: {taksit} ₺";
            TotalPaymentLabel.Text = $"Toplam Ödeme: {toplam} ₺";
            TotalInterestLabel.Text = $"Toplam Faiz: {toplamFaiz} ₺";
        }
    }
}
