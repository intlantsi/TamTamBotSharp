using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API
{
    public class TamTamAPIVersion
    {
        private static readonly int MAJOR = 0;
        private static readonly int MINOR = 3;
        private static readonly int BUILD = 0;
        private static readonly string VERSION = String.Format("{0}.{1}.{2}", MAJOR, MINOR, BUILD);

        private TamTamAPIVersion()
        {

        }

        public static string GetVersion { get=> VERSION;}
    }
}
