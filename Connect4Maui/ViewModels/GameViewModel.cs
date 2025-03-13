using Connect4Maui.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Connect4Maui.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CaseConnect4> Grille { get; set; }
        private Players _currentPlayer;
        private readonly Players _player1;
        private readonly Players _player2;
        private bool _gameEnded;
        private string _currentPlayerText;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Affiche le text du joueur entrain de jouer.
        /// </summary>
        public string CurrentPlayerText
        {
            get => _currentPlayerText;
            set
            {
                _currentPlayerText = value;
                OnPropertyChanged(nameof(CurrentPlayerText));
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public GameViewModel()
        {
            // Initialisation de la grille (6 lignes x 7 colonnes = 42 cases)
            Grille = new ObservableCollection<CaseConnect4>();
            for (int i = 0; i < 42; i++)
            {
                Grille.Add(new CaseConnect4 { Color = Colors.White });
            }

            // Initialisation des joueurs
            _player1 = new Player1();
            _player2 = new Player2();
            _currentPlayer = _player1;

            CurrentPlayerText = "C'est au tour du Joueur 1 (Rouge)";
            _gameEnded = false;
        }

        /// <summary>
        /// Méthode appelée lorsqu'un joueur joue un coup
        /// </summary>
        /// <param name="column"></param>
        public void PlayMove(int column)
        {
            if (_gameEnded) return;

            // Trouver la première case vide dans la colonne (de bas en haut)
            for (int row = 5; row >= 0; row--)
            {
                int index = row * 7 + column;
                if (Grille[index].Color == Colors.White)
                {
                    // Placer le pion
                    Grille[index].Color = _currentPlayer.Color;

                    // Vérifier si le joueur a gagné
                    if (CheckForWin(row, column))
                    {
                        CurrentPlayerText = $"Le Joueur {(_currentPlayer is Player1 ? "1" : "2")} a gagné !";
                        _gameEnded = true;
                        return;
                    }

                    // Changer de joueur
                    SwitchPlayer();
                    return;
                }
            }

            // Si on arrive ici, la colonne est pleine, on ne fait rien
        }

        /// <summary>
        /// Permet de changer de joueur
        /// </summary>
        private void SwitchPlayer()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
            CurrentPlayerText = $"C'est au tour du Joueur {(_currentPlayer is Player1 ? "1" : "2")} ({(_currentPlayer is Player1 ? "Rouge" : "Jaune")})";
        }

        /// <summary>
        /// Vérifie si le joueur actuel a gagné
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool CheckForWin(int row, int column)
        {
            Color playerColor = _currentPlayer.Color;

            // Vérification horizontale
            int count = 0;
            for (int c = 0; c < 7; c++)
            {
                if (Grille[row * 7 + c].Color == playerColor)
                {
                    count++;
                    if (count == 4) return true;
                }
                else
                {
                    count = 0;
                }
            }

            // Vérification verticale
            count = 0;
            for (int r = 0; r < 6; r++)
            {
                if (Grille[r * 7 + column].Color == playerColor)
                {
                    count++;
                    if (count == 4) return true;
                }
                else
                {
                    count = 0;
                }
            }

            // Vérification diagonale (haut-gauche à bas-droite)
            count = 0;
            int startRow = row - Math.Min(row, column);
            int startCol = column - Math.Min(row, column);
            while (startRow < 6 && startCol < 7)
            {
                if (Grille[startRow * 7 + startCol].Color == playerColor)
                {
                    count++;
                    if (count == 4) return true;
                }
                else
                {
                    count = 0;
                }
                startRow++;
                startCol++;
            }

            // Vérification diagonale (bas-gauche à haut-droite)
            count = 0;
            startRow = row + Math.Min(5 - row, column);
            startCol = column - Math.Min(5 - row, column);
            while (startRow >= 0 && startCol < 7)
            {
                if (Grille[startRow * 7 + startCol].Color == playerColor)
                {
                    count++;
                    if (count == 4) return true;
                }
                else
                {
                    count = 0;
                }
                startRow--;
                startCol++;
            }

            return false;
        }

        /// <summary>
        /// Rédémarre la partie
        /// </summary>
        public void RestartGame()
        {
            for (int i = 0; i < 42; i++)
            {
                Grille[i].Color= Colors.White;
            }
            _currentPlayer = _player1;
            CurrentPlayerText = "C'est au tour du Joueur 1 (Rouge)";
            _gameEnded = false;
        }

        /// <summary>
        /// Permet de notifier le changement de valeur d'une propriété
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}