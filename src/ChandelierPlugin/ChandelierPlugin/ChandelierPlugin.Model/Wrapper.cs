using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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

        public KompasObject Kompas
        {
            get => _kompas;
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
    }
}