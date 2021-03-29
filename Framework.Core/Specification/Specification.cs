using System;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Core.Specification
{
    public abstract class Specification<T>
    {
        public static readonly Specification<T> All = new AllSpecification<T>();

        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();

            return predicate(entity);
        }

        public Specification<T> And(Specification<T> specification)
        {
            if (this == All) return specification;

            if (specification == All) return this;

            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            if (this == All || specification == All)
                return All;

            return new OrSpecification<T>(this, specification);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        public Specification<T> Not(Specification<T> spec)
        {
            return new NotEqualSpecification<T>(this, spec);
        }
    }

    internal sealed class AllSpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }

    internal sealed class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> left;
        private readonly Specification<T> right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = left.ToExpression();

            var rightExpression = right.ToExpression();

            var andExpression = Expression.AndAlso(leftExpression.Body, Expression.Invoke(rightExpression, leftExpression.Parameters.Single()));

            return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters);
        }
    }

    internal sealed class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> left;
        private readonly Specification<T> right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = left.ToExpression();

            var rightExpression = right.ToExpression();

            var orExpression = Expression.OrElse(leftExpression.Body, Expression.Invoke(rightExpression, leftExpression.Parameters.Single()));

            return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters);
        }
    }

    internal sealed class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> specification;

        public NotSpecification(Specification<T> specification)
        {
            this.specification = specification;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var expression = specification.ToExpression();

            var notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }

    internal sealed class NotEqualSpecification<T> : Specification<T>
    {
        private readonly Specification<T> left;
        private readonly Specification<T> right;

        public NotEqualSpecification(Specification<T> left, Specification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = left.ToExpression();

            var rightExpression = right.ToExpression();

            var notEqExpression = Expression.NotEqual(leftExpression.Body, Expression.Invoke(rightExpression, leftExpression.Parameters.Single()));

            return Expression.Lambda<Func<T, bool>>(notEqExpression, leftExpression.Parameters);
        }
    }
}
