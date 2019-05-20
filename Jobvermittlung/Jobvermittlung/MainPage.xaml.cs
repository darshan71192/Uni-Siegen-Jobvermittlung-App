using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using HtmlAgilityPack;

namespace Jobvermittlung
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public IList<JobListing> ListOfAllJobs { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            //ListOfAllJobs = new List<JobListing>();
            GetAllJobs();

            BindingContext = this;
        }

        private void GetAllJobs()
        {
            ListOfAllJobs = new List<JobListing>();

            // TODO web scrapping and populating data
            var url = "https://www.jobvermittlung.uni-siegen.de/studierende/stellenangebote.xml";

            var web = new HtmlWeb();
            var doc = web.Load(url);
            var nodes = doc.DocumentNode.Descendants("div")
                                        .Where(x => x.Attributes["class"] != null &&
                                                    x.Attributes["class"].Value == "block" && 
                                                    x.Attributes["id"] != null && 
                                                    x.Attributes["id"].Value != "");
            foreach (var node in nodes)
            {
                var id = node.SelectSingleNode("div/strong/a").InnerText as string;
                var title = node.SelectSingleNode("h2/a").InnerText;
                var details = node.SelectSingleNode("p").InnerText;
                var time = node.SelectSingleNode("ul/li[1]").InnerText;
                var lohn = node.SelectSingleNode("ul/li[2]").InnerText;
                var ort = node.SelectSingleNode("ul/li[3]").InnerText;
                var sprache = "N/A";
                if (node.SelectSingleNode("ul/li[4]") != null)
                {
                    sprache = node.SelectSingleNode("ul/li[4]").InnerText;
                }                
                ListOfAllJobs.Add(new JobListing(id.Trim(), title, details, time, lohn, ort, sprache));
            }
        }        
    }
}
