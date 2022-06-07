using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;

namespace NasaApiProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Queries NASA's APOD API for the picture of the day and displays it to the User 
        /// when the button is clicked.
        /// </summary>
        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(
                 @"https://api.nasa.gov/planetary/apod?api_key=ib07wpe905b3e9lA8w6ZFUaV6qxVQZwejdtOqQqE");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                NasaImage img = JsonSerializer.Deserialize<NasaImage>(content);

                using (WebClient web = new WebClient())
                {
                    if (!Directory.Exists(@"c:\temp"))
                        Directory.CreateDirectory(@"c:\temp");
                    
                    web.DownloadFile(new Uri(img.url), @"c:\temp\coolpic.jpg");
                }

                label1.Image = Image.FromFile(@"c:\temp\coolpic.jpg");
                button1.Enabled = false;
            }
        }
    }

    /// <summary>
    /// A class used to interpret the JSON data recieved from the API query.
    /// </summary>
    public class NasaImage
    {
        public string copyright { get; set; }
        public string date { get; set; }
        public string explaination { get; set; }
        public string hdurl { get; set; }
        public string media_type { get; set; }
        public string service_version  { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }
}
