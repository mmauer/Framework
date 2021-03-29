using Framework.Core.Specification;
using System;
using System.Linq.Expressions;

namespace Framework.Core.Tests.Specification
{
    public class LessThanZeroSpecification : Specification<int>
    {
        public override Expression<Func<int, bool>> ToExpression()
        {
            return x => x < 0;
        }
    }
}