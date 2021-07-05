namespace CreateClassesFromSqlServer.Classes
{
    /// <summary>
    /// Container for language ComboBox
    /// </summary>
    public class ComboLanguage
    {
        /// <summary>
        /// Text to display
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// For passing to <see cref="DataOperations.Create"/>
        /// </summary>
        public Language Language { get; set; }
        public override string ToString() => Display;
    }
}