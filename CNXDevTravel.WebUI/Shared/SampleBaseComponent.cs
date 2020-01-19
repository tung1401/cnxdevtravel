using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CNXDevTravel.WebUI.Shared
{
    public class SampleBaseComponent: ComponentBase, IDisposable
    {
        [Inject]
        protected IJSRuntime jsRuntime { get; set; }

        internal SampleData SampleDetails { get; set; } = new SampleData();
        protected override void OnAfterRender(bool FirstRender)
        {
            if (FirstRender)
            {
                this.jsRuntime.InvokeVoidAsync("hideSpinner");
                //SampleBrowser.CurrentControl = SampleDetails.CurrentControl;
                //SampleBrowser.CurrentSampleName = SampleDetails.CurrentSampleName;
                //SampleBrowser.CurrentControlName = SampleDetails.CurrentControlName;
                //SampleBrowser.CurrentControlCategory = SampleDetails.CurrentControlCategory;
                //SampleBrowser.TitleTag = SampleDetails.TitleTag;
                //SampleBrowser.MetaDescription = SampleDetails.MetaDescription;
                //SampleBrowser.ActionDescription = SampleDetails.ActionDescription;
                //SampleBrowser.Description = SampleDetails.Description;
                //this.StateHasChanged();
            }
        }

        public void Dispose()
        {
           // jsRuntime.InvokeAsync<string>("contentDispose");
        }
    }

    internal class SampleData
    {
        public List<SampleList> SampleList { get; set; } = new List<SampleList>();
        //internal SampleConfig Config = SampleBrowser.SampleList
        internal string CurrentSampleName;
        internal List<Sample> CurrentControl;
        internal string CurrentControlName;
        internal string CurrentControlCategory;
        internal string CurrentFilePath;
        internal string CurrentUrl;
        internal string TitleTag;
        internal string MetaDescription;
        internal string[] ActionDescription;
        internal string[] Description;
        internal List<String> SampleUrls = new List<String>();
    }

    internal class SampleList
    {

        public string Name { get; set; }
        public string Directory { get; set; }
        public string Category { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SampleType Type { get; set; }
        public int Order { get; set; }
        public int UID { get; set; }

        public List<Sample> Samples { get; set; } = new List<Sample>();

        public String ControllerName { get; set; }
    }

    internal class Sample
    {
        public string Name { get; set; }
        public string Directory { get; set; }
        public string Category { get; set; }
        public int Order { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string TitleTag { get; set; }
        public string MetaDescription { get; set; }

        public string[] ActionDescription { get; set; }

        public string[] Description { get; set; }
        public List<SourceCollection> SourceFiles { get; set; } = new List<SourceCollection>();

        [JsonConverter(typeof(StringEnumConverter))]
        public SampleType Type { get; set; }
    }

    internal class SourceCollection
    {
        public string FileName { get; set; }
        public string Id { get; set; }
    }

    enum SampleType
    {
        None,
        New,
        Updated,
        Preview
    }
}
