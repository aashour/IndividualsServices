using Tamkeen.IndividualsServices.Core.Models;
using System.Collections.Generic;

namespace Tamkeen.IndividualsServices.Services
{
    public interface ILaborerService
    {
        Laborer GetLaborerById(long laborerId);

        IList<Laborer> GetLaborersByIds(long[] laborerIds);

        Laborer GetLaborerByIdNumber(string idNumber);

        Laborer GetLaborerByBorderNumber(string borderNumber);

        IList<Laborer> GetLaborersByIdNumbers(string[] laborerIdNumbers);
    }
}
