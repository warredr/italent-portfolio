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
    public sealed partial class StudentJobPage : Page
    {
        private bool _speechStarted = false;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancellationTokenSource;

        public StudentJobPage()
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
            sb.Append("Welcome to the section about my summer job as a .NET developer. ... ");
            sb.Append(Application.Current.Resources["descriptionStudentJob"].ToString());
            sb.Append(wait);
            sb.Append("Next up: the report of the activity. ...");
            sb.Append(Application.Current.Resources["reportStudentJob-01"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportStudentJob-02"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportStudentJob-03"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportStudentJob-04"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportStudentJob-05"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportStudentJob-06"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportStudentJob-07"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportStudentJob-08"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reportStudentJob-09"].ToString());
            sb.Append(wait);
            sb.Append("My personal reflection:");
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reflectionStudentJob-01"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reflectionStudentJob-02"].ToString());
            sb.Append(wait);
            sb.Append(Application.Current.Resources["reflectionStudentJob-03"].ToString());

            return sb.ToString();
        }
    }
}
