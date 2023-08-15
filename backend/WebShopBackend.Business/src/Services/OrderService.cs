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
    private readonly IBaseRepository<OrderProduct> _orderProductRepository;
    private readonly IBaseRepository<Product> _productRepository;
    public OrderService(IBaseRepository<Product> productRepository, IBaseRepository<Order> repository, IBaseRepository<OrderProduct> orderProductRepository, IMapper mapper) : base(repository, mapper)
    {
        _orderRepository = repository;
        _orderProductRepository = orderProductRepository;
        _productRepository = productRepository;
    }

    public override List<OrderGetDto> GetAll(QueryOptions queryOptions)
    {
        return _mapper.Map<List<OrderGetDto>>(_orderRepository.GetAll(queryOptions));
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

    private OrderProduct CreateOrderProduct(OrderProductDto orderProductDto, Order order)
    {
        var product = _productRepository.GetOne(orderProductDto.Product.Id);
        if (orderProductDto.Amount < product.Inventory)
        {
            throw new ArgumentException($"Not enough of inventory: {orderProductDto.Product.Title}");
        }

        product.Inventory -= orderProductDto.Amount;
        _productRepository.Update(product);
        var newOrderProduct = _mapper.Map<OrderProduct>(orderProductDto);
        newOrderProduct.ProductId = product.Id;
        newOrderProduct.OrderId = order.Id;
        newOrderProduct.Order = order;
        return newOrderProduct;
    }
}