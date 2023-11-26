using Kompas6API5;
using Kompas6Constants3D;
using Kompas6Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasAPI7;
using System.Diagnostics;
using System.Security.Cryptography;

namespace ChandelierPlugin.Model
{
    public class Builder
    {
        private Wrapper _wrapper = new Wrapper();
        private KompasObject _kompas;
        private ksPart _part;
        private ksEntity _entityDraw;
        private ksDocument3D _doc3D;

        private double radiusInnerCircle;
        private double radiusOuterCircle;
        private double radiusBaseCircle;
        private double foundationThickness;
        private int lampsAmount;
        private double lampRadius;

        public Builder()
        {
            if (!this._wrapper.ConnectToKompas())
            {
                Console.WriteLine("Не удалось подключиться к KOMPAS-3D.");
                return;
            }

            _kompas = _wrapper.Kompas;
            _doc3D = _wrapper.CreateDocument3D();
            _doc3D.Create();
            _part = _wrapper.Part;
        }

        public void BuildDetail(Parameters parameters)
        {
            radiusInnerCircle = parameters.ParametersDict[ParameterType.RadiusInnerCircle].CurrentValue;
            radiusOuterCircle = parameters.ParametersDict[ParameterType.RadiusOuterCircle].CurrentValue;
            radiusBaseCircle = parameters.ParametersDict[ParameterType.RadiusBaseCircle].CurrentValue;
            foundationThickness = parameters.ParametersDict[ParameterType.FoundationThickness].CurrentValue;
            lampsAmount = (int)parameters.ParametersDict[ParameterType.LampsAmount].CurrentValue;
            lampRadius = parameters.ParametersDict[ParameterType.LampRadius].CurrentValue;

            BuildBase(radiusInnerCircle, radiusOuterCircle, radiusBaseCircle);

            //BuildExtrusion(foundationThickness);
            //BuildWiresTubes(radiusBaseCircle, 20, foundationThickness / 2);
            //BuildLamps(lampsAmount, lampRadius);
        }

        private void BuildBase(double radiusInnerCircle, double radiusOuterCircle, double radiusBaseCircle)
        {
            var sketch = this.CreateSketch(Obj3dType.o3d_planeXOZ, null);
            var document2d = (ksDocument2D)sketch.BeginEdit();
            document2d.ksCircle(0, 0, radiusBaseCircle, 1);
            document2d.ksCircle(0, 0, radiusInnerCircle, 1);
            document2d.ksCircle(0, 0, radiusOuterCircle, 1);
            sketch.EndEdit();

            СreateExtrusion(sketch, foundationThickness, true);
        }

        private void BuildLamps(int lampsAmount, double lampRadius)
        {

        }

        private void BuildWiresTubes(double distanceFromOrigin, double radius, double sketchHeight)
        {
            const int pTop_part = -1;
            const int o3d_sketch = 5;
            const int o3d_planeYOZ = 4;


            // Создаем плоскость YOZ
            ksEntity planeYOZ = _part.NewEntity(o3d_sketch);
            ksSketchDefinition planeYOZDefinition = planeYOZ.GetDefinition();
            ksEntity entityPlaneYOZ = _part.GetDefaultEntity(o3d_planeYOZ);
            planeYOZDefinition.SetPlane(entityPlaneYOZ);
            planeYOZ.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D planeYOZDocument2D = planeYOZDefinition.BeginEdit();

            // Рассчитываем координаты центра окружности
            double yCenter = distanceFromOrigin; // расстояние от центра координат по оси Y

            planeYOZDocument2D.ksCircle(0, 12, radius, 1);

            // Выходим из режима редактирования эскиза
            planeYOZDefinition.EndEdit();
        }


        private ksSketchDefinition CreateSketch(Obj3dType planeType, ksEntity offsetPlane)
        {
            var plane = (ksEntity)_part.GetDefaultEntity((short)planeType);
            var sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            var ksSketch = (ksSketchDefinition)sketch.GetDefinition();

            if (offsetPlane != null)
            {
                ksSketch.SetPlane(offsetPlane);
                sketch.Create();
                return ksSketch;
            }

            ksSketch.SetPlane(plane);
            sketch.Create();
            return ksSketch;
        }

        private void СreateExtrusion(ksSketchDefinition sketch, double depth, bool side = true)
        {
            var extrusionEntity = (ksEntity)_part.NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity.GetDefinition();

            extrusionDef.SetSideParam(side, (short)End_Type.etBlind, depth);
            extrusionDef.directionType = side ? (short)Direction_Type.dtNormal : (short)Direction_Type.dtReverse;
            extrusionDef.SetSketch(sketch);
            extrusionEntity.Create();
        }
    }
}
