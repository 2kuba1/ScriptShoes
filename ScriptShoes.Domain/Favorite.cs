﻿using ScriptShoes.Domain.Common;

namespace ScriptShoes.Domain;

public class Favorite : BaseEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ShoeId { get; set; }
}