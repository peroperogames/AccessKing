using System;
using System.Runtime.InteropServices;
using UnityEngine.Scripting;

namespace PeroTools2.AccessKing
{
    [StructLayout(LayoutKind.Explicit)]
    internal unsafe class PointerConverter
    {
        private static readonly PointerConverter pointerConverter = new PointerConverter();
        private delegate void* Object2VoidPtr(object obj);
        private delegate object VoidPtr2Object(void* pointer);

        [Preserve] [FieldOffset(0)] private Func<object, object> m_Object2VoidPtr_Shared = SwitchTarget;
        [Preserve] [FieldOffset(0)] private Func<object, object> m_VoidPtr2Object_Shared = SwitchTarget;
        [Preserve] [FieldOffset(0)] private Object2VoidPtr m_Object2VoidPtr;
        [Preserve] [FieldOffset(0)] private VoidPtr2Object m_VoidPtr2Object;

        private static object SwitchTarget(object o) => o;
        internal static object ConvertToObject(void* pointer) => pointerConverter.m_VoidPtr2Object(pointer);
        internal static void* ConvertToVoidPtr(object obj) => pointerConverter.m_Object2VoidPtr(obj);
        internal static IntPtr ConvertToIntPtr(object obj) => (IntPtr) pointerConverter.m_Object2VoidPtr(obj);
        internal static byte* ConvertToBytePtr(object obj) => (byte*) pointerConverter.m_Object2VoidPtr(obj);
    }
}