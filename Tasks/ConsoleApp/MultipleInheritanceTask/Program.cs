using System;

namespace MultipleInheritanceTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface ITemparatureSensor
    {
        int GetTemparature();
    }

    public class TemparatureSensor : ITemparatureSensor
    {
        public int GetTemparature()
        {
            return 100;
        }
    }

    public interface IMoistureSensor
    {
        bool IsWet();
    }

    public class MoistureSensor : IMoistureSensor
    {
        public bool IsWet()
        {
            return true;
        }
    }

    // should inherit behavior of both A and B classes
    // if C.GetTemparature() => A
    // if C.IsWet() => true
    // ITemparatureSensor sensor = new GenericSensor();
    public class GenericSensor : ITemparatureSensor, IMoistureSensor
    {
        private ITemparatureSensor _temparatureSensor;
        private IMoistureSensor _moistureSensor;
        public GenericSensor(ITemparatureSensor temparatureSensor,IMoistureSensor moistureSensor)
        {
            _temparatureSensor = temparatureSensor;
            _moistureSensor = moistureSensor;
        }
        public int GetTemparature()
        {
            return _temparatureSensor.GetTemparature();
        }

        public bool IsWet()
        {
            return _moistureSensor.IsWet();
        }
    }
}
