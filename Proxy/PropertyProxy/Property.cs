using System;
using System.Collections.Generic;

namespace Proxy.PropertyProxy
{
    /*
     * This is an example generic property proxy. For this example
     * we want to avoid assigning duplicate values to a property of this
     * generic type - let's say to avoid setting an expensive value over and over again
     */
    public class Property<T> : IEquatable<Property<T>> where T : new()
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value)) return;
                _value = value;
                Console.WriteLine($"Value is set {_value}");
            }
        }

        /* Default parameterless constructor uses Activator to create
         * a default value for T. we can always use default(T) too but in that case
         * we'll almost always get a null value for reference types (e.g: strings)
         * if this is OK for the implementation default(T) can be used.
         */
        public Property() : this(Activator.CreateInstance<T>()) { }

        public Property(T value)
        {
            _value = value;
        }

        public static implicit operator T(Property<T> property)
        {
            return property.Value;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value);
        }

        public bool Equals(Property<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Property<T>) obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(Property<T> left, Property<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Property<T> left, Property<T> right)
        {
            return !Equals(left, right);
        }
    }
}
