using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.CognitiveServices.Speech;
using System.Runtime.Serialization.Json;
using System.IO;

namespace LightControl
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognizer recognizer;
        public MainWindow()
        {
            InitializeComponent();

            var basicFactory = SpeechFactory.FromSubscription("738e230c827f4a13b4406fac6d08c179", "westus");
            recognizer = basicFactory.CreateSpeechRecognizer("zh-CN");
            recognizer.FinalResultReceived += Recognizer_FinalResultReceived;
            recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);
        }

        protected override void OnClosed(EventArgs e)
        {
            recognizer.Dispose();
            base.OnClosed(e);
        }

        private async void Recognizer_FinalResultReceived(object sender, SpeechRecognitionResultEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Result.Text))
            {
                string jsonLuis = await GetLuisResultAsync(e.Result.Text);
                ExecuteLuisResult(jsonLuis);
            }
        }

        private async Task<string> GetLuisResultAsync(string text)
        {
            using (var httpClient = new HttpClient())
            {
                string luisEndpointUrl = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/7b893c2e-094e-438e-94df-65b668fc8f2b?subscription-key=21a712d554e44aca954c8c96f950f4ec&verbose=true&timezoneOffset=0&q=";
                return await httpClient.GetStringAsync(luisEndpointUrl + text);
            }
        }

        public class Rootobject
        {
            public string query { get; set; }
            public Topscoringintent topScoringIntent { get; set; }
            public Intent[] intents { get; set; }
            public object[] entities { get; set; }
        }

        public class Topscoringintent
        {
            public string intent { get; set; }
            public float score { get; set; }
        }

        public class Intent
        {
            public string intent { get; set; }
            public float score { get; set; }
        }

        private void ExecuteLuisResult(string jsonLuis)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonLuis)))
            {
                var luisResult = (Rootobject)new DataContractJsonSerializer(typeof(Rootobject)).ReadObject(ms);
                if ("turnon".Equals(luisResult?.topScoringIntent?.intent, StringComparison.OrdinalIgnoreCase))
                {
                    OpenLight();
                }
                else if ("turnoff".Equals(luisResult?.topScoringIntent?.intent, StringComparison.OrdinalIgnoreCase))
                {
                    CloseLight();
                }
            }
        }

        private void OpenLight()
        {
            Dispatcher.Invoke(() =>
            {
                imgLight.Source = new BitmapImage(new Uri("LightOn.png", UriKind.Relative));
            });
        }

        private void CloseLight()
        {
            Dispatcher.Invoke(() =>
            {
                imgLight.Source = new BitmapImage(new Uri("LightOff.png", UriKind.Relative));
            });
        }
    }
}
