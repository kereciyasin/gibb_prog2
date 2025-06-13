namespace MeineRestApi.Models
{
    public class Buch
    {
        /// <summary>
        /// Die eindeutige Id des Buches.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Der Titel des Buches.
        /// </summary>
        public string Titel { get; set; }

        /// <summary>
        /// Der Name des Autors.
        /// </summary>
        public string Autor { get; set; }

        /// <summary>
        /// Das Erscheinungsjahr des Buches.
        /// </summary>
        public int Erscheinungsjahr { get; set; }
    }
}
