using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
namespace CORE.Interfaces;
public interface ISpecification<T> 
    {
        Expression<Func<T, bool>>? Criteria { get; }
        Expression<Func<T, object>>? OrderBy { get; }
      
        Expression<Func<T, object>>? OrderByDescending { get; }
        bool IsDistinct { get; }
}
 
public interface ISpecification<T, TResults> : ISpecification<T>
{
    Expression<Func<T, TResults>>? Select { get; }
   
}