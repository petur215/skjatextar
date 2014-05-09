using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using skjatextar.Models;

namespace skjatextar.DAL
{
    public class RequestInitializer : DropCreateDatabaseAlways<RequestContext>
    {
        public override void InitializeDatabase(RequestContext context)
        {
            var requests = new List<Request>
            {
                new Request{
                    Username = "ViggiCool",
                    NewRequest = "Mig langar i Mean Girls",
                    RequestSent = DateTime.Parse("2014-05-09 16:58:00")
                },
                new Request{
                    Username = "PesiSvali",
                    NewRequest = "Mig langar i Shopaholic",
                    RequestSent = DateTime.Parse("2014-05-08 16:58:00")
                },
                new Request{
                    Username = "ToniToff",
                    NewRequest = "Nennir e-h ad gera ToyStory 2",
                    RequestSent = DateTime.Parse("2014-03-08 16:58:00")
                },
                new Request{
                    Username = "EinsiPungur",
                    NewRequest = "Nennir e-r ad thyda Mama Mia",
                    RequestSent = DateTime.Parse("2014-05-08 16:58:00")
                },
                new Request{
                    Username = "PesiIceBerg",
                    NewRequest = "Mig langar ad sja Pirates(klammyndina)",
                    RequestSent = DateTime.Parse("2014-02-08 16:58:00")
                },
            };
        }
    }
}