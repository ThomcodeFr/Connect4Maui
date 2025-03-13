using Connect4Maui.ViewModels;

namespace Connect4Maui.Views;

public partial class GamePage : ContentPage
{
    public GamePage()
    {
        InitializeComponent();
        BindingContext = new GameViewModel();
    }

    /// <summary>
    /// M�thode appel�e lorsqu'une case est cliqu�e
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnCellTapped(object sender, EventArgs e)
    {
        var viewModel = BindingContext as GameViewModel;
        if (viewModel == null) return;

        var grid = sender as Grid;
        if (grid == null) return;

        // Trouver l'index de la case cliqu�e dans la grille
        var index = GrillePuissance4.ItemsSource.Cast<object>().ToList().IndexOf(grid.BindingContext);
        if (index == -1) return;

        // Calculer la colonne (0 � 6)
        int column = index % 7;

        // Appeler la m�thode PlayMove du ViewModel
        viewModel.PlayMove(column);
    }

    /// <summary>
    /// M�thode appel�e lorsqu'on clique sur le bouton "Recommencer"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnRestartButtonClicked(object sender, EventArgs e)
    {
        var viewModel = BindingContext as GameViewModel;
        viewModel?.RestartGame();
    }
}