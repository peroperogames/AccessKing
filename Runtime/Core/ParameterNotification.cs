namespace PeroTools2.AccessKing
{
    public struct ParameterNotification : INotification
    {
        public static ParameterNotification Empty = new ParameterNotification();
    }

    public struct ParameterNotification<T> : INotification
    {
        public readonly T item;

        public ParameterNotification(T item)
        {
            this.item = item;
        }
    }

    public struct ParameterNotification<T1, T2> : INotification
    {
        public readonly T1 item1;
        public readonly T2 item2;

        public ParameterNotification(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }
    }

    public struct ParameterNotification<T1, T2, T3> : INotification
    {
        public readonly T1 item1;
        public readonly T2 item2;
        public readonly T3 item3;

        public ParameterNotification(T1 item1, T2 item2, T3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }
    }

    public struct ParameterNotification<T1, T2, T3, T4> : INotification
    {
        public readonly T1 item1;
        public readonly T2 item2;
        public readonly T3 item3;
        public readonly T4 item4;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
        }
    }

    public struct ParameterNotification<T1, T2, T3, T4, T5> : INotification
    {
        public readonly T1 item1;
        public readonly T2 item2;
        public readonly T3 item3;
        public readonly T4 item4;
        public readonly T5 item5;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
            this.item5 = item5;
        }
    }
}