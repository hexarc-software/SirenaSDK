using System.IO;
using System.Text;

namespace Sirena.Helpers
{
    class Utf32StringWritter : StringWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF32;
            }
        }
    }
}
