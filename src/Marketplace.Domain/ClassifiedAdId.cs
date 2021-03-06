using System;
using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class ClassifiedAdId: Value<ClassifiedAdId>
    {
        private readonly Guid _value;

        public ClassifiedAdId(Guid value)
        {
            if (value == default) {
                throw new ArgumentException("Classified Ad id cannot be empty", nameof(value));
            }

            _value = value;
        }

        public static implicit operator Guid(ClassifiedAdId self) => self._value;
    }
}