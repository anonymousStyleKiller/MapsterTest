using System.ComponentModel.DataAnnotations;
using MapsterTest.Api.Interfaces;

namespace MapsterTest.Api.Models;

public class Entity : IEntity
{
    [Key] public Guid Id { get; set; }
}