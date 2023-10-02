﻿using System.ComponentModel.DataAnnotations;

namespace ScriptShoes.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
}