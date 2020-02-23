using System.Collections.Generic;

namespace PhotoLibrary.Helpers {
    public static class ListExtensions {
        public static AsyncObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll) {
            if (coll == null) {
                return null;
            }
            var c = new AsyncObservableCollection<T>();
            foreach (var e in coll)
                c.Add(e);
            return c;
        }

    }
}
