using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Heals.CSX.Mall.Products
{
    public enum ProductStatus
    {
        OutofStock = 0,
        Available = 1
    }


    /// <summary>
    /// product Catalog type
    /// </summary>
    public enum CatalogType
    {
        BundleProduct = 1,
        ComputerCombination,
        Accessories,
        Monitor,
        Printer,
        Switch_Router,
        SmartPhone_Tablet
    }
}
