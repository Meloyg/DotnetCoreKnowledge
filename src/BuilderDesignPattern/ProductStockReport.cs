namespace BuilderDesignPattern;

public class ProductStockReport
{
    public string? HeaderPart { get; set; }
    public string? BodyPart { get; set; }
    public string? FooterPart { get; set; }

    public override string ToString()
    {
        return $"{HeaderPart}\n{BodyPart}\n{FooterPart}";
    }
}