using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAspNetWebApi.Controllers
{
    public class SponsorTransferController : ApiController
    {
        private static List<OracleTransactionLog> logs = new List<OracleTransactionLog>();

        public SponsorTransferController()
        {
            AllServiceLogs();
        }

        private void AllServiceLogs()
        {
            Establishment est1 = new Establishment { Id = 1, Name = "منشأة 1", LaborOfficeId = 1, SequenceNumber = 233 };
            Establishment est2 = new Establishment { Id = 2, Name = "2 منشأة", LaborOfficeId = 1, SequenceNumber = 4536 };
            Establishment est3 = new Establishment { Id = 3, Name = "3 منشأة", LaborOfficeId = 1, SequenceNumber = 787654 };

            List<Establishment> ests = new List<Establishment>();

            ests.Add(est1);
            ests.Add(est2);
            ests.Add(est3);

            LaborOffice office1 = new LaborOffice { Id = 1, Name = "مكتب 1", Establishments = ests };
            LaborOffice office2 = new LaborOffice { Id = 2, Name = "مكتب 2", Establishments = ests };
            LaborOffice office3 = new LaborOffice { Id = 3, Name = "مكتب 3", Establishments = ests };

            Laborer lab1 = new Laborer
            {
                Id = 34,
                BorderNo = "3003300333",
                EstablishmentId = 1,
                Establishment = est1,
                LaborOffice = office1,
                Nationality = new Nationality { Id = 23, Name = "جنسية 1" },
                NationalityId = 23,
                SaudiFlagId = 1,
                SecondName = "second name",
                SequenceNumber = 536346,
                Status = new LaborerStatus { Id = 5, Name = "Status 1" },
                StatusId = 5,
                FirstName = "first",
                FourthName = "fourth",
                IdNo = "22337758",
                Job = new Job
                {
                    Id = 2,
                    Name = "job 1"
                },
                JobId = 2,
                LaborOfficeId = 1,
                SaudiFlag = new SaudiFlag
                {
                    Id = 343,
                    Name = "NonSaudi"
                },
                ThirdName = "third",
            };
            Laborer lab2 = new Laborer
            {
                Id = 30,
                BorderNo = "355998877",
                EstablishmentId = 2,
                Establishment = est2,
                LaborOffice = office2,
                Nationality = new Nationality { Id = 23, Name = "جنسية 1" },
                NationalityId = 23,
                SaudiFlagId = 1,
                SecondName = "second name",
                SequenceNumber = 98556,
                Status = new LaborerStatus { Id = 5, Name = "Status 1" },
                StatusId = 5,
                FirstName = "first",
                FourthName = "fourth",
                IdNo = "223377500",
                Job = new Job
                {
                    Id = 2,
                    Name = "job 1"
                },
                JobId = 2,
                LaborOfficeId = 1,
                SaudiFlag = new SaudiFlag
                {
                    Id = 343,
                    Name = "NonSaudi"
                },
                ThirdName = "third",
            };
            Laborer lab3 = new Laborer
            {
                Id = 30,
                BorderNo = "366989555",
                EstablishmentId = 3,
                Establishment = est3,
                LaborOffice = office3,
                Nationality = new Nationality { Id = 23, Name = "جنسية 1" },
                NationalityId = 23,
                SaudiFlagId = 1,
                SecondName = "second name",
                SequenceNumber = 98556,
                Status = new LaborerStatus { Id = 5, Name = "Status 1" },
                StatusId = 5,
                FirstName = "first",
                FourthName = "fourth",
                IdNo = "22337744",
                Job = new Job
                {
                    Id = 2,
                    Name = "job 1"
                },
                JobId = 2,
                LaborOfficeId = 1,
                SaudiFlag = new SaudiFlag
                {
                    Id = 343,
                    Name = "NonSaudi"
                },
                ThirdName = "third",
            };

            OracleTransactionLog log1 = new OracleTransactionLog
            {
                Establishment = est1,
                EstablishmentId = est1.Id,
                Laborer = lab1,
                LaborerId = lab1.Id,
                Id = 1,
                LabOff = 4,
                ManPower = false,
                OnlineRequestsId = 5911532,
                OracleResult = "04-1438-41323",
                RepresentativeIdNo = "1010389078",
                SeqNo = 41323,
                Service = new Service { Id = 3, Name = "TransferSponser" },
                ServiceId = 3,
                SerYY = 1438,
                TimeStamp = new DateTime(2017, 4, 26),
                TransactionStatus = 1,
                User = new Shared.Models.User { Id = 33, UserName = "12863518", FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                UserId = 12863518
            };
            OracleTransactionLog log2 = new OracleTransactionLog
            {
                Establishment = est1,
                EstablishmentId = est1.Id,
                Laborer = lab2,
                LaborerId = lab2.Id,
                Id = 2,
                LabOff = 9,
                ManPower = false,
                OnlineRequestsId = 5911549,
                OracleResult = "09-1438-103543",
                RepresentativeIdNo = 1031470568.ToString(),
                SeqNo = 103543,
                Service = new Service { Id = 3, Name = "TransferSponser" },
                ServiceId = 3,
                SerYY = 1438,
                TimeStamp = new DateTime(2017, 4, 26),
                TransactionStatus = 1,
                User = new Shared.Models.User { Id = 33, UserName = 1031470568.ToString(), FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                UserId = 12863518
            };
            OracleTransactionLog log3 = new OracleTransactionLog
            {
                Establishment = est1,
                EstablishmentId = est1.Id,
                Laborer = lab3,
                LaborerId = lab3.Id,
                Id = 3,
                LabOff = 1,
                ManPower = false,
                OnlineRequestsId = 5911548,
                OracleResult = "01-1438-193994",
                RepresentativeIdNo = 1047365240.ToString(),
                SeqNo = 193994,
                Service = new Service { Id = 3, Name = "TransferSponser" },
                ServiceId = 3,
                SerYY = 1438,
                TimeStamp = new DateTime(2017, 4, 26),
                TransactionStatus = 1,
                User = new Shared.Models.User { Id = 33, UserName = 1047365240.ToString(), FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                UserId = 11062868
            };

            OracleTransactionLog log4 = new OracleTransactionLog
            {
                Establishment = est2,
                EstablishmentId = est2.Id,
                Laborer = lab1,
                LaborerId = lab1.Id,
                Id = 4,
                LabOff = 9,
                ManPower = false,
                OnlineRequestsId = 5911547,
                OracleResult = "09-1438-103542",
                RepresentativeIdNo = 1076744463.ToString(),
                SeqNo = 103542,
                Service = new Service { Id = 3, Name = "TransferSponser" },
                ServiceId = 3,
                SerYY = 1438,
                TimeStamp = new DateTime(2017, 4, 26),
                TransactionStatus = 1,
                User = new Shared.Models.User { Id = 33, UserName = 1076744463.ToString(), FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                UserId = 172833
            };
            OracleTransactionLog log5 = new OracleTransactionLog
            {
                Establishment = est3,
                EstablishmentId = est3.Id,
                Laborer = lab1,
                LaborerId = lab1.Id,
                Id = 5,
                LabOff = 1,
                ManPower = false,
                OnlineRequestsId = 5911546,
                OracleResult = "01-1438-193993",
                RepresentativeIdNo = 1043604378.ToString(),
                SeqNo = 193993,
                Service = new Service { Id = 3, Name = "TransferSponser" },
                ServiceId = 3,
                SerYY = 1438,
                TimeStamp = new DateTime(2017, 4, 26),
                TransactionStatus = 1,
                User = new Shared.Models.User { Id = 33, UserName = 1043604378.ToString(), FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                UserId = 12593634
            };


            OracleTransactionLog log6 = new OracleTransactionLog
            {
                Establishment = est2,
                EstablishmentId = est2.Id,
                Laborer = lab2,
                LaborerId = lab2.Id,
                Id = 6,
                LabOff = 9,
                ManPower = false,
                OnlineRequestsId = 5911545,
                OracleResult = "09-1438-103541",
                RepresentativeIdNo = 1059869154.ToString(),
                SeqNo = 103541,
                Service = new Service { Id = 3, Name = "TransferSponser" },
                ServiceId = 3,
                SerYY = 1438,
                TimeStamp = new DateTime(2017, 4, 26),
                TransactionStatus = 1,
                User = new Shared.Models.User { Id = 33, UserName = 1059869154.ToString(), FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                UserId = 819067
            };
            OracleTransactionLog log7 = new OracleTransactionLog
            {
                Establishment = est2,
                EstablishmentId = est2.Id,
                Laborer = lab3,
                LaborerId = lab3.Id,
                Id = 7,
                LabOff = 18,
                ManPower = false,
                OnlineRequestsId = 5911544,
                OracleResult = "18-1438-9778",
                RepresentativeIdNo = 1037748546.ToString(),
                SeqNo = 9778,
                Service = new Service { Id = 3, Name = "TransferSponser" },
                ServiceId = 3,
                SerYY = 1438,
                TimeStamp = new DateTime(2017, 4, 26),
                TransactionStatus = 3,
                User = new Shared.Models.User { Id = 33, UserName = 1037748546.ToString(), FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                UserId = 12167795
            };

            //OracleTransactionLog log8 = new OracleTransactionLog
            //{
            //    Establishment = est1,
            //    EstablishmentId = est1.Id,
            //    Id = 8,
            //    LabOff = 9,
            //    ManPower = false,
            //    OnlineRequestsId = 5911543,
            //    OracleResult = "09-1438-103540",
            //    RepresentativeIdNo = 1014032187.ToString(),
            //    SeqNo = 103540,
            //    Service = new Service { Id = 3, Name = "TransferSponser" },
            //    ServiceId = 3,
            //    SerYY = 1438,
            //    TimeStamp = new DateTime(2017, 4, 26),
            //    TransactionStatus = 1,
            //    User = new Shared.Models.User { Id = 33, UserName = 1014032187.ToString(), FullName = "fullname8" },
            //    UserId = 12580233
            //};
            //OracleTransactionLog log9 = new OracleTransactionLog
            //{
            //    Establishment = est1,
            //    EstablishmentId = est1.Id,
            //    Id = 9,
            //    LabOff = 9,
            //    ManPower = false,
            //    OnlineRequestsId = 5911542,
            //    OracleResult = "09-1438-103539",
            //    RepresentativeIdNo = 1073766642.ToString(),
            //    SeqNo = 103539,
            //    Service = new Service { Id = 3, Name = "TransferSponser" },
            //    ServiceId = 3,
            //    SerYY = 1438,
            //    TimeStamp = new DateTime(2017, 4, 26),
            //    TransactionStatus = 1,
            //    User = new Shared.Models.User { Id = 33, UserName = 1073766642.ToString(), FullName = "fullname9" },
            //    UserId = 12110135
            //};
            //OracleTransactionLog log10 = new OracleTransactionLog
            //{
            //    Establishment = est1,
            //    EstablishmentId = est1.Id,
            //    Id = 10,
            //    LabOff = 9,
            //    ManPower = false,
            //    OnlineRequestsId = 5911541,
            //    OracleResult = "09-1438-103538",
            //    RepresentativeIdNo = 1056550583.ToString(),
            //    SeqNo = 103538,
            //    Service = new Service { Id = 3, Name = "TransferSponser" },
            //    ServiceId = 3,
            //    SerYY = 1438,
            //    TimeStamp = new DateTime(2017, 4, 26),
            //    TransactionStatus = 1,
            //    User = new Shared.Models.User { Id = 33, UserName = 1056550583.ToString(), FullName = "fullname10" },
            //    UserId = 13101733
            //};



            logs.Add(log1);
            logs.Add(log2);
            logs.Add(log3);
            logs.Add(log4);
            logs.Add(log5);
            logs.Add(log6);
            logs.Add(log7);
            //logs.Add(log8);
            //logs.Add(log9);
            //logs.Add(log10);
        }


        // GET: SponsorTransfer/5
        public IHttpActionResult Get(long id)
        {
            var result = logs.Where(log => log.Laborer.IdNo == id.ToString());
            return Json(result);
        }

        // GET: SponsorTransfer
        public IHttpActionResult Get()
        {
            return Json(logs);
        }

        // POST: SponsorTransfer
        public void Post([FromBody]OracleTransactionLog log)
        {
            if (log != null)
                logs.Add(log);
        }

        // PUT: SponsorTransfer/5
        public void Put(long id, [FromBody]OracleTransactionLog log)
        {
            if (log != null)
            {
                var result = logs.Find(lg => lg.Laborer.IdNo == id.ToString());
                if (result != null)
                    result = log;
            }
        }

        // DELETE: /SponsorTransfer/5
        public void Delete(long id)
        {
            logs.Remove(logs.Where(log => log.Laborer.IdNo == id.ToString()).First());
        }
    }
}

