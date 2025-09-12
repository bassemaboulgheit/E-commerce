using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public interface ICartService
    {
        public void CreateCart(Cart category);
    }
}
