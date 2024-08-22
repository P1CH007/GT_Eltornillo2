using System;
using System.Collections.Generic;
using System.Data;
using Entities;
using Persistence;

namespace Logic
{
    public class LocalDAO
    {
        public bool AddLocal(Local local)
        {
            Create create = new Create();
            return create.AddLocal(
                local.LocalName,
                local.Country,
                local.City,
                local.Street,
                local.NumberSt,
                string.Join(",", local.Services),  // Convert array to comma-separated string
                local.Description,
                local.OpeningTime,
                local.ClosingTime
            );
        }

        public bool DeleteLocal(int localID)
        {
            Delete del = new Delete();
            return del.DeleteLocal(localID);
        }

        public List<Local> GetLocals()
        {
            Read read = new Read();
            DataTable dt = read.GetLocalsData();
            List<Local> locals = new List<Local>();

            foreach (DataRow row in dt.Rows)
            {
                Local local = new Local
                {
                    LocalID = Convert.ToInt32(row["LocalID"]),
                    LocalName = row["LocalName"].ToString(),
                    Country = row["Country"].ToString(),
                    City = row["City"].ToString(),
                    Street = row["Street"].ToString(),
                    NumberSt = row["NumberSt"].ToString(),
                    Services = row["Services"].ToString().Split(','),  // Convert comma-separated string to array
                    Description = row["Description"].ToString(),
                    OpeningTime = TimeSpan.Parse(row["OpeningTime"].ToString()),
                    ClosingTime = TimeSpan.Parse(row["ClosingTime"].ToString())
                };
                locals.Add(local);
            }

            return locals;
        }

        public Local GetLocalById(int localID)
        {
            Read read = new Read();
            DataRow row = read.GetLocalByIdData(localID);

            if (row != null)
            {
                Local local = new Local
                {
                    LocalID = Convert.ToInt32(row["LocalID"]),
                    LocalName = row["LocalName"].ToString(),
                    Country = row["Country"].ToString(),
                    City = row["City"].ToString(),
                    Street = row["Street"].ToString(),
                    NumberSt = row["NumberSt"].ToString(),
                    Services = row["Services"].ToString().Split(','),  // Convert comma-separated string to array
                    Description = row["Description"].ToString(),
                    OpeningTime = TimeSpan.Parse(row["OpeningTime"].ToString()),
                    ClosingTime = TimeSpan.Parse(row["ClosingTime"].ToString())
                };
                return local;
            }

            return null;
        }

        public bool UpdateLocal(Local local)
        {
            Update update = new Update();
            return update.UpdateLocal(
                local.LocalID,
                local.LocalName,
                local.Country,
                local.City,
                local.Street,
                local.NumberSt,
                string.Join(",", local.Services),  // Convert array to comma-separated string
                local.Description,
                local.OpeningTime,
                local.ClosingTime
            );
        }
    }
}
