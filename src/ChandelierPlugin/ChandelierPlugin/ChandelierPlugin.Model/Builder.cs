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

            BuildWiresTubes(15);
            //BuildWiresTubes(radiusBaseCircle, 20, foundationThickness / 2);
            //BuildLamps(lampsAmount, lampRadius);
        }

        private void BuildBase(double radiusInnerCircle, double radiusOuterCircle, double radiusBaseCircle)
        {
            var sketch = this.CreateSketch(Obj3dType.o3d_planeXOY, null);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(0, 0, radiusBaseCircle, 1);
            document2d.ksCircle(0, 0, radiusInnerCircle, 1);
            document2d.ksCircle(0, 0, radiusOuterCircle, 1);
            sketch.EndEdit();

            this.СreateExtrusion(sketch, this.foundationThickness, true);
        }

        private void BuildWiresTubes(double radius)
        {
            var offsetWidthEntity = this.CreateOffsetPlane(Obj3dType.o3d_planeXOZ, this.radiusBaseCircle);
            var sketch = this.CreateSketch(Obj3dType.o3d_planeXOZ, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(0, -this.foundationThickness / 2, radius, 1);
            sketch.EndEdit();

            var extrusionDef = this.СreateExtrusionToNearSurface(sketch, false);
            CreateCircularCopy(3, extrusionDef);

            extrusionDef = this.СreateExtrusionToNearSurface(sketch, true);
            CreateCircularCopy(3, extrusionDef);
        }

        private void BuildLamps(int lampsAmount, double lampRadius)
        {

        }

        private ksEntity CreateOffsetPlane(Obj3dType plane, double offset)
        {
            var offsetEntity = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var offsetDef = (ksPlaneOffsetDefinition)offsetEntity.GetDefinition();
            offsetDef.SetPlane((ksEntity)_part.NewEntity((short)plane));
            offsetDef.offset = offset;
            offsetDef.direction = false;
            offsetEntity.Create();
            return offsetEntity;
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

        private ksBossExtrusionDefinition СreateExtrusionToNearSurface(ksSketchDefinition sketch, bool side = true)
        {
            var extrusionEntity = (ksEntity)_part.NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity.GetDefinition();

            extrusionDef.SetSideParam(side, (short)End_Type.etUpToNearSurface);
            extrusionDef.directionType = side ? (short)Direction_Type.dtNormal : (short)Direction_Type.dtReverse;
            extrusionDef.SetSketch(sketch);
            extrusionEntity.Create();

            return extrusionDef;
        }

        private void CreateCircularCopy(int count, object definition)
        {
            ksEntity entity = _part.NewEntity((short)Obj3dType.o3d_circularCopy);
            ksCircularCopyDefinition copyDefinition = entity.GetDefinition();
            copyDefinition.SetCopyParamAlongDir(count, 360, true, false);
            ksEntity baseAxisOz = _part.GetDefaultEntity((short)Obj3dType.o3d_axisOZ);
            copyDefinition.SetAxis(baseAxisOz);
            ksEntityCollection entityCollection = copyDefinition.GetOperationArray();
            entityCollection.Add(definition);
            entity.Create();
        }
    }
}
