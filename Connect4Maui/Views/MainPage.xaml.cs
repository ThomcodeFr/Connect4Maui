namespace Connect4Maui.Views
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Va à la page de jeu.
        /// </summary>
        private void GoToGamePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());
        }

        /// <summary>
        /// Quitte l'application.
        /// </summary>
        private void QuitBtn(object sender, EventArgs e)
        {
            Application.Current?.Quit();
        }
    }

}