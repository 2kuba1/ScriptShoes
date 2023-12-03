namespace ScriptShoes.Application.Models.Shoe;

public class GetFiltersDto
{
    public List<float>? Sizes { get; set; } 
    public List<string>? Brand { get; set; }
    public List<string>? ShoeType { get; set; }
}