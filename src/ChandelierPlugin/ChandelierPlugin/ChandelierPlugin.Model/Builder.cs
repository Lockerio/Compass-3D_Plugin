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

            this._kompas = this._wrapper.Kompas;
            this._doc3D = this._wrapper.CreateDocument3D();
            this._doc3D.Create();
            this._part = this._wrapper.Part;
        }

        public void BuildDetail(Parameters parameters)
        {
            this.radiusInnerCircle = parameters.ParametersDict[ParameterType.RadiusInnerCircle].CurrentValue;
            this.radiusOuterCircle = parameters.ParametersDict[ParameterType.RadiusOuterCircle].CurrentValue;
            this.radiusBaseCircle = parameters.ParametersDict[ParameterType.RadiusBaseCircle].CurrentValue;
            this.foundationThickness = parameters.ParametersDict[ParameterType.FoundationThickness].CurrentValue;
            this.lampsAmount = (int)parameters.ParametersDict[ParameterType.LampsAmount].CurrentValue;
            this.lampRadius = parameters.ParametersDict[ParameterType.LampRadius].CurrentValue;

            this.BuildBase(this.radiusInnerCircle, this.radiusOuterCircle, this.radiusBaseCircle);
            this.BuildWiresTubes(15);
            this.BuildLamps(this.lampsAmount, this.lampRadius);
        }

        private void BuildBase(double radiusInnerCircle, double radiusOuterCircle, double radiusBaseCircle)
        {
            var sketch = _wrapper.CreateSketch(Obj3dType.o3d_planeXOY, null);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(0, 0, radiusBaseCircle, 1);
            document2d.ksCircle(0, 0, radiusInnerCircle, 1);
            document2d.ksCircle(0, 0, radiusOuterCircle, 1);
            sketch.EndEdit();

            _wrapper.СreateExtrusion(sketch, this.foundationThickness, true);
        }

        private void BuildWiresTubes(double radius)
        {
            var offsetWidthEntity = _wrapper.CreateOffsetPlane(Obj3dType.o3d_planeXOZ, this.radiusBaseCircle);
            var sketch = _wrapper.CreateSketch(Obj3dType.o3d_planeXOZ, offsetWidthEntity);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            document2d.ksCircle(0, -this.foundationThickness / 2, radius, 1);
            sketch.EndEdit();

            var extrusionDef = _wrapper.СreateExtrusionToNearSurface(sketch, false);
            _wrapper.CreateCircularCopy(3, extrusionDef);

            extrusionDef = _wrapper.СreateExtrusionToNearSurface(sketch, true);
            _wrapper.CreateCircularCopy(3, extrusionDef);
        }

        private void BuildLamps(int lampsAmount, double lampRadius)
        {
            var sketch = _wrapper.CreateSketch(Obj3dType.o3d_planeXOY, null);
            var document2d = (ksDocument2D)sketch.BeginEdit();

            var offset = (this.radiusOuterCircle + this.radiusInnerCircle) / 2;
            document2d.ksCircle(offset, 0, lampRadius, 1);
            sketch.EndEdit();

            var extrusionDef = _wrapper.СreateExtrusion(sketch, 20, false);
            _wrapper.CreateCircularCopy(lampsAmount, extrusionDef);
        }
    }
}
