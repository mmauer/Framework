using Framework.Core.Specification;
using System;
using System.Linq.Expressions;

namespace Framework.Core.Tests.Specification
{
    public class EqualsOneSpecification : Specification<int>
    {
        public override Expression<Func<int, bool>> ToExpression()
        {
            return x => x == 1;
        }
    }
}