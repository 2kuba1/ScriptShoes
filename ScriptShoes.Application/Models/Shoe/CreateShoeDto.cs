﻿namespace ScriptShoes.Application.Models.Shoe;

public class CreateShoeDto
{
    public string? ShoeName { get; set; }
    public string? Brand { get; set; }
    public string? ShoeType { get; set; }

    public List<float>? ShoeSizes { get; set; }
    public float CurrentPrice { get; set; }
    public string? ThumbnailImage { get; set; }
    public List<string>? Images { get; set; }
}