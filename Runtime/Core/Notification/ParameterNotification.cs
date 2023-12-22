/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/05 11:12:52
 */

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Empty parameter.
    /// </summary>
    public readonly struct Empty : INotification { }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public static class ParameterNotification
    {
        /// <summary>
        /// Empty parameter.
        /// </summary>
        public static readonly Empty Empty = new();

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T> Create<T>(T param) => new (param);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2> Create<T1, T2>(T1 param1, T2 param2) => new (param1, param2);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3> Create<T1, T2, T3>(T1 param1, T2 param2, T3 param3) => new (param1, param2, param3);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4) => new (param1, param2, param3, param4);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => new (param1, param2, param3, param4, param5);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6) => new (param1, param2, param3, param4, param5, param6);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7) => new (param1, param2, param3, param4, param5, param6, param7);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8) => new (param1, param2, param3, param4, param5, param6, param7, param8);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9) => new (param1, param2, param3, param4, param5, param6, param7, param8, param9);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10) => new (param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11) => new (param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12) => new (param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13) => new (param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14) => new (param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15) => new (param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15, T16 param16) => new (param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16);

        /// <summary>
        /// Create notification form parameters.
        /// </summary>
        /// <returns>Notification from parameters.</returns>
        public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15, T16 param16, T17 param17) => new (param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16, param17);
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T> : INotification
    {
        public readonly T item;
        public ParameterNotification(T item)
        {
            this.item = item;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
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

    /// <summary>
    /// Notification from parameters.
    /// </summary>
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

    /// <summary>
    /// Notification from parameters.
    /// </summary>
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

    /// <summary>
    /// Notification from parameters.
    /// </summary>
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

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;
		public readonly T9 item9;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
			this.item9 = item9;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;
		public readonly T9 item9;
		public readonly T10 item10;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
			this.item9 = item9;
			this.item10 = item10;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;
		public readonly T9 item9;
		public readonly T10 item10;
		public readonly T11 item11;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
			this.item9 = item9;
			this.item10 = item10;
			this.item11 = item11;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;
		public readonly T9 item9;
		public readonly T10 item10;
		public readonly T11 item11;
		public readonly T12 item12;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
			this.item9 = item9;
			this.item10 = item10;
			this.item11 = item11;
			this.item12 = item12;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;
		public readonly T9 item9;
		public readonly T10 item10;
		public readonly T11 item11;
		public readonly T12 item12;
		public readonly T13 item13;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
			this.item9 = item9;
			this.item10 = item10;
			this.item11 = item11;
			this.item12 = item12;
			this.item13 = item13;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;
		public readonly T9 item9;
		public readonly T10 item10;
		public readonly T11 item11;
		public readonly T12 item12;
		public readonly T13 item13;
		public readonly T14 item14;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
			this.item9 = item9;
			this.item10 = item10;
			this.item11 = item11;
			this.item12 = item12;
			this.item13 = item13;
			this.item14 = item14;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;
		public readonly T9 item9;
		public readonly T10 item10;
		public readonly T11 item11;
		public readonly T12 item12;
		public readonly T13 item13;
		public readonly T14 item14;
		public readonly T15 item15;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
			this.item9 = item9;
			this.item10 = item10;
			this.item11 = item11;
			this.item12 = item12;
			this.item13 = item13;
			this.item14 = item14;
			this.item15 = item15;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;
		public readonly T9 item9;
		public readonly T10 item10;
		public readonly T11 item11;
		public readonly T12 item12;
		public readonly T13 item13;
		public readonly T14 item14;
		public readonly T15 item15;
		public readonly T16 item16;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15, T16 item16)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
			this.item9 = item9;
			this.item10 = item10;
			this.item11 = item11;
			this.item12 = item12;
			this.item13 = item13;
			this.item14 = item14;
			this.item15 = item15;
			this.item16 = item16;
        }
    }

    /// <summary>
    /// Notification from parameters.
    /// </summary>
    public struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : INotification
    {
        public readonly T1 item1;
		public readonly T2 item2;
		public readonly T3 item3;
		public readonly T4 item4;
		public readonly T5 item5;
		public readonly T6 item6;
		public readonly T7 item7;
		public readonly T8 item8;
		public readonly T9 item9;
		public readonly T10 item10;
		public readonly T11 item11;
		public readonly T12 item12;
		public readonly T13 item13;
		public readonly T14 item14;
		public readonly T15 item15;
		public readonly T16 item16;
		public readonly T17 item17;

        public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15, T16 item16, T17 item17)
        {
            this.item1 = item1;
			this.item2 = item2;
			this.item3 = item3;
			this.item4 = item4;
			this.item5 = item5;
			this.item6 = item6;
			this.item7 = item7;
			this.item8 = item8;
			this.item9 = item9;
			this.item10 = item10;
			this.item11 = item11;
			this.item12 = item12;
			this.item13 = item13;
			this.item14 = item14;
			this.item15 = item15;
			this.item16 = item16;
			this.item17 = item17;
        }
    }
}