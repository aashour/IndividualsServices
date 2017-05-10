using Shared.Data;
using Shared.DataStructure;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tamkeen.IndividualsServices.Services;

namespace SampleAspNetWebApi.Controllers
{
    [Authorize]
    public class RunawayController : ApiController
    {
        private readonly IServiceLogService _serviceLogService;
        private static IPagedList<ServiceLog> logs = null;

        public RunawayController(IServiceLogService serviceLogService)
        {
            this._serviceLogService = serviceLogService;
            AllServiceLogs();
        }

        private void AllServiceLogs()
        {
            var logs = this._serviceLogService.SearchServiceLog(pageIndex: 0, pageSize: 20);

            if (logs.Count > 0)
                return;

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

            ServiceLog log1 = new ServiceLog
            {
                Establishment = est1,
                EstablishmentId = est1.Id,
                LaborerId = lab1.Id,
                RequesterIdNo = "233578889",
                Id = 1,
                Laborer = lab1,
                Requester = new Shared.Models.User { Id = 1, UserName = "233578889", FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                ServiceId = 24,
            };
            ServiceLog log2 = new ServiceLog
            {
                Establishment = est1,
                EstablishmentId = est1.Id,
                LaborerId = lab1.Id,
                RequesterIdNo = "2335789855",
                Id = 2,
                Laborer = lab1,
                Requester = new Shared.Models.User { Id = 2, UserName = "2335789855", FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                ServiceId = 24,
            };
            ServiceLog log3 = new ServiceLog
            {
                Establishment = est1,
                EstablishmentId = est1.Id,
                LaborerId = lab1.Id,
                RequesterIdNo = "255888996",
                Id = 3,
                Laborer = lab1,
                Requester = new Shared.Models.User { Id = 3, UserName = "255888996", FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                ServiceId = 24,
            };
            ServiceLog log4 = new ServiceLog
            {
                Establishment = est2,
                EstablishmentId = est2.Id,
                LaborerId = lab2.Id,
                RequesterIdNo = "1545988722",
                Id = 4,
                Laborer = lab2,
                Requester = new Shared.Models.User { Id = 4, UserName = "1545988722", FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                ServiceId = 24,
            };
            ServiceLog log5 = new ServiceLog
            {
                Establishment = est2,
                EstablishmentId = est2.Id,
                LaborerId = lab2.Id,
                RequesterIdNo = "1545988722",
                Id = 5,
                Laborer = lab2,
                Requester = new Shared.Models.User { Id = 4, UserName = "1545988722", FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                ServiceId = 24,
            };
            ServiceLog log6 = new ServiceLog
            {
                Establishment = est2,
                EstablishmentId = est2.Id,
                LaborerId = lab2.Id,
                RequesterIdNo = "1545988722",
                Id = 6,
                Laborer = lab2,
                Requester = new Shared.Models.User { Id = 4, UserName = "1545988722", FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                ServiceId = 24,
            };
            ServiceLog log7 = new ServiceLog
            {
                Establishment = est3,
                EstablishmentId = est3.Id,
                LaborerId = lab3.Id,
                RequesterIdNo = "1234567890",
                Id = 7,
                Laborer = lab3,
                Requester = new Shared.Models.User { Id = 7, UserName = "1234567890", FirstName = "first", SecondName = "second", ThirdName = "third", FourthName = "last" },
                ServiceId = 24,
            };

            List<ServiceLog> lst = new List<ServiceLog>();
            lst.Add(log1);
            lst.Add(log2);
            lst.Add(log3);
            lst.Add(log4);
            lst.Add(log5);
            lst.Add(log6);
            lst.Add(log7);

            logs = new PagedList<ServiceLog>(lst, 0, 10);
        }

        // GET: /Runaway/5
        public IHttpActionResult Get(long id)
        {
            var result = logs.Where(log => log.Laborer.IdNo == id.ToString());
            return Json(result);
        }

        // GET: /Runaway
        public IHttpActionResult Get()
        {
            return Json(logs);
        }

        // POST: /Runaway
        public void Post([FromBody]ServiceLog log)
        {
            if (log != null)
                logs.Add(log);
        }

        // PUT: /Runaway/5
        public void Put(long id, [FromBody]ServiceLog log)
        {
            if (log != null)
            {
                var result = this._serviceLogService.ServiceLogForLaborer(id, 0, 10).FirstOrDefault();
                if (result != null)
                    result = log;
            }
        }

        // DELETE: /Runaway/5
        public void Delete(long id)
        {
            logs.Remove(logs.Where(log => log.Laborer.IdNo == id.ToString()).First());
        }
    }
}
