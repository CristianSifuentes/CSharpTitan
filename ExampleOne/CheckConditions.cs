// Utility class to provide different checking conditions
public static class CheckConditions{
    
    /// <summary>
    /// Check if a number is contained in a collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="item"></param>
    /// <param name="threshold"></param>
    /// <returns></returns>
    public static bool CountOccurrences<T>(IEnumerable<T> collection, T item, int threshold){
        // A method matching this delegate must have exactly the same signature
        // bool MethodName(IEnumerable<T> collection, T item, int threshold);
        // ✔ It can be assigned to CheckCondition<T>.

        return collection.Count(x=> EqualityComparer<T>.Default.Equals(x, item)) >= threshold;
    }
}