namespace ChandelierPlugin.Model
{
    using System;
    using System.Runtime.InteropServices;
    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// Класс-обертка для работы с KOMPAS-3D.
    /// </summary>
    public class Wrapper
    {
        public ksPart Part { get; set; }

        /// <summary>
        /// Получает объект KOMPAS-3D.
        /// </summary>
        public KompasObject Kompas { get; set; }

        /// <summary>
        /// Подключается к активной сессии KOMPAS-3D.
        /// </summary>
        /// <returns>True, если подключение успешно.
        /// В противном случае - false.</returns>
        public void ConnectToKompas()
        {
            try
            {
                Kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                Console.WriteLine("Уже подключено к активной сессии KOMPAS-3D");
            }
            catch (COMException)
            {
                try
                {
                    Kompas = (KompasObject)Activator.CreateInstance(
                        Type.GetTypeFromProgID("KOMPAS.Application.5"));
                    Kompas.Visible = true;
                    Kompas.ActivateControllerAPI();

                    Console.WriteLine("Успешно подключено к активной сессии KOMPAS-3D");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при подключении к активной сессии KOMPAS-3D: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Неожиданная ошибка: " + ex.Message);
            }
        }

        /// <summary>
        /// Создает 3D-документ KOMPAS-3D.
        /// </summary>
        /// <returns>Объект 3D-документа KOMPAS-3D.</returns>
        public void CreateDocument3D()
        {
            var document3D = (ksDocument3D)Kompas.Document3D();
            document3D.Create();
            Part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Создает смещенную плоскость относительно другой плоскости.
        /// </summary>
        /// <param name="plane">Тип базовой плоскости.</param>
        /// <param name="offset">Величина смещения.</param>
        /// <returns>Экземпляр смещенной плоскости.</returns>
        public ksEntity CreateOffsetPlane(Obj3dType plane, double offset)
        {
            var offsetEntity = (ksEntity)Part.
                NewEntity((short)Obj3dType.o3d_planeOffset);
            var offsetDef = (ksPlaneOffsetDefinition)offsetEntity.
                GetDefinition();

            offsetDef.SetPlane((ksEntity)Part.NewEntity((short)plane));
            offsetDef.offset = offset;
            offsetDef.direction = false;
            offsetEntity.Create();

            return offsetEntity;
        }

        /// <summary>
        /// Создает эскиз на заданной плоскости.
        /// </summary>
        /// <param name="planeType">Тип плоскости, на которой создается
        /// эскиз.</param>
        /// <param name="offsetPlane">Смещенная плоскость
        /// (может быть null).</param>
        /// <returns>Определение созданного эскиза.</returns>
        public ksSketchDefinition CreateSketch(
            Obj3dType planeType,
            ksEntity offsetPlane)
        {
            var plane = (ksEntity)Part.
                GetDefaultEntity((short)planeType);
            var sketch = (ksEntity)Part.
                NewEntity((short)Obj3dType.o3d_sketch);
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

        /// <summary>
        /// Создает выдавливание на основе эскиза.
        /// </summary>
        /// <param name="sketch">Эскиз, на основе которого создается
        /// выдавливание.</param>
        /// <param name="depth">Глубина выдавливания.</param>
        /// <param name="side">Направление выдавливания
        /// (true - в одну сторону, false - в обратную).</param>
        /// <returns>Определение созданного выдавливания.</returns>
        public ksBossExtrusionDefinition CreateExtrusion(
            ksSketchDefinition sketch,
            double depth,
            bool side = true)
        {
            var extrusionEntity = (ksEntity)Part.
                NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity.
                GetDefinition();

            extrusionDef.SetSideParam(side, (short)End_Type.etBlind, depth);
            extrusionDef.directionType =
                side ? (short)Direction_Type.dtNormal :
                    (short)Direction_Type.dtReverse;
            extrusionDef.SetSketch(sketch);
            extrusionEntity.Create();

            return extrusionDef;
        }

        /// <summary>
        /// Создает выдавливание до ближайшей поверхности на основе эскиза.
        /// </summary>
        /// <param name="sketch">Эскиз, на основе которого создается
        /// выдавливание.</param>
        /// <param name="side">Направление выдавливания
        /// (true - в одну сторону, false - в обратную).</param>
        /// <returns>Определение созданного выдавливания.</returns>
        public ksBossExtrusionDefinition CreateExtrusionToNearSurface(
            ksSketchDefinition sketch,
            bool side = true)
        {
            var extrusionEntity = (ksEntity)Part.
                NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity.
                GetDefinition();

            extrusionDef.SetSideParam(
                side,
                (short)End_Type.etUpToNearSurface);
            extrusionDef.directionType =
                side ? (short)Direction_Type.dtNormal :
                    (short)Direction_Type.dtReverse;
            extrusionDef.SetSketch(sketch);
            extrusionEntity.Create();

            return extrusionDef;
        }

        /// <summary>
        /// Создает кольцевую копию объекта.
        /// </summary>
        /// <param name="count">Количество копий.</param>
        /// <param name="definition">Определение объекта для
        /// копирования.</param>
        public void CreateCircularCopy(int count, object definition)
        {
            ksEntity entity = Part.
                NewEntity((short)Obj3dType.o3d_circularCopy);
            ksCircularCopyDefinition copyDefinition = entity.GetDefinition();
            copyDefinition.SetCopyParamAlongDir(
                count,
                360,
                true,
                false);
            ksEntity baseAxisOz = Part.
                GetDefaultEntity((short)Obj3dType.o3d_axisOZ);
            copyDefinition.SetAxis(baseAxisOz);
            ksEntityCollection entityCollection =
                copyDefinition.GetOperationArray();

            entityCollection.Add(definition);
            entity.Create();
        }
    }
}