using Tamkeen.IndividualsServices.Core.Models;
using System.Text;
using Tamkeen.IndividualsServices.WebAPIs.Models;
using System.Collections.Generic;
using System.Linq;
using Tamkeen.IndividualsServices.Services.Models;

namespace Tamkeen.IndividualsServices.WebAPIs.Extensions
{
    public static class MappingExtensions
    {
        #region Laborer

        public static LaborerDto ToDto(this Laborer laborer)
        {
            return new LaborerDto
            {
                //Email=
                EstablishmentId = laborer.EstablishmentId,
                Gender = laborer.Gender.Name,
                IdExpirationDate = laborer.LastWPExpirationDate,
                IdNumber = laborer.IdNo,
                Job = laborer.IdNo,
                //MobileNumber,
                Name = GetLaborerFullName(laborer),
                Nationality = laborer.Nationality.Name,
                Number = $"{laborer.LaborOfficeId}-{laborer.SequenceNumber}",
                PassportNumber = laborer.PassportNo,
                ServiceStartDate = laborer.ServiceStartDate,
                Status = laborer.Status.Name,
                StatusModificationDate = laborer.LaborerStatusModificationDate,
                YearOfBirth = laborer.YearOfBirth
            };
        }

        private static string GetLaborerFullName(Laborer laborer)
        {
            var fullName = new StringBuilder();

            fullName.Append(laborer.FirstName);
            fullName.Append(GetNamePart(laborer.SecondName));
            fullName.Append(GetNamePart(laborer.ThirdName));
            fullName.Append(GetNamePart(laborer.FourthName));

            return fullName.ToString();
        }

        private static string GetUserFullName(User user)
        {
            var fullName = new StringBuilder();

            fullName.Append(user.FirstName);
            fullName.Append(GetNamePart(user.SecondName));
            fullName.Append(GetNamePart(user.ThirdName));
            fullName.Append(GetNamePart(user.FourthName));

            return fullName.ToString();
        }

        private static string GetNamePart(string namePart)
        {
            return !(string.IsNullOrEmpty(namePart) && namePart == "-") ? $" {namePart}" : string.Empty;
        }

        #endregion Laborer

        #region Establishment

        public static EstablishmentDto ToDto(this Establishment establishment, EstablishmentKPI establishmentKpi, UserEstablishment userEstablishment)
        {
            return new EstablishmentDto
            {
                Name = establishment.Name,
                Color = establishmentKpi?.Color.Name,
                CommercialRecordNumber = establishment.CommercialRecordNumber,
                EconomicActivity = establishment.SubEconomicActivity?.ActivityName,
                Number = $"{establishment.LaborOfficeId}-{establishment.SequenceNumber}",
                OwnerIdOrSevenHundred = establishment.GetOwnerIdOrSevenHundred(),
                WaselAddress = establishment.GetWasselAddress(),
                Email = establishment.Email,
                Phone = establishment.GetPhone(),
                EstablishmentRepresentatvie = new EstablishmentRepresentatvieDto
                {
                    Email = string.Empty,
                    Mobile = string.Empty,
                    Name = userEstablishment?.Name,
                    Type = userEstablishment?.GetRepresentatvieType()
                }
            };
        }

        private static string GetPhone(this Establishment establishment)
        {
            if (establishment == null)
            {
                return string.Empty;
            }

            return !string.IsNullOrEmpty(establishment.Telephone1) ? establishment.Telephone1 : (!string.IsNullOrEmpty(establishment.Telephone2) ? establishment.Telephone2 : string.Empty);
        }

        private static string GetWasselAddress(this Establishment establishment)
        {
            if (!string.IsNullOrEmpty(establishment.Wasel.Primary))
            {
                return $"{establishment.Wasel.Primary}-{establishment.Wasel.Secondary}, {establishment.Wasel.Street}, {establishment.Wasel.Area}, {establishment.Wasel.City}";
            }

            return string.Empty;
        }

        private static string GetOwnerIdOrSevenHundred(this Establishment establishment)
        {
            if (establishment.UnifiedNumber != null)
            {
                if (establishment.UnifiedNumber.TypeId == (int)EstablishmentTypeList.Individual)
                {
                    return establishment.UnifiedNumber?.Owner?.IdNo;
                }
                else
                {
                    return establishment.UnifiedNumber?.SevenHundredNumber.ToString();
                }
            }

            return string.Empty;
        }

        #endregion Establishment

        #region UserEstablishment
        public static string GetRepresentatvieType(this UserEstablishment userEstablishment)
        {
            if (userEstablishment == null)
            {
                return string.Empty;
            }

            switch (userEstablishment.TypeId)
            {
                case 1:
                    return "Owner";
                case 2:
                    return "Agent";
                case 3:
                    return "Commissioner";
            }

            return string.Empty;

        }
        #endregion

        public static IEnumerable<RunawayRequestDto> ToDto(this IEnumerable<RunawayRequest> runawayRequests)
        {
            return runawayRequests.Select(item => item.ToDto()).ToList();
        }

        public static RunawayRequestDto ToDto(this RunawayRequest runawayRequest)
        {
            return new RunawayRequestDto
            {
                RequesterName = GetUserFullName(runawayRequest.Requester),
                EstablishmentName = runawayRequest.Establishment.Name,
                RequestDate = runawayRequest.CreationDate,
                CancellationDate = runawayRequest.CancellationDate,
                // TODO : Request Information
                CancellationReason = runawayRequest.CancellationReason.ToString(),
                CancellationReasonId = (int)runawayRequest.CancellationReason,
                RunawayDate = runawayRequest.RunawayDate,
                Status = runawayRequest.Status.ToString(),
                StatusId = (int)runawayRequest.Status,
                RunawayComplaintRequests = runawayRequest.RunawayComplaints?.ToDto()
            };
        }

        public static IEnumerable<RunawayComplaintDto> ToDto(this IEnumerable<RunawayComplaint> runawayComplaints)
        {
            return runawayComplaints.Select(item => new RunawayComplaintDto
            {
                ComplaintDate = item.ComplaintDate,
                DecisionDate = item.DecisionDate,
                EstablishmentName = item.Establishment.Name,
                Id = item.Id,
                Reason = item.Reason,
                RejectReason = item.RejectReason,
                Status = ((RunawayComplaintStatusList)item.StatusId).ToString(),
                StatusId = item.StatusId
            }).ToList();
        }
    }
}