using System.Text;

namespace Gallery.Extensions;

public static class ByteArrayExtensions
{
    public static string BytesToString(this byte[] content)
    {
        return Encoding.UTF8.GetString(content);
    }
}