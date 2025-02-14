// Utility class to provide different checking conditions
public static class CheckConditions{
    public static bool CountOccurrences<T>(IEnumerable<T> collection, T item, int threshold){
        return collection.Count(x => EqualityComparer<T>.Default.Equals(x, item)) >= threshold;
    }
}