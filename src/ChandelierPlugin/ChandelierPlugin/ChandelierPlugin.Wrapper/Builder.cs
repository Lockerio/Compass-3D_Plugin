namespace ChandelierPlugin.Model
{
    using System;
    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// Класс для построения деталей в KOMPAS-3D.
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Получает или устанавливает радиус внутреннего круга.
        /// </summary>
        public double RadiusInnerCircle;

        /// <summary>
        /// Получает или устанавливает радиус внешнего круга.
        /// </summary>
        public double RadiusOuterCircle;

        /// <summary>
        /// Получает или устанавливает радиус круга основания.
        /// </summary>
        public double RadiusBaseCircle;

        /// <summary>
        /// Получает или устанавливает толщину фундамента.
        /// </summary>
        public double FoundationThickness;

        /// <summary>
        /// Получает или устанавливает количество ламп.
        /// </summary>
        public int LampsAmount;

        /// <summary>
        /// Радиус лампы.
        /// </summary>
        public double LampRadius;

        /// <summary>
        /// Экземпляр класса обертки.
        /// </summary>
        private readonly Wrapper _wrapper = new Wrapper();

        // TODO: XML
        // TODO: RSDN
        public ksDocument3D doc3D;

        /// <summary>
        /// Создает новое подключению к компасу.
        /// </summary>
        public void CheckOrCreateKompasConnection()
        {
            if (!_wrapper.ConnectToKompas())
            {
                throw new ArgumentException("Не удалось подключиться к KOMPAS-3D.");
            }
        }

        /// <summary>
        /// Создает новый документ.
        /// </summary>
        public void CreateNewDocument()
        {
            doc3D = _wrapper.CreateDocument3D();
            doc3D.Create();
        }

        /// <summary>
        /// Строит деталь на основе заданных параметров.
        /// </summary>
        /// <param name="parameters">Параметры для построения детали.</param>
        public void BuildDetail(Parameters parameters)
        {
            RadiusInnerCircle = parameters.
                ParametersDict[ParameterType.RadiusInnerCircle].CurrentValue;
            RadiusOuterCircle = parameters.
                ParametersDict[ParameterType.RadiusOuterCircle].CurrentValue;
            RadiusBaseCircle = parameters.
                ParametersDict[ParameterType.RadiusBaseCircle].CurrentValue;
            FoundationThickness = parameters.
                ParametersDict[ParameterType.FoundationThickness].
                CurrentValue;
            LampsAmount = (int)parameters.
                ParametersDict[ParameterType.LampsAmount].CurrentValue;
            LampRadius = parameters.
                ParametersDict[ParameterType.LampRadius].CurrentValue;

            BuildBase(
                RadiusInnerCircle,
                RadiusOuterCircle,
                RadiusBaseCircle);
            BuildWiresTubes(15);
            BuildLamps(LampsAmount, LampRadius);
        }

        /// <summary>
        /// Строит основание детали.
        /// </summary>
        /// <param name="radiusInnerCircle">Радиус внутреннего круга.</param>
        /// <param name="radiusOuterCircle">Радиус внешнего круга.</param>
        /// <param name="radiusBaseCircle">Радиус базового круга.</param>
        private void BuildBase(
            double radiusInnerCircle,
            double radiusOuterCircle,
            double radiusBaseCircle)
        {
            var sketch = _wrapper.CreateSketch(Obj3dType.o3d_planeXOY, null);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(0, 0, radiusBaseCircle, 1);
            document2d.ksCircle(0, 0, radiusInnerCircle, 1);
            document2d.ksCircle(0, 0, radiusOuterCircle, 1);
            sketch.EndEdit();

            _wrapper.CreateExtrusion(sketch, FoundationThickness, true);
        }

        /// <summary>
        /// Строит трубы под провода.
        /// </summary>
        /// <param name="radius">Радиус труб и проводов.</param>
        private void BuildWiresTubes(double radius)
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(
                Obj3dType.o3d_planeXOZ,
                RadiusBaseCircle);
            var sketch = _wrapper.
                CreateSketch(Obj3dType.o3d_planeXOZ, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(
                0,
                -FoundationThickness / 2,
                radius,
                1);
            sketch.EndEdit();

            var extrusionDef = _wrapper.
                CreateExtrusionToNearSurface(sketch, false);
            _wrapper.CreateCircularCopy(3, extrusionDef);

            extrusionDef = _wrapper.
                CreateExtrusionToNearSurface(sketch, true);
            _wrapper.CreateCircularCopy(3, extrusionDef);
        }

        /// <summary>
        /// Строит лампы детали.
        /// </summary>
        /// <param name="lampsAmount">Количество ламп.</param>
        /// <param name="lampRadius">Радиус лампы.</param>
        private void BuildLamps(int lampsAmount, double lampRadius)
        {
            var sketch = _wrapper.
                CreateSketch(Obj3dType.o3d_planeXOY, null);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            var offset = (RadiusOuterCircle + RadiusInnerCircle) / 2;
            document2d.ksCircle(offset, 0, lampRadius, 1);
            sketch.EndEdit();

            var extrusionDef = _wrapper.
                CreateExtrusion(sketch, 20, false);
            _wrapper.CreateCircularCopy(lampsAmount, extrusionDef);
        }
    }
}
