namespace ScriptShoes.Application.Models.Shoe;

public class UpdateShoeDto
{
    public string? NewName { get; set; }
    public float? CurrentPrice { get; set; }
    public string? Brand { get; set; }
    public string? ShoeType { get; set; }
    public List<float>? SizesList { get; set; }
}