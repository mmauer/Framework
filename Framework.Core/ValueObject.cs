namespace Framework.Core
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        private int? _cachedHashCode;

        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (valueObject is null) return false;

            return EqualsCore(valueObject);
        }

        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = GetHashCodeCore();
            }

            return _cachedHashCode.Value;
        }

        protected abstract int GetHashCodeCore();

        protected abstract bool EqualsCore(T other);

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (left is null && right is null) return true;

            if (left is null || right is null) return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }
    }
}
