using System.ComponentModel.DataAnnotations;
using WebShopBackend.Core.Abstractions;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Entities;

public class Order : IOrder
{
    [Key]
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get;  set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public OrderStatus OrderStatus { get; set; }
}