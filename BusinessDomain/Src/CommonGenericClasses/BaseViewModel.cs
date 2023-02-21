using System;

namespace CommonGenericClasses
{
    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[] ConcurrencyStamp { get; set; } = null!;
    }
}