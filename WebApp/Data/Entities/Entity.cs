using System.ComponentModel.DataAnnotations;
using WebApp.Data.Contracts;

namespace WebApp.Data.Entities;

public abstract class Entity : IEntity
{
    [Key]
    public int Id { get; set; }
}