namespace ChandelierPlugin.Model
{
    using System.Collections.Generic;
    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// Класс для построения деталей в KOMPAS-3D.
    /// </summary>
    public class Builder
    {
        // TODO: сделать поля приватными (+)

        /// <summary>
        /// Расстояние между слоями.
        /// </summary>
        private readonly double _wiresRadius = 15.0;

        /// <summary>
        /// Расстояние между слоями.
        /// </summary>
        private readonly double _fasteningRadius = 60.0;

        /// <summary>
        /// Расстояние между слоями.
        /// </summary>
        private readonly int _layersOffset = 600;

        /// <summary>
        /// Словарь текущих значений всех параметров.
        /// </summary>
        public Dictionary<ParameterType, double> ParametersDict;

        /// <summary>
        /// Расстояние между слоями.
        /// </summary>
        public double LayerHeight { get; set; }

        /// <summary>
        /// Экземпляр класса обертки.
        /// </summary>
        private readonly Wrapper _wrapper = new Wrapper();

        /// <summary>
        /// Строит деталь на основе заданных параметров.
        /// </summary>
        /// <param name="parameters">Параметры для построения детали.</param>
        public void BuildDetail(Dictionary<ParameterType, double> parametersDict)
        {
            _wrapper.ConnectToKompas();
            _wrapper.CreateDocument3D();

            ParametersDict = parametersDict;
            LayerHeight = 0;

            for (var i = 0; i < ParametersDict[ParameterType.LayersAmount]; i++)
            {
                BuildBase();
                BuildWiresTubes();
                BuildLamps();
                BuildFastening();

                // TODO: магическое число (+)
                LayerHeight += -_layersOffset + ParametersDict[ParameterType.FoundationThickness];

                ParametersDict[ParameterType.RadiusInnerCircle] *=
                    ParametersDict[ParameterType.ParameterMultiplier];
                ParametersDict[ParameterType.RadiusOuterCircle] *=
                    ParametersDict[ParameterType.ParameterMultiplier];
                ParametersDict[ParameterType.LampsAmount] *= (int)ParametersDict[ParameterType.ParameterMultiplier];
            }

            LayerHeight = 0;
        }

        /// <summary>
        /// Строит основание детали.
        /// </summary>
        private void BuildBase()
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(
                Obj3dType.o3d_planeXOY,
                LayerHeight);

            var sketch = _wrapper.CreateSketch(Obj3dType.o3d_planeXOY, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(
                0,
                0,
                ParametersDict[ParameterType.RadiusBaseCircle],
                1);
            document2d.ksCircle(
                0,
                0,
                ParametersDict[ParameterType.RadiusInnerCircle],
                1);
            document2d.ksCircle(
                0,
                0,
                ParametersDict[ParameterType.RadiusOuterCircle],
                1);
            sketch.EndEdit();

            _wrapper.CreateExtrusion(
                sketch,
                ParametersDict[ParameterType.FoundationThickness],
                true);
        }

        /// <summary>
        /// Строит трубы под провода.
        /// </summary>
        /// <param name="radius">Радиус труб и проводов.</param>
        /// <param name="heightOffset">Отступ слоя по высоте.</param>
        private void BuildWiresTubes()
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(
                Obj3dType.o3d_planeXOZ,
                ParametersDict[ParameterType.RadiusBaseCircle]);
            var sketch = _wrapper.
                CreateSketch(Obj3dType.o3d_planeXOZ, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(
                0,
                LayerHeight - (ParametersDict[ParameterType.FoundationThickness] / 2),
                _wiresRadius,
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
        private void BuildLamps()
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(
                Obj3dType.o3d_planeXOY,
                LayerHeight);
            var sketch = _wrapper.
                CreateSketch(Obj3dType.o3d_planeXOY, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            var offset = (ParametersDict[ParameterType.RadiusOuterCircle]
                          + ParametersDict[ParameterType.RadiusInnerCircle]) / 2;
            document2d.ksCircle(
                offset,
                0,
                ParametersDict[ParameterType.LampRadius],
                1);
            sketch.EndEdit();

            var extrusionDef = _wrapper.
                CreateExtrusion(sketch, 20, false);
            _wrapper.CreateCircularCopy(
                (int)ParametersDict[ParameterType.LampsAmount],
                extrusionDef);
        }

        /// <summary>
        /// Строит крепление между слоями.
        /// </summary>
        /// <param name="heightOffset">Отступ основания крепления каждого слоя.</param>
        /// <param name="radius">Радиус крепления.</param>
        private void BuildFastening()
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(
                Obj3dType.o3d_planeXOY,
                LayerHeight - ParametersDict[ParameterType.FoundationThickness]);
            var sketch = _wrapper.
                CreateSketch(Obj3dType.o3d_planeXOY, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(0, 0, _fasteningRadius, 1);
            sketch.EndEdit();

            _wrapper.CreateExtrusionToNearSurface(sketch, false);
        }
    }
}
