namespace PeroTools2.AccessKing
{
    public struct ParameterNotification : INotification
    {
        public static ParameterNotification Empty = new ParameterNotification();
    }

    public struct ParameterNotification<T> : INotification
    {
        public T item;
    }

    public struct ParameterNotification<T1, T2> : INotification
    {
        public T1 item1;
        public T2 item2;
    }

    public struct ParameterNotification<T1, T2, T3> : INotification
    {
        public T1 item1;
        public T2 item2;
        public T3 item3;
    }

    public struct ParameterNotification<T1, T2, T3, T4> : INotification
    {
        public T1 item1;
        public T2 item2;
        public T3 item3;
        public T4 item4;
    }

    public struct ParameterNotification<T1, T2, T3, T4, T5> : INotification
    {
        public T1 item1;
        public T2 item2;
        public T3 item3;
        public T4 item4;
        public T5 item5;
    }
}