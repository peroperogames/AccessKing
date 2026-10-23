/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/05 11:12:52
 */

namespace PeroTools2.AccessKing;

/// <summary>
/// Empty parameter.
/// </summary>
public readonly struct Empty : INotification;

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
    public static ParameterNotification<T> Create<T>(T param) => new(param);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2> Create<T1, T2>(T1 param1, T2 param2) => new(param1, param2);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3> Create<T1, T2, T3>(T1 param1, T2 param2, T3 param3) => new(param1, param2, param3);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4) => new(param1, param2, param3, param4);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => new(param1, param2, param3, param4, param5);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6) =>
        new(param1, param2, param3, param4, param5, param6);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7) =>
        new(param1, param2, param3, param4, param5, param6, param7);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>
        Create<T1, T2, T3, T4, T5, T6, T7, T8>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8) =>
        new(param1, param2, param3, param4, param5, param6, param7, param8);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7,
        T8 param8, T9 param9) => new(param1, param2, param3, param4, param5, param6, param7, param8, param9);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6,
        T7 param7, T8 param8, T9 param9, T10 param10) => new(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5,
        T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11) => new(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 param1, T2 param2, T3 param3, T4 param4,
        T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12) =>
        new(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 param1, T2 param2, T3 param3,
        T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13) =>
        new(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 param1, T2 param2,
        T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14) =>
        new(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 param1, T2 param2,
        T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15) =>
        new(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);

    /// <summary>
    /// Create notification form parameters.
    /// </summary>
    /// <returns>Notification from parameters.</returns>
    public static ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 param1,
        T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15, T16 param16) =>
        new(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16);
}

/// <summary>
/// Notification from parameters.
/// </summary>
public readonly struct ParameterNotification<T> : INotification
{
    /// <summary>
    /// The notification parameter.
    /// </summary>
    public readonly T item;

    /// <summary>
    /// Create a notification with a single parameter.
    /// </summary>
    /// <param name="item">The notification parameter.</param>
    public ParameterNotification(T item)
    {
        this.item = item;
    }
}

/// <summary>
/// Notification from parameters.
/// </summary>
public readonly struct ParameterNotification<T1, T2> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Create a notification with 2 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    public ParameterNotification(T1 item1, T2 item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }
}

/// <summary>
/// Notification from parameters.
/// </summary>
public readonly struct ParameterNotification<T1, T2, T3> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Create a notification with 3 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Create a notification with 4 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Create a notification with 5 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Create a notification with 6 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Create a notification with 7 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Create a notification with 8 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Parameter 9 of the notification.
    /// </summary>
    public readonly T9 item9;

    /// <summary>
    /// Create a notification with 9 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
    /// <param name="item9">Parameter 9 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Parameter 9 of the notification.
    /// </summary>
    public readonly T9 item9;

    /// <summary>
    /// Parameter 10 of the notification.
    /// </summary>
    public readonly T10 item10;

    /// <summary>
    /// Create a notification with 10 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
    /// <param name="item9">Parameter 9 of the notification.</param>
    /// <param name="item10">Parameter 10 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Parameter 9 of the notification.
    /// </summary>
    public readonly T9 item9;

    /// <summary>
    /// Parameter 10 of the notification.
    /// </summary>
    public readonly T10 item10;

    /// <summary>
    /// Parameter 11 of the notification.
    /// </summary>
    public readonly T11 item11;

    /// <summary>
    /// Create a notification with 11 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
    /// <param name="item9">Parameter 9 of the notification.</param>
    /// <param name="item10">Parameter 10 of the notification.</param>
    /// <param name="item11">Parameter 11 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Parameter 9 of the notification.
    /// </summary>
    public readonly T9 item9;

    /// <summary>
    /// Parameter 10 of the notification.
    /// </summary>
    public readonly T10 item10;

    /// <summary>
    /// Parameter 11 of the notification.
    /// </summary>
    public readonly T11 item11;

    /// <summary>
    /// Parameter 12 of the notification.
    /// </summary>
    public readonly T12 item12;

    /// <summary>
    /// Create a notification with 12 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
    /// <param name="item9">Parameter 9 of the notification.</param>
    /// <param name="item10">Parameter 10 of the notification.</param>
    /// <param name="item11">Parameter 11 of the notification.</param>
    /// <param name="item12">Parameter 12 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Parameter 9 of the notification.
    /// </summary>
    public readonly T9 item9;

    /// <summary>
    /// Parameter 10 of the notification.
    /// </summary>
    public readonly T10 item10;

    /// <summary>
    /// Parameter 11 of the notification.
    /// </summary>
    public readonly T11 item11;

    /// <summary>
    /// Parameter 12 of the notification.
    /// </summary>
    public readonly T12 item12;

    /// <summary>
    /// Parameter 13 of the notification.
    /// </summary>
    public readonly T13 item13;

    /// <summary>
    /// Create a notification with 13 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
    /// <param name="item9">Parameter 9 of the notification.</param>
    /// <param name="item10">Parameter 10 of the notification.</param>
    /// <param name="item11">Parameter 11 of the notification.</param>
    /// <param name="item12">Parameter 12 of the notification.</param>
    /// <param name="item13">Parameter 13 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Parameter 9 of the notification.
    /// </summary>
    public readonly T9 item9;

    /// <summary>
    /// Parameter 10 of the notification.
    /// </summary>
    public readonly T10 item10;

    /// <summary>
    /// Parameter 11 of the notification.
    /// </summary>
    public readonly T11 item11;

    /// <summary>
    /// Parameter 12 of the notification.
    /// </summary>
    public readonly T12 item12;

    /// <summary>
    /// Parameter 13 of the notification.
    /// </summary>
    public readonly T13 item13;

    /// <summary>
    /// Parameter 14 of the notification.
    /// </summary>
    public readonly T14 item14;

    /// <summary>
    /// Create a notification with 14 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
    /// <param name="item9">Parameter 9 of the notification.</param>
    /// <param name="item10">Parameter 10 of the notification.</param>
    /// <param name="item11">Parameter 11 of the notification.</param>
    /// <param name="item12">Parameter 12 of the notification.</param>
    /// <param name="item13">Parameter 13 of the notification.</param>
    /// <param name="item14">Parameter 14 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Parameter 9 of the notification.
    /// </summary>
    public readonly T9 item9;

    /// <summary>
    /// Parameter 10 of the notification.
    /// </summary>
    public readonly T10 item10;

    /// <summary>
    /// Parameter 11 of the notification.
    /// </summary>
    public readonly T11 item11;

    /// <summary>
    /// Parameter 12 of the notification.
    /// </summary>
    public readonly T12 item12;

    /// <summary>
    /// Parameter 13 of the notification.
    /// </summary>
    public readonly T13 item13;

    /// <summary>
    /// Parameter 14 of the notification.
    /// </summary>
    public readonly T14 item14;

    /// <summary>
    /// Parameter 15 of the notification.
    /// </summary>
    public readonly T15 item15;

    /// <summary>
    /// Create a notification with 15 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
    /// <param name="item9">Parameter 9 of the notification.</param>
    /// <param name="item10">Parameter 10 of the notification.</param>
    /// <param name="item11">Parameter 11 of the notification.</param>
    /// <param name="item12">Parameter 12 of the notification.</param>
    /// <param name="item13">Parameter 13 of the notification.</param>
    /// <param name="item14">Parameter 14 of the notification.</param>
    /// <param name="item15">Parameter 15 of the notification.</param>
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Parameter 9 of the notification.
    /// </summary>
    public readonly T9 item9;

    /// <summary>
    /// Parameter 10 of the notification.
    /// </summary>
    public readonly T10 item10;

    /// <summary>
    /// Parameter 11 of the notification.
    /// </summary>
    public readonly T11 item11;

    /// <summary>
    /// Parameter 12 of the notification.
    /// </summary>
    public readonly T12 item12;

    /// <summary>
    /// Parameter 13 of the notification.
    /// </summary>
    public readonly T13 item13;

    /// <summary>
    /// Parameter 14 of the notification.
    /// </summary>
    public readonly T14 item14;

    /// <summary>
    /// Parameter 15 of the notification.
    /// </summary>
    public readonly T15 item15;

    /// <summary>
    /// Parameter 16 of the notification.
    /// </summary>
    public readonly T16 item16;

    /// <summary>
    /// Create a notification with 16 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
    /// <param name="item9">Parameter 9 of the notification.</param>
    /// <param name="item10">Parameter 10 of the notification.</param>
    /// <param name="item11">Parameter 11 of the notification.</param>
    /// <param name="item12">Parameter 12 of the notification.</param>
    /// <param name="item13">Parameter 13 of the notification.</param>
    /// <param name="item14">Parameter 14 of the notification.</param>
    /// <param name="item15">Parameter 15 of the notification.</param>
    /// <param name="item16">Parameter 16 of the notification.</param>
    public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15,
        T16 item16)
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
public readonly struct ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> : INotification
{
    /// <summary>
    /// Parameter 1 of the notification.
    /// </summary>
    public readonly T1 item1;

    /// <summary>
    /// Parameter 2 of the notification.
    /// </summary>
    public readonly T2 item2;

    /// <summary>
    /// Parameter 3 of the notification.
    /// </summary>
    public readonly T3 item3;

    /// <summary>
    /// Parameter 4 of the notification.
    /// </summary>
    public readonly T4 item4;

    /// <summary>
    /// Parameter 5 of the notification.
    /// </summary>
    public readonly T5 item5;

    /// <summary>
    /// Parameter 6 of the notification.
    /// </summary>
    public readonly T6 item6;

    /// <summary>
    /// Parameter 7 of the notification.
    /// </summary>
    public readonly T7 item7;

    /// <summary>
    /// Parameter 8 of the notification.
    /// </summary>
    public readonly T8 item8;

    /// <summary>
    /// Parameter 9 of the notification.
    /// </summary>
    public readonly T9 item9;

    /// <summary>
    /// Parameter 10 of the notification.
    /// </summary>
    public readonly T10 item10;

    /// <summary>
    /// Parameter 11 of the notification.
    /// </summary>
    public readonly T11 item11;

    /// <summary>
    /// Parameter 12 of the notification.
    /// </summary>
    public readonly T12 item12;

    /// <summary>
    /// Parameter 13 of the notification.
    /// </summary>
    public readonly T13 item13;

    /// <summary>
    /// Parameter 14 of the notification.
    /// </summary>
    public readonly T14 item14;

    /// <summary>
    /// Parameter 15 of the notification.
    /// </summary>
    public readonly T15 item15;

    /// <summary>
    /// Parameter 16 of the notification.
    /// </summary>
    public readonly T16 item16;

    /// <summary>
    /// Parameter 17 of the notification.
    /// </summary>
    public readonly T17 item17;

    /// <summary>
    /// Create a notification with 17 parameters.
    /// </summary>
    /// <param name="item1">Parameter 1 of the notification.</param>
    /// <param name="item2">Parameter 2 of the notification.</param>
    /// <param name="item3">Parameter 3 of the notification.</param>
    /// <param name="item4">Parameter 4 of the notification.</param>
    /// <param name="item5">Parameter 5 of the notification.</param>
    /// <param name="item6">Parameter 6 of the notification.</param>
    /// <param name="item7">Parameter 7 of the notification.</param>
    /// <param name="item8">Parameter 8 of the notification.</param>
    /// <param name="item9">Parameter 9 of the notification.</param>
    /// <param name="item10">Parameter 10 of the notification.</param>
    /// <param name="item11">Parameter 11 of the notification.</param>
    /// <param name="item12">Parameter 12 of the notification.</param>
    /// <param name="item13">Parameter 13 of the notification.</param>
    /// <param name="item14">Parameter 14 of the notification.</param>
    /// <param name="item15">Parameter 15 of the notification.</param>
    /// <param name="item16">Parameter 16 of the notification.</param>
    /// <param name="item17">Parameter 17 of the notification.</param>
    public ParameterNotification(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15,
        T16 item16, T17 item17)
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