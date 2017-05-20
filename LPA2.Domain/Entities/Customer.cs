﻿using System;
using LPA2.Domain.ValueObjects;
using LPA2.Shared.Entities;

namespace LPA2.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Name name, Email email, Document document, User user)
        {
            Name = name;
            BirthDate = null;
            Email = email;
            Document = document;
            User = user;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
           
        }
        
        public Name Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public User User { get; private set; }
        
        public void Update(Name name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }

}
