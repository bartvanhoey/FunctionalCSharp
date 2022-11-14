using System.Collections;

namespace LaYumba
{
   public class EmptyList<T> : IEnumerable<T>
   {
      IEnumerator IEnumerable.GetEnumerator() { yield break; }
      IEnumerator<T> IEnumerable<T>.GetEnumerator() { yield break; }
   }
}