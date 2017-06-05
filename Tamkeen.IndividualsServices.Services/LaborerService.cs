using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Models;
using Shared.Data;

namespace Tamkeen.IndividualsServices.Services
{
    public class LaborerService : ILaborerService
    {

        private readonly IRepository<Laborer, long> _laborerRepository;

        public LaborerService(IRepository<Laborer, long> laborerRepository)
        {
            this._laborerRepository = laborerRepository;
        }

        public Laborer GetLaborerByBorderNumber(string borderNumber)
        {
            var query = from laborer in _laborerRepository.Table
                        where laborer.BorderNo.Equals(borderNumber, StringComparison.InvariantCultureIgnoreCase)
                        select laborer;

            return query.FirstOrDefault();
        }

        public Laborer GetLaborerById(long laborerId)
        {
            return _laborerRepository.GetById(laborerId);
        }

        public Laborer GetLaborerByIdNumber(string idNumber)
        {
            var query = from laborer in _laborerRepository.Table
                        where laborer.IdNo.Equals(idNumber, StringComparison.InvariantCultureIgnoreCase)
                        select laborer;
            
            return query.FirstOrDefault();
        }

        public IList<Laborer> GetLaborersByIdNumbers(string[] laborerIdNumbers)
        {
            if (laborerIdNumbers == null || laborerIdNumbers.Length == 0)
                return new List<Laborer>();

            var query = from l in _laborerRepository.Table
                        where laborerIdNumbers.Contains(l.IdNo)
                        select l;

            var laborers = query.ToList();
            //sort by passed identifiers
            var sortedLaborers = new List<Laborer>();

            foreach (string idNumber in laborerIdNumbers)
            {
                var laborer = laborers.Find(x => x.IdNo == idNumber);
                if (laborer != null)
                    sortedLaborers.Add(laborer);
                else
                    sortedLaborers.Add(new Laborer { IdNo = idNumber });
            }

            return sortedLaborers;
        }

        public IList<Laborer> GetLaborersByIds(long[] laborerIds)
        {
            if (laborerIds == null || laborerIds.Length == 0)
                return new List<Laborer>();

            var query = from p in _laborerRepository.Table
                        where laborerIds.Contains(p.Id)
                        select p;

            var laborers = query.ToList();
            //sort by passed identifiers
            var sortedLaborers = new List<Laborer>();
            foreach (int id in laborerIds)
            {
                var laborer = laborers.Find(x => x.Id == id);
                if (laborer != null)
                    sortedLaborers.Add(laborer);
            }

            return sortedLaborers;
        }
    }
}
