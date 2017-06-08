using Tamkeen.IndividualsServices.Core.Models;
using System;

namespace Tamkeen.IndividualsServices.Services
{
    public class NitaqatService : INitaqatService
    {
        public EstablishmentKPI GetEstablishmentDetails(int laborOfficeId, long sequenceNumber)
        {
            var client = new ServiceReference.EstablishmentKPIWebServiceSoapClient();

            var response = client.GetEstablishmentColor(new ServiceReference.GetEstablishmentColorRequest
            {
                laborOfficeId = laborOfficeId,
                sequenceNumber = sequenceNumber
            });

            if (response != null && response.GetEstablishmentColorResult <= 0)
            {
                //TODO: Create Typed Exception
                throw new Exception("Connot get establishment color");
            }

            return new EstablishmentKPI
            {
                LaborOfficeId = laborOfficeId,
                SequenceNumber = sequenceNumber,
                Color = new Color
                {
                    Id = response.GetEstablishmentColorResult
                }
            };
        }
    }
}
