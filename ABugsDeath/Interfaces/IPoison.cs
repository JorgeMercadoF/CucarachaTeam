using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Interfaces
{
    public interface IPoison : IAsset
    {
        string Name { get; }
        decimal Quantity { get; set; }
    }
}
