using AutoMapper;
using WebShopBackend.Business.DTOs.OrderDto;
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
        _orderRepository.Update(_mapper.Map<Order>(itemForUpdate));
        if (itemForUpdate.OrderProductDtos.Count > 0)
        {
            foreach (var orderProductDto in itemForUpdate.OrderProductDtos)
            {
                if (orderProductDto.Amount == 0)
                {
                    _orderProductRepository.Remove(_mapper.Map<OrderProduct>(orderProductDto));
                }
                var product = _productRepository.GetOne(orderProductDto.Product.Id);
                if (CheckInventory(orderProductDto, product))
                {
                    _orderProductRepository.Update(_mapper.Map<OrderProduct>(orderProductDto));   
                }
            }
        }

        return _mapper.Map<OrderGetDto>(_orderRepository.GetOne(itemForUpdate.Id));
    }

    public override OrderGetDto Create(OrderCreateDto item)
    {
        var newOrder = _mapper.Map<Order>(item);
        foreach (var orderProductDto in item.OrderProducts)
        {
            var newOrderProduct = CreateOrderProduct(orderProductDto, newOrder);
            _orderProductRepository.Create(newOrderProduct);
            newOrder.OrderProducts.Add(newOrderProduct);
        }

        newOrder.OrderStatus = OrderStatus.Received;
        newOrder.AddressId = item.Address.Id;
        newOrder.UserId = item.User.Id;
        return _mapper.Map<OrderGetDto>(_orderRepository.Create(newOrder));
    }

    public override bool Remove(Guid id)
    {
        // Remove first all OrderProducts attached to the order
        var orderProducts = _orderProductRepository.GetAll(new OrderProductQuery
        {
            FilterBy = OrderProductsFilterBy.Order,
            Id = id
        });
        foreach (var orderProduct in orderProducts)
        {
            _orderProductRepository.Remove(orderProduct);
        }
        
        // Last removing the actual order entity
        return base.Remove(id);
    }

    private OrderProduct CreateOrderProduct(OrderProductDto orderProductDto, Order order)
    {
        var product = _productRepository.GetOne(orderProductDto.Product.Id);
        product.Inventory -= orderProductDto.Amount;
        _productRepository.Update(product);
        var newOrderProduct = _mapper.Map<OrderProduct>(orderProductDto);
        newOrderProduct.ProductId = product.Id;
        newOrderProduct.OrderId = order.Id;
        newOrderProduct.Order = order;
        return newOrderProduct;
    }

    private bool CheckInventory(OrderProductDto orderProductDto, Product product)
    {
        if (orderProductDto.Amount < product.Inventory)
        {
            throw new ArgumentException($"Not enough of inventory: {orderProductDto.Product.Title}");
        }

        return true;
    }
}