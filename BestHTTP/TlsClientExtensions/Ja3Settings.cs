using System;
using System.Collections.Generic;
using System.Text;

namespace BestHTTP.TlsClientExtensions
{
    public class Ja3Settings
    {
        //"771,4865-4866-4867-49195-49199-49196-49200-52393-52392-49171-49172-156-157-47-53-255,22-17513-23-0-5-13-10-11-43-45-51-41,29-23-24,0

        public bool RandomExtensions { get; set; } = true;
        public string Extensions { get; set; } = "22-17513-23-0-5-13-10-11-43-45-51-41";
        public string Ciphers { get; set; } = "4865-4866-4867-49195-49199-49196-49200-52393-52392-49171-49172-156-157-47-53";
        public string EllipticCurves
        {
            get; set;
        } = "29-23-24";
        public string EllipticCurvePointFormats { get; set; } = "0";
    }
}
