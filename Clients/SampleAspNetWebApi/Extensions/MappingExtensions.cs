using Shared.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAspNetWebApi.Extensions
{
    public static class MappingExtensions
    {
        public static IPagedList<Model.ServiceLog> ToModel(this IPagedList<Shared.Models.ServiceLog> logs)
        {
            List<Model.ServiceLog> model = new List<Model.ServiceLog>();

            foreach (var item in logs)
            {
                model.Add(new Model.ServiceLog
                {
                    Establishment = new Model.Establishment
                    {
                        CommercialRecordNumber = item.Establishment.CommercialRecordNumber,
                        LaborOfficeId = item.Establishment.LaborOfficeId,
                        Name = item.Establishment.Name,
                        SequenceNumber = item.Establishment.SequenceNumber,
                    },
                    Laborer = new Model.Laborer
                    {
                        FirstName = item.Laborer.FirstName,
                        FourthName = item.Laborer.FourthName,
                        IdNo = item.Laborer.IdNo,
                        LaborOfficeId = item.Laborer.LaborOfficeId,
                        SaudiFlagId = item.Laborer.SaudiFlagId,
                        SecondName = item.Laborer.SecondName,
                        SequenceNumber = item.Laborer.SequenceNumber,
                        ThirdName = item.Laborer.ThirdName,
                    },
                    Requester = new Model.User
                    {
                        IdNumber = item.Requester.IdNumber.Value,
                        TypeId = item.Requester.TypeId.Value,
                        UserName = item.Requester.UserName,
                    },
                    RequesterIdNo = item.RequesterIdNo,

                });
            }

            IPagedList<Model.ServiceLog> logsToReturn = new PagedList<Model.ServiceLog>(model, logs.PageIndex, logs.PageSize);


            return logsToReturn;
        }
    }
}