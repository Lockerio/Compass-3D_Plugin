namespace ChandelierPlugin.Model
{
    using System;

    /// <summary>
    /// Статический класс, предоставляющий методы для проверки диапазона
    /// чисел.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проверяет, что значение находится в заданном числовом диапазоне.
        /// </summary>
        /// <param name="value">Проверяемое число.</param>
        /// <param name="min">Минимальное значение диапазона.</param>
        /// <param name="max">Максимальное значение диапазона.</param>
        /// <exception cref="Exception">Выбрасывается, если число не
        /// находится в допустимом диапазоне.</exception>
        public static void AssertNumberIsInRange(
            double value,
            double min,
            double max)
        {
            if (IsNumberInRange(value, min, max))
            {
                return;
            }

            throw new Exception("Ваше число не попадает в диапазон"
                                + " доступных чисел!");
        }

        /// <summary>
        /// Проверяет, что значение находится в заданном числовом диапазоне.
        /// </summary>
        /// <param name="value">Проверяемое число.</param>
        /// <param name="min">Минимальное значение диапазона.</param>
        /// <param name="max">Максимальное значение диапазона.</param>
        /// <returns>True, если число находится в допустимом диапазоне. В
        /// противном случае - false.</returns>
        private static bool IsNumberInRange(
            double value,
            double min,
            double max)
        {
            return min <= value && value <= max;
        }
    }
}