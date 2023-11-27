using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using KAPITypes;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using KompasAPI7;
using KompasLibrary;

namespace ChandelierPlugin.Model
{
    public class Wrapper
    {
        private KompasObject _kompas;
        private ksPart _part;

        public KompasObject Kompas
        {
            get => _kompas;
        }

        public ksPart Part
        {
            get => _part;
        }

        public bool ConnectToKompas()
        {
            try
            {
                _kompas = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
                _kompas.Visible = true;
                _kompas.ActivateControllerAPI();

                Console.WriteLine("Успешно подключено к активной сессии KOMPAS-3D");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при подключении к активной сессии KOMPAS-3D: " + ex.Message);
                return false;
            }
        }

        public ksDocument3D CreateDocument3D()
        {
            ksDocument3D document3D = Kompas.Document3D();
            document3D.Create();
            _part = document3D.GetPart((int)Part_Type.pTop_Part);
            return document3D;
        }

        public ksEntity CreateOffsetPlane(Obj3dType plane, double offset)
        {
            var offsetEntity = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var offsetDef = (ksPlaneOffsetDefinition)offsetEntity.GetDefinition();
            offsetDef.SetPlane((ksEntity)this._part.NewEntity((short)plane));
            offsetDef.offset = offset;
            offsetDef.direction = false;
            offsetEntity.Create();
            return offsetEntity;
        }

        public ksSketchDefinition CreateSketch(Obj3dType planeType, ksEntity offsetPlane)
        {
            var plane = (ksEntity)this._part.GetDefaultEntity((short)planeType);
            var sketch = (ksEntity)this._part.NewEntity((short)Obj3dType.o3d_sketch);
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

        public ksBossExtrusionDefinition СreateExtrusion(ksSketchDefinition sketch, double depth, bool side = true)
        {
            var extrusionEntity = (ksEntity)this._part.NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity.GetDefinition();

            extrusionDef.SetSideParam(side, (short)End_Type.etBlind, depth);
            extrusionDef.directionType = side ? (short)Direction_Type.dtNormal : (short)Direction_Type.dtReverse;
            extrusionDef.SetSketch(sketch);
            extrusionEntity.Create();

            return extrusionDef;
        }

        public ksBossExtrusionDefinition СreateExtrusionToNearSurface(ksSketchDefinition sketch, bool side = true)
        {
            var extrusionEntity = (ksEntity)this._part.NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity.GetDefinition();

            extrusionDef.SetSideParam(side, (short)End_Type.etUpToNearSurface);
            extrusionDef.directionType = side ? (short)Direction_Type.dtNormal : (short)Direction_Type.dtReverse;
            extrusionDef.SetSketch(sketch);
            extrusionEntity.Create();

            return extrusionDef;
        }

        public void CreateCircularCopy(int count, object definition)
        {
            ksEntity entity = this._part.NewEntity((short)Obj3dType.o3d_circularCopy);
            ksCircularCopyDefinition copyDefinition = entity.GetDefinition();
            copyDefinition.SetCopyParamAlongDir(count, 360, true, false);
            ksEntity baseAxisOz = this._part.GetDefaultEntity((short)Obj3dType.o3d_axisOZ);
            copyDefinition.SetAxis(baseAxisOz);
            ksEntityCollection entityCollection = copyDefinition.GetOperationArray();
            entityCollection.Add(definition);
            entity.Create();
        }
    }
}