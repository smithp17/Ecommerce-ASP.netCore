using System;
using System.Collections.Generic;
using System.Text;
using CORE.Entities;
namespace CORE.Specification
{
    public class TypeListSpecification:BaseSpecification<Product, string>
    {
        public TypeListSpecification()
        {
            AddSelect(p => p.Type);
            ApplyDistinct();
        }
    
    }
}
