using SmartStock.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetByName(string name);
        Client GetByCpf(string cpf);
        
    }
}
