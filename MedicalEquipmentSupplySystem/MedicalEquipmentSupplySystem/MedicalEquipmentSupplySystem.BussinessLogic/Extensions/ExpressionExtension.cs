using System.Linq.Expressions;


namespace BloodTransfusionBank.BussinessLogic.Extensions
{
    public static class ExpressionExtension
    {
        public static Expression<TDelegate> AndAlso<TDelegate>(this Expression<TDelegate> left, Expression<TDelegate> right)
        {
            return Expression.Lambda<TDelegate>(Expression.AndAlso(left, right), left.Parameters);
        }
    }
}
