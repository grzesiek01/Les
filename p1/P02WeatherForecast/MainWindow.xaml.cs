// P02WeatherForecast/MainWindow.xaml.cs  (wersja tymczasowa)
using System.Windows;

namespace P02WeatherForecast;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        txtCities.Text = string.Join(Environment.NewLine, "Warszawa", "Kraków", "Gdańsk", "Berlin", "Paryż", "Tokio");
    }

    private void MenuClear_Click(object sender, RoutedEventArgs e) { tbResults.Text = ""; lvLog.Items.Clear(); }
    private void MenuExit_Click(object sender, RoutedEventArgs e) => Close();
    private void MenuAbout_Click(object sender, RoutedEventArgs e) =>
        MessageBox.Show("Dzień 11 – kontenery, style i programowanie asynchroniczne w WPF.", "O programie");

    //private void btnSync_Click(object sender, RoutedEventArgs e) { }
    private void btnAsync1_Click(object sender, RoutedEventArgs e) { }
    private void btnAsync2_Click(object sender, RoutedEventArgs e) { }
    private void btnAsync3_Click(object sender, RoutedEventArgs e) { }
    private void btnAsync4_Click(object sender, RoutedEventArgs e) { }
    private void btnAsync5_Click(object sender, RoutedEventArgs e) { }
    private void btnAsync6_Click(object sender, RoutedEventArgs e) { }
    private void btnSync_Click(object sender, RoutedEventArgs e)
    {
        tbResults.Text = ""; lvLog.Items.Clear();
        foreach (string city in txtCities.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
        {
            lvLog.Items.Add($"Pobieram {city}...");
            double temperature = _service.GetTemperature(city);   // blokuje wątek UI
            tbResults.Text += $"{city}: {temperature:F1} °C{Environment.NewLine}";
        }
    }
}