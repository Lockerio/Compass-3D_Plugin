namespace ChandelierPlugin.Model
{
    /// <summary>
    /// Типы параметров, используемые в расчетах.
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// Радиус внешнего круга.
        /// </summary>
        RadiusOuterCircle,

        /// <summary>
        /// Радиус внутреннего круга.
        /// </summary>
        RadiusInnerCircle,

        /// <summary>
        /// Радиус основания.
        /// </summary>
        RadiusBaseCircle,

        /// <summary>
        /// Толщина фундамента.
        /// </summary>
        FoundationThickness,

        /// <summary>
        /// Количество ламп.
        /// </summary>
        LampsAmount,

        /// <summary>
        /// Радиус лампы.
        /// </summary>
        LampRadius,

        /// <summary>
        /// Количество слоев.
        /// </summary>
        LayersAmount,

        /// <summary>
        /// Множитель параметров.
        /// </summary>
        ParameterMultiplier,

        /// <summary>
        /// Неизвестный тип параметра.
        /// </summary>
        Unknown,
    }
}