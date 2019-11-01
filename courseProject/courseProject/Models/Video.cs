using System;
namespace courseProject.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public int Url_Video { get; set; }
        public Therapy Video_Therapy { get; set; }
    }
}
