﻿using Supermarket.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Api.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}
