using AutoMapper;
using WebShopBackend.Business.DTOs.OrderDto;
using WebShopBackend.Business.Shared;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.Enums;
using WebShopBackend.Core.HelperClasses;

namespace WebShopBackend.Business.Services;

public class OrderService : BaseService<Order, OrderGetDto, OrderCreateDto, OrderUpdateDto>
{
    private readonly IBaseRepository<Order> _orderRepository;
    private readonly IOrderProductRepository _orderProductRepository;
    private readonly IBaseRepository<Product> _productRepository;
    public OrderService(IBaseRepository<Product> productRepository, IBaseRepository<Order> repository, IOrderProductRepository orderProductRepository, IMapper mapper) : base(repository, mapper)
    {
        _orderRepository = repository;
        _orderProductRepository = orderProductRepository;
        _productRepository = productRepository;
    }

    public override OrderGetDto Update(Guid updateId, OrderUpdateDto itemForUpdate)
    {
        var order = _orderRepository.GetOne(itemForUpdate.Id);
        order.AddressId = itemForUpdate.AddressId;
        foreach (var orderProductDto in itemForUpdate.OrderProductDtos)
        {
            var product = _productRepository.GetOne(orderProductDto.ProductId);
            var currentAmount = order.OrderProducts.Find(e => e.ProductId == orderProductDto.ProductId)!.Amount;
            var amountDifference = orderProductDto.Amount - currentAmount;
            product.Inventory -= amountDifference;
            _productRepository.Update(product);
            order.OrderProducts.Find(e => e.ProductId == product.Id)!.Amount = orderProductDto.Amount;
        }
        
        _orderRepository.Update(_mapper.Map<Order>(order));
        return _mapper.Map<OrderGetDto>(_orderRepository.GetOne(itemForUpdate.Id));
    }

    public override OrderGetDto Create(OrderCreateDto item)
    {
        var newOrder = _mapper.Map<Order>(item);
        newOrder.OrderStatus = OrderStatus.Received;
        var createdOrder = _orderRepository.Create(newOrder);
        foreach (var orderProduct in createdOrder.OrderProducts)
        {
            var product = _productRepository.GetOne(orderProduct.ProductId);
            product.Inventory -= orderProduct.Amount;
            _productRepository.Update(product);
        }
        return _mapper.Map<OrderGetDto>(createdOrder);
    }

    public override bool Remove(Guid id)
    {
        var order = _orderRepository.GetOne(id);
        if (order.OrderStatus.ToString() == "Cancelled" || order.OrderStatus.ToString() == "Shipped")
        {
            throw new InvalidOperationException($"Invalid action, order status already: {order.OrderStatus.ToString()}");
        }

        foreach (var orderProduct in order.OrderProducts)
        {
            var product = _productRepository.GetOne(orderProduct.ProductId);
            product.Inventory += orderProduct.Amount;
            _productRepository.Update(product);
        }
        return base.Remove(id);
    }
}