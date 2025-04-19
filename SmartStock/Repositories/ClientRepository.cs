using Dapper;
using Microsoft.Data.SqlClient;
using SmartStock.Entities;
using SmartStock.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly SqlConnection _connection;

        public ClientRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Client> GetAll()
        {
            var sql = "SELECT * FROM Client";
            return _connection.Query<Client>(sql);
        }


        public Client GetById(int id)
        {
            var sql = "SELECT * FROM Client WHERE IdClient = @IdClient";
            return _connection.QueryFirstOrDefault<Client>(sql, new { IdClient = id });
        }

        public Client GetByName(string name)
        {
            var sql = "SELECT * FROM Client WHERE Name LIKE @Name";
            return _connection.QueryFirstOrDefault<Client>(sql, new { Name = $"%{name}%" });
        }


        public Client GetByCpf(string cpf)
        {
            //cpf = cpf.Replace(".", "").Replace("-", "");
            var sql = "SELECT * FROM Client WHERE CpfClient = @CpfClient";
            return _connection.QueryFirstOrDefault<Client>(sql, new { CpfClient = cpf });
        }


        public void Insert(Client client)
        {
            var sql = @"INSERT INTO Client (Name, EmailClient, CpfClient, PhoneClient, CreateDate)
                        VALUES (@Name, @EmailClient, @CpfClient, @PhoneClient, @CreateDate)";
            _connection.Execute(sql, client);
        }

        public void Update(Client client)
        {
            var sql = @"UPDATE Client
                        SET Name = @Name, EmailClient = @EmailClient, CpfClient = @CpfClient, PhoneClient = @PhoneClient, CreateDate = @CreateDate
                        Where IdClient = @IdClient";
            _connection.Execute(sql, client);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Client WHERE IdClient = @IdClient";
            _connection.Execute(sql, new { IdClient = id });
        }


    }
}
