using Flipping.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flipping.Services
{
    public interface IGrandExchangeService
    {
        Task<string> GetAsync(string uri);
    }
}
