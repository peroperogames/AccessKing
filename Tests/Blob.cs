using System.Runtime.InteropServices;

namespace PeroTools2.AccessKing.Tests;

[StructLayout(LayoutKind.Explicit)]
internal class Blob
{
    [FieldOffset(0)] public long a = 0;
    [FieldOffset(67789)] long a2 = 0;
}