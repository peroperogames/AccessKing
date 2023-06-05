/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月26日
 * Description: Event bus with ParameterNotification wrapper.
 */
 
namespace PeroTools2.AccessKing
{
    public class ParameterEventBus : EventBus<Empty> { }
    public class ParameterEventBus<T> : EventBus<ParameterNotification<T>> { }
    public class ParameterEventBus<T1,T2> : EventBus<ParameterNotification<T1,T2>> { }
    public class ParameterEventBus<T1,T2,T3> : EventBus<ParameterNotification<T1,T2,T3>> { }
    public class ParameterEventBus<T1,T2,T3,T4> : EventBus<ParameterNotification<T1,T2,T3,T4>> { }
    public class ParameterEventBus<T1,T2,T3,T4,T5> : EventBus<ParameterNotification<T1,T2,T3,T4,T5>> { }
}