namespace Products.Common;

public record ProductResponse(
    int Id,
    string Name,
    decimal UnitPrice
);