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
    }
}