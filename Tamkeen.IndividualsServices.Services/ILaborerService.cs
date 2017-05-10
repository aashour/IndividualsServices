using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Services
{
    public interface ILaborerService
    {
        Laborer GetLaborerById(int laborerId);

        IList<Laborer> GetLaborersByIds(long[] laborerIds);

        Laborer GetLaborerByIdNumber(string idNumber);

        Laborer GetLaborerByBorderNumber(string borderNumber);

        IList<Laborer> GetLaborersByIdNumbers(string[] laborerIdNumbers);
    }
}
