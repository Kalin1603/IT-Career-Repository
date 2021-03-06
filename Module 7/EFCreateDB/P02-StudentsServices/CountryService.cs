﻿namespace P02_StudentsServices
{
    using P02_StudentsAppData;
    using P02_StudentsAppData.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CountryService 
    {
        private readonly ApplicationDbContext dbContext;

        public CountryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string AddCountry(string name)
        {
            Country country = GetCountryByName(name);

            if (country==null)
            {
                this.dbContext.Countries.Add(new Country() { Name = name });
                dbContext.SaveChanges();
                return $"Country {name} is added";
            }

            else
            {
                return $"{name} already exist";
            }

        }

        public string GetAllCountries()
        {
            StringBuilder sb = new StringBuilder();
            List<Country> countries = dbContext.Countries.ToList();
            sb.AppendLine(">> Countries list");
            sb.AppendLine(new string('-', 30));
            sb.AppendLine($"{"Id",3} | {"Name",10}");
            sb.AppendLine(new string('-', 30));

            foreach (var c in countries)
            {
                sb.AppendLine($"{c.Id,3} | {c.Name,10}");
            }
            sb.AppendLine(new string('-', 30));
            return sb.ToString().TrimEnd();
        }

        public string EditCountryNameById(int id,string newName)
        {
            Country country = GetCountryById(id);
            if (country!=null)
            {
                country.Name = newName;
                dbContext.Countries.Update(country);
                dbContext.SaveChanges();
                return $"Country with id: {id} has new Name: {newName}";
            }
            else
            {
                return $"Country with id: {id} not found!";
            }
        }

        public string RemoveCountry(int id,string removedName)
        {
            Country country = GetCountryById(id);
            if (country != null)
            {
                country.Name = removedName;
                dbContext.Countries.Remove(country);
                dbContext.SaveChanges();
                return $"Country with id: {id} and Name: {removedName} is removed!";
            }
            else
            {
                return $"Country with id: {id} not found!";
            }
        }

        public Country GetCountryById(int id)
        {
            return this.dbContext.Countries.FirstOrDefault(x => x.Id == id);
        }

        public Country GetCountryByName(string name)
        {
            return this.dbContext.Countries.FirstOrDefault(x => x.Name == name);
        }      
    }
}
