namespace SampleAspNetWebApi.Model
{
    public class ServiceLog
    {
        public string RequesterIdNo { get; set; }
        public virtual Establishment Establishment { get; set; }
        public virtual Laborer Laborer { get; set; }
        public virtual User Requester { get; set; }
    }
}