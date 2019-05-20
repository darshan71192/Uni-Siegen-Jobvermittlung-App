using System;
using System.Collections.Generic;
using System.Text;

namespace Jobvermittlung
{
    public class JobListing
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Details { get; private set; }
        public string ArbeitZeit { get; private set; }
        public string Lohn { get; private set; }
        public string Ort { get; private set; }
        public string Sprachniveau { get; private set; }        

        public JobListing(string id, string title, string details, string arbeitZeit, string lohn, string ort, string sprachniveau)
        {
            Id = id;
            Title = title;
            Details = details;
            ArbeitZeit = arbeitZeit;
            Lohn = lohn;
            Ort = ort;
            Sprachniveau = sprachniveau;
        }
    }
}
