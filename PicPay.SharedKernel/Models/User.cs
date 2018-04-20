using System;

namespace PicPay.SharedKernel.Models
{
    public sealed class User
    {
        public User(string name, string username)
        {
            Id = Guid.NewGuid();
            Name = name;
            Username = username;
        }

        public User(Guid id, string name, string username)
        {
            Id = id;
            Name = name;
            Username = username;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
    }
}
