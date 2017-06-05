using SampleAspNetWebApi.Model;
using Shared.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SampleAspNetWebApi.Extensions
{
    public static class MappingExtensions
    {
        //public static IPagedList<Model.ServiceLog> ToModel(this IPagedList<Shared.Models.ServiceLog> logs)
        //{
        //    List<Model.ServiceLog> model = new List<Model.ServiceLog>();

        //    foreach (var item in logs)
        //    {
        //        model.Add(new Model.ServiceLog
        //        {
        //            Establishment = new Model.Establishment
        //            {
        //                CommercialRecordNumber = item.Establishment.CommercialRecordNumber,
        //                LaborOfficeId = item.Establishment.LaborOfficeId,
        //                Name = item.Establishment.Name,
        //                SequenceNumber = item.Establishment.SequenceNumber,
        //            },
        //            Laborer = new Model.Laborer
        //            {
        //                FirstName = item.Laborer.FirstName,
        //                FourthName = item.Laborer.FourthName,
        //                IdNo = item.Laborer.IdNo,
        //                LaborOfficeId = item.Laborer.LaborOfficeId,
        //                SaudiFlagId = item.Laborer.SaudiFlagId,
        //                SecondName = item.Laborer.SecondName,
        //                SequenceNumber = item.Laborer.SequenceNumber,
        //                ThirdName = item.Laborer.ThirdName,
        //            },
        //            Requester = new Model.User
        //            {
        //                IdNumber = item.Requester.IdNumber.Value,
        //                TypeId = item.Requester.TypeId.Value,
        //                UserName = item.Requester.UserName,
        //            },
        //            RequesterIdNo = item.RequesterIdNo,

        //        });
        //    }

        //    IPagedList<Model.ServiceLog> logsToReturn = new PagedList<Model.ServiceLog>(model, logs.PageIndex, logs.PageSize);


        //    return logsToReturn;
        //}

        public static Laborer ToModel(this Shared.Models.Laborer laborer)
        {
            return new Laborer
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

        public static Establishment ToModel(this Shared.Models.Establishment es)
        {
            return new Establishment();
        }

        private static string GetLaborerFullName(Shared.Models.Laborer laborer)
        {
            var fullName = new StringBuilder();

            fullName.Append(laborer.FirstName);
            fullName.Append(!string.IsNullOrEmpty(laborer.SecondName) && laborer.SecondName == "-" ? $" {laborer.SecondName}" : string.Empty);
            fullName.Append(!string.IsNullOrEmpty(laborer.ThirdName) && laborer.ThirdName == "-" ? $" {laborer.ThirdName}" : string.Empty);
            fullName.Append(!string.IsNullOrEmpty(laborer.FourthName) && laborer.FourthName == "-" ? $" {laborer.FourthName}" : string.Empty);

            return fullName.ToString();
        }
    }
}