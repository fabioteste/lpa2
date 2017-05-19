﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using LPA2.Domain.Enums;
using LPA2.Shared.Entities;

namespace LPA2.Domain.Entities 
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;

        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0,8).ToUpper();
            Status = EOrderStatus.Created;
            DeliveryFee = deliveryFee;
            Discount = discount;
            _items = new List<OrderItem>();

            new ValidationContract<Order>(this)
                .IsGreaterThan(x => x.Discount, -1)
                .IsGreaterThan(x => x.DeliveryFee, 0);
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }

        public decimal Subtotal() => Items.Sum(x => x.Total());
        public decimal Total() => Subtotal() + DeliveryFee - Discount;

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);
            if (item.IsValid())
                _items.Add(item);
        }


    }
}
