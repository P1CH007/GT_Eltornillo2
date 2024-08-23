using System;
using System.Collections.Generic;
using System.Data;
using Entities;
using Persistence;

namespace Logic
{
    public class ClientsDAO
    {
        public bool AddClient(Clients client)
        {
            Create create = new Create();
            return create.AddClient(
                client.ClientCi,
                client.ClientName,
                client.ClientLastName,
                client.City,
                client.Street,
                client.NumberSt,
                client.Phone,
                client.Email,
                client.DateOfAdmission
            );
        }

        public bool DeleteClient(string clientId)
        {
            Delete del = new Delete();
            return del.DeleteClient(clientId);
        }

        public List<Clients> GetClients()
        {
            Read read = new Read();
            DataTable dt = read.GetClientsData();
            List<Clients> clients = new List<Clients>();

            foreach (DataRow row in dt.Rows)
            {
                Clients client = new Clients
                {
                    ClientCi = row["ClientCi"].ToString(),
                    ClientName = row["ClientName"].ToString(),
                    ClientLastName = row["ClientLastName"].ToString(),
                    City = row["City"].ToString(),
                    Street = row["Street"].ToString(),
                    NumberSt = row["NumberSt"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString()
                };
                clients.Add(client);
            }

            return clients;
        }

        public Clients GetClientByCi(string clientId)
        {
            Read read = new Read();
            DataRow row = read.GetClientByCiData(clientId);

            if (row != null)
            {
                Clients client = new Clients
                {
                    ClientCi = row["ClientCi"].ToString(),
                    ClientName = row["ClientName"].ToString(),
                    ClientLastName = row["ClientLastName"].ToString(),
                    City = row["City"].ToString(),
                    Street = row["Street"].ToString(),
                    NumberSt = row["NumberSt"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    DateOfAdmission = row["DateOfAdmission"] != DBNull.Value ? Convert.ToDateTime(row["DateOfAdmission"]) : DateTime.MinValue,
                };
                return client;
            }

            return null;
        }

        public bool UpdateClient(Clients client)
        {
            Update update = new Update();
            return update.UpdateClient(
                client.ClientCi,
                client.ClientName,
                client.ClientLastName,
                client.City,
                client.Street,
                client.NumberSt,
                client.Phone,
                client.Email,
                client.DateOfAdmission
            );
        }
    }
}
