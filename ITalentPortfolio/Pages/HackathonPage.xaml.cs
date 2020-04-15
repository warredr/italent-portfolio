using Plugin.TextToSpeech;
using System.Linq;
using System.Text;
using System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ITalentPortfolio.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HackathonPage : Page
    {
        private bool _speechStarted = false;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancellationTokenSource;

        public HackathonPage()
        {
            this.InitializeComponent();

            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        private async void textToSpeechButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (!_speechStarted)
            {
                _speechStarted = true;
                var languages = await CrossTextToSpeech.Current.GetInstalledLanguages();
                var language = languages.FirstOrDefault(l => l.Language.Equals("nl-BE"));
                var text = GetCompleteText();

                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationToken = _cancellationTokenSource.Token;

                await CrossTextToSpeech.Current.Speak(text, language, 1, 1, 1, _cancellationToken);
            }
            else
            {
                _speechStarted = false;
                _cancellationTokenSource.Cancel();
            }
        }

        private string GetCompleteText()
        {
            var wait = " ... ";
            var sb = new StringBuilder();
            sb.Append("Welcome to the section about the Sint Oda Hackathon. ... ");
            sb.Append(Application.Current.Resources["descriptionHackathon"].ToString());
            sb.Append(wait);
            sb.Append("Next up: the report of the activity. ...");
            sb.Append(Application.Current.Resources["reportHackathon-01"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportHackathon-02"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportHackathon-03"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportHackathon-04"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportHackathon-05"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportHackathon-06"].ToString());
            sb.Append(wait);
            sb.Append("My personal reflection:");
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reflectionHackathon-01"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reflectionHackathon-02"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reflectionHackathon-03"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reflectionHackathon-04"].ToString());

            return sb.ToString();
        }

    }
}
