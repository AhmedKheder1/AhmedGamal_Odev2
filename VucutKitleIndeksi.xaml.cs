namespace AhmedGamal_Odev2
{
    public partial class VucutKitleIndeksi : ContentPage
    {
        public VucutKitleIndeksi()
        {
            InitializeComponent();
        }

        void OnWeightSliderChanged(object sender, ValueChangedEventArgs e)
        {
            WeightEntry.Text = e.NewValue.ToString("F1");
            CalculateBMI();
        }

        void OnHeightSliderChanged(object sender, ValueChangedEventArgs e)
        {
            HeightEntry.Text = e.NewValue.ToString("F1");
            CalculateBMI();
        }

        void OnWeightEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double value))
                WeightSlider.Value = value;

            CalculateBMI();
        }

        void OnHeightEntryChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double value))
                HeightSlider.Value = value;

            CalculateBMI();
        }

        void CalculateBMI()
        {
            if (double.TryParse(WeightEntry.Text, out double weight) &&
                double.TryParse(HeightEntry.Text, out double height))
            {
                height = height / 100.0; // convert cm to meters
                double bmi = weight / (height * height);
                ResultLabel.Text = bmi.ToString("F2");

                if (bmi < 18.5)
                    StatusLabel.Text = "Zayıf";
                else if (bmi < 25)
                    StatusLabel.Text = "Normal";
                else if (bmi < 30)
                    StatusLabel.Text = "Fazla Kilolu";
                else if (bmi < 35)
                    StatusLabel.Text = "1. Derecede Obez";
                else if (bmi < 40)
                    StatusLabel.Text = "2. Derecede Obez";
                else
                    StatusLabel.Text = "3. Derecede Obez / Morbid Obez";
            }
            else
            {
                ResultLabel.Text = "";
                StatusLabel.Text = "";
            }
        }
    }
}
