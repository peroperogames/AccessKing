using System;

namespace PeroTools2.AccessKing
{
    public interface IDelegate<TDelegate> where TDelegate : Delegate
    {
        TDelegate delegation { get; }
        void Add(TDelegate target);
        bool Remove(TDelegate target);
        void Clear();
    }
}