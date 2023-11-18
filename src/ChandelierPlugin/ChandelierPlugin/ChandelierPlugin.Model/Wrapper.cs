using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using KAPITypes;
using Kompas6API5;

namespace ChandelierPlugin.Model
{
    public class Wrapper
    {
        public void ConnectOrOpenCAD()
        {
            // Создаем экземпляр KOMPAS-3D
            KompasObject kompas = null;
            try
            {
                kompas = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при создании экземпляра KOMPAS-3D: " + ex.Message);
                return;
            }

            // Подключаемся к активной сессии KOMPAS-3D
            try
            {
                kompas.Visible = true; // Делаем KOMPAS-3D видимым
                kompas.ActivateControllerAPI(); // Активируем API контроллера
                Console.WriteLine("Успешно подключено к активной сессии KOMPAS-3D");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при подключении к активной сессии KOMPAS-3D: " + ex.Message);
            }
            finally
            {
                // Освобождаем ресурсы
                if (kompas != null)
                {
                    Marshal.ReleaseComObject(kompas);
                }
            }
        }
    }
}