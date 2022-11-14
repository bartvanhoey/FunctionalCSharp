namespace LaYumba
{
   using static F;

   public static class DictionaryExt
   {
      public static Option<T> Lookup<K, T>(this IDictionary<K, T> dict, K key)
      {
         T value;
         return dict.TryGetValue(key, out value) ? Some(value) : None;
      }
   }
}