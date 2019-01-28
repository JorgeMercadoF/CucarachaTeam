using System;
using System.Collections.Generic;
using System.Text;

namespace ABugsDeath.Interfaces
{
    public interface IAsset : ICost
    {
        decimal Price { get; set; }
    }
}
