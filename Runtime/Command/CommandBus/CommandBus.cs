/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月29日
 * Description: Default command bus implementation.
 */

using System.Collections;
using UnityEngine.Assertions;

namespace PeroTools2.AccessKing
{
    public class CommandBus<TNotification> : ISchedulableCommandBus<TNotification>
        where TNotification : INotification
    {
        private ICommandHandlerFactory m_HandlerFactory;

        public CommandBus(ICommandHandlerFactory handlerFactory) => m_HandlerFactory = handlerFactory;

        public CommandBus() { }

        void ICommandHandlerFactoryModifiable.SetFactory(ICommandHandlerFactory factory) => m_HandlerFactory = factory;

        void IAccessBus.Dispatch(INotification notification)
        {
            if (m_HandlerFactory == null)
                return;
            if (notification is TNotification tNotification)
                Execute(ref tNotification);
            else
                ThrowHelper.NotificationCastFailed<TNotification>(notification);
        }

        public CommandOperation Execute(ref TNotification notification)
        {
            Assert.IsNotNull(m_HandlerFactory);
            var handlers = m_HandlerFactory.RequireHandlers<TNotification>();
            var results = new ArrayList();
            foreach (var handler in handlers)
            {
                handler.Handle(ref notification);
                if (handler is IResultAvailable resultGetter)
                {
                    results.Add(resultGetter.GetResult());
                }
            }

            return new CommandOperation(results);
        }
    }
}