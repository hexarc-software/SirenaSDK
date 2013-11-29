using System.IO;
using System.Text;

namespace Sirena.Helpers
{
    class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}
