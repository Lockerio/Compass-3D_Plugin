namespace ChandelierPlugin.Model
{
    /// <summary>
    /// Представляет параметр с текущим значением, максимальным и минимальным
    /// значениями.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса Parameter с указанными
        /// значениями.
        /// </summary>
        /// <param name="currentValue">Текущее значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        /// <param name="minValue">Минимальное значение параметра.</param>
        public Parameter(
            double currentValue,
            double maxValue,
            double minValue)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
            MinValue = minValue;
        }

        /// <summary>
        /// Получает или задает текущее значение параметра.
        /// </summary>
        public double CurrentValue { get; set; }

        /// <summary>
        /// Получает или задает максимальное значение параметра.
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Получает или задает минимальное значение параметра.
        /// </summary>
        public double MinValue { get; set; }
    }
}