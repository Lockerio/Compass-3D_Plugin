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
        /// Количество слоев.
        /// </summary>
        public double LayersAmount;

        /// <summary>
        /// Множитель параметров.
        /// </summary>
        public double ParameterMultiplier;

        /// <summary>
        /// Расстояние между слоями.
        /// </summary>
        public double LayerHeight = 0;

        /// <summary>
        /// Экземпляр класса обертки.
        /// </summary>
        private readonly Wrapper _wrapper = new Wrapper();

        // TODO: XML (+)
        // TODO: RSDN (+)
        /// <summary>
        /// Документ в среде КОМПАС-3Д.
        /// </summary>
        public ksDocument3D Doc3D;

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
            Doc3D = _wrapper.CreateDocument3D();
            Doc3D.Create();
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
            LayersAmount = parameters.
                ParametersDict[ParameterType.LayersAmount].CurrentValue;
            ParameterMultiplier = parameters.
                ParametersDict[ParameterType.ParameterMultiplier].CurrentValue;

            for (var i = 0; i < LayersAmount; i++)
            {
                BuildBase(
                    RadiusInnerCircle,
                    RadiusOuterCircle,
                    RadiusBaseCircle,
                    LayerHeight);
                BuildWiresTubes(LayerHeight, 15);
                BuildLamps(LayerHeight, LampsAmount, LampRadius);
                BuildFastening(LayerHeight, 60);

                LayerHeight += -600 + FoundationThickness;

                RadiusInnerCircle *= ParameterMultiplier;
                RadiusOuterCircle *= ParameterMultiplier;
                LampsAmount *= (int)ParameterMultiplier;
            }

            LayerHeight = 0;
        }

        /// <summary>
        /// Строит основание детали.
        /// </summary>
        /// <param name="radiusInnerCircle">Радиус внутреннего круга.</param>
        /// <param name="radiusOuterCircle">Радиус внешнего круга.</param>
        /// <param name="radiusBaseCircle">Радиус базового круга.</param>
        /// <param name="heightOffset">Отступ слоя по высоте.</param>
        private void BuildBase(
            double radiusInnerCircle,
            double radiusOuterCircle,
            double radiusBaseCircle,
            double heightOffset)
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(
                Obj3dType.o3d_planeXOY,
                heightOffset);

            var sketch = _wrapper.CreateSketch(Obj3dType.o3d_planeXOY, offsetWidthEntity);
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
        /// <param name="heightOffset">Отступ слоя по высоте.</param>
        private void BuildWiresTubes(double heightOffset, double radius)
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(
                Obj3dType.o3d_planeXOZ,
                RadiusBaseCircle);
            var sketch = _wrapper.
                CreateSketch(Obj3dType.o3d_planeXOZ, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(
                0,
                heightOffset - (FoundationThickness / 2),
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
        /// <param name="heightOffset">Отступ слоя по высоте.</param>
        private void BuildLamps(double heightOffset, int lampsAmount, double lampRadius)
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(
                Obj3dType.o3d_planeXOY,
                heightOffset);
            var sketch = _wrapper.
                CreateSketch(Obj3dType.o3d_planeXOY, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            var offset = (RadiusOuterCircle + RadiusInnerCircle) / 2;
            document2d.ksCircle(offset, 0, lampRadius, 1);
            sketch.EndEdit();

            var extrusionDef = _wrapper.
                CreateExtrusion(sketch, 20, false);
            _wrapper.CreateCircularCopy(lampsAmount, extrusionDef);
        }

        /// <summary>
        /// Строит крепление между слоями.
        /// </summary>
        /// <param name="heightOffset">Отступ основания крепления каждого слоя.</param>
        /// <param name="radius">Радиус крепления.</param>
        private void BuildFastening(double heightOffset, double radius)
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(
                Obj3dType.o3d_planeXOY,
                heightOffset - FoundationThickness);
            var sketch = _wrapper.
                CreateSketch(Obj3dType.o3d_planeXOY, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(0, 0, radius, 1);
            sketch.EndEdit();

            _wrapper.CreateExtrusionToNearSurface(sketch, false);
        }
    }
}
