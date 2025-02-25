﻿using System;

namespace Demo.Common.Interfaces
{
    public interface IFilteredNone<T>
    {
        IActionable<T> Do(Action action);
        IMapped<T, TResult> MapTo<TResult>(Func<TResult> mapping);
    }
}