using System;
using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class UserId: Value<UserId>
    {
        private readonly Guid _value;

        public UserId(Guid value)
        {
            if (value == default) {
                throw new ArgumentException("User id cannot be empty", nameof(value));
            }

            _value = value;
        }

        public static implicit operator Guid(UserId self) => self._value;
    }
}