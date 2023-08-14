using AutoMapper;
using WebShopBackend.Business.DTOs.OrderDto;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

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

    public override OrderGetDto Create(OrderCreateDto item)
    {
        var orderProduct = _mapper.Map<Order>(item);
        //Create order and get the order id
        // Creating OrderProducts and saving them
        // - Includes also checking product inventory
        throw new NotImplementedException();
    }

    private OrderProduct CreateOrderProduct(OrderProductDto orderProduct, Order order)
    {
        var product = _productRepository.GetOne(orderProduct.Product.Id);
        if (orderProduct.Amount < product.Inventory)
        {
            throw new ArgumentOutOfRangeException();
        }

        product.Inventory -= orderProduct.Amount;
        _productRepository.Update(product);
        var newOrderProduct = _mapper.Map<OrderProduct>(orderProduct);
        newOrderProduct.ProductId = product.Id;
        newOrderProduct.OrderId = order.Id;
        newOrderProduct.Order = order;
        throw new NotImplementedException();
    }
}