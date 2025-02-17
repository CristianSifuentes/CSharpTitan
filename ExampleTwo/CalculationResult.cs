// Record with Init-Only Properties for immutability
public record CalculationResult(int Min, int Max, int Difference){
    // Defines an immutable reference type with value-like semantics.
    // int Min, int Max, int Difference -> Declares readonly properties (Init-Only).
    // Custom ToString()
    //Uses raw string literals ($$"""...""") for clean formatting.
    // public override string ToString() => $"Min: {Min}, Max: {Max}, Difference: {Difference}";

    public override string ToString() => $$"""
        Greatest Difference Calculation:
        Min Value: {{Min}}
        Max Value: {{Max}}
        Difference: {{Difference}}
        """;

}