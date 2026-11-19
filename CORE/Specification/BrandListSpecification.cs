using System;
using System.Collections.Generic;
using System.Text;
using CORE.Entities;
namespace CORE.Specification
{
    public class BrandListSpecification : BaseSpecification<Product, string>
    {
        public BrandListSpecification()
        {
            AddSelect(p => p.Brand);
            ApplyDistinct();
        }
    }
    
}
