using System.ComponentModel;

namespace Connect4Maui.Models
{
    // INotifyPropertyChanged -> Permet de notifier quand l'UI lorsque la couleur change
    public partial class CaseConnect4 : INotifyPropertyChanged
    {
        private Color? _color;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Couleur de la case
        /// </summary>
        public Color Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }
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
