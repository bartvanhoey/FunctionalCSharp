﻿using System.Collections;

namespace LaYumba.Functional;

public class EmptyList<T> : IEnumerable<T>
{
   IEnumerator IEnumerable.GetEnumerator() { yield break; }
   IEnumerator<T> IEnumerable<T>.GetEnumerator() { yield break; }
}