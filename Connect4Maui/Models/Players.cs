using Connect4Maui.Services;

namespace Connect4Maui.Models
{
    /// <summary>
    /// Classe de gestion des joueurs
    /// </summary>
    public class Players : IPlayers
    {
        public Color Color { get; protected set; }

        protected Players(Color color)
        {
            Color = color;
        }
    }

    /// <summary>
    /// Joueur n°1
    /// </summary>
    public class Player1 : Players
    {
        public Player1() : base(Colors.Red)
        {
        }
    }

    /// <summary>
    /// Joueur n°2
    /// </summary>
    public class Player2 : Players
    {
        public Player2() : base(Colors.Yellow)
        {
        }
    }
}
