using System;
using System.Collections.Generic;
using System.Text;

namespace BestHTTP.Logger
{
   
    public sealed class EmptyOutput : ILogOutput
    {
        public void Write(Loglevels level, string logEntry)
        {
            switch (level)
            {
                case Loglevels.All:
                case Loglevels.Information:
                    break;

                case Loglevels.Warning:
                    break;

                case Loglevels.Error:
                case Loglevels.Exception:
                    break;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
