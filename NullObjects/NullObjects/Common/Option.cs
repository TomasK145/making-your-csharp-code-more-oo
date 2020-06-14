﻿using System.Collections;
using System.Collections.Generic;

namespace NullObjects.Common
{
    class Option<T> : IEnumerable<T>
    {
        private IEnumerable<T> Content { get; }

        private Option(IEnumerable<T> content)
        {
            this.Content = content;
        }

        // static factory method
        public static Option<T> Some(T value) => new Option<T>(new[] { value });

        // static factory method
        public static Option<T> None() => new Option<T>(new T[0]);

        public IEnumerator<T> GetEnumerator() => this.Content.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
