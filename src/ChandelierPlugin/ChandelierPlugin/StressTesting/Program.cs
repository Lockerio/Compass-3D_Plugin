namespace StressTesting
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using ChandelierPlugin.Model;
    using Microsoft.VisualBasic.Devices;

    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new Builder();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var parameters = new Parameters();
            var streamWriter = new StreamWriter($"log.txt", true);
            Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            var count = 0;
            while (count < 50)
            {
                const double gigabyteInByte = 0.000000000931322574615478515625;
                builder.BuildDetail(parameters.GetParametersCurrentValues());
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory
                                  - computerInfo.AvailablePhysicalMemory)
                                 * gigabyteInByte;
                streamWriter.WriteLine(
                    $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }

            stopWatch.Stop();
            streamWriter.Close();
            streamWriter.Dispose();
            Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
        }
    }
}
