using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Services
{
    public class NitaqatService : INitaqatService
    {
        public EstablishmentKPI GetEstablishmentDetails(int laborOfficeId, long sequenceNumber)
        {
            var client = new NitaqatServiceReference.EstablishmentKPIWebServiceSoapClient();

            var colorId = client.GetEstablishmentColor(laborOfficeId, sequenceNumber);

            if (colorId <= 0)
            {
                //TODO: Create Typed Exception
                throw new Exception("Connot get estblishment color");
            }

            return new EstablishmentKPI
            {
                LaborOfficeId = laborOfficeId,
                SequenceNumber = sequenceNumber,
                Color = new Color
                {
                    Id = colorId
                }
            };
        }
    }
}
