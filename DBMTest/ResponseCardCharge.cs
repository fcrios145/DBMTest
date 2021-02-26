using System;
namespace DBMTest
{
    public class ResponseCardCharge<T>
    {
        public string Reason { get; set; }
        public bool success { get; set; }
        public T Payload { get; set; }
    }
}
