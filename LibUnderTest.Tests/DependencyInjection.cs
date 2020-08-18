using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibUnderTest.Tests
{
    public class DependencyInjection_HardToTestServices
    {
        public DependencyInjection_HardToTestServices()
        {

        }


        public string MethodUnderTest()
        {
            var myService = new ThingDoer();

            //CN: How do we test the different possible conditions that come out of this?
            //  What happens when it returns null?
            //  What happens when it returns a value?
            //Since we're using a real implementation we would have to do a ton of work within that 
            //and it makes it hard to prove out *this* method (MethodUnderTest).
            var result = myService.DoThingWithSpecialSite();

            if (result.HasValue)
            {
                return $"Value was 100 less than: {result.Value + 100}";
            }

            return ":(";
        }
        
    }

    public class DependencyInjection_HardToTestSingleton
    {
        public  DependencyInjection_HardToTestSingleton()
        {

        }

        public string MethodUnderTest()
        {
            //CN -- How do we test this method? 
            // What if we want to ensure the behaviour when GetString() returns null?
            //  When it's empty?
            //  When it's null?
            //  When it's got a '7'
            //  When it doesn't have a '7'
            //Since we're using a static accessor style (GO4) singleton we can't inject
            //the behaviours we want to test. It makes it hard to isolate a unit
            var stringICareAbout = GangOfFourSingleton.Instance.GetString();

            if (stringICareAbout.Contains("7"))
            {
                return stringICareAbout;
            }

            return stringICareAbout + "7";
        }
    }


    public class DependencyInjection_EasyToTestSingleton
    {
        private readonly IStringGetter _stringGetter;

        //CN -- The object doesn't really *need* to know that IStringGetter is being injected
        // as a singleton or as a transient service - provided its needs are being met everything
        // should be cool.
        public DependencyInjection_EasyToTestSingleton(IStringGetter stringGetter)
        {
            _stringGetter = stringGetter ?? throw new ArgumentNullException(nameof(stringGetter));
        }

        public string MethodUnderTest()
        {
            var stringICareAbout =_stringGetter.GetString();

            if (stringICareAbout?.Contains("7") ?? false)
            {
                return stringICareAbout;
            }

            return stringICareAbout + "7";
        }
    }

    public class DependencyInjection_EasyToTestServices
    {
        private readonly IThingDoer _thingDoer;

        //CN -- Looks the same right? That's because what we're really doing is
        // just removing the knowledge of the implementation details!
        public DependencyInjection_EasyToTestServices(IThingDoer thingDoer)
        {
            _thingDoer = thingDoer;
        }


        public string MethodUnderTest()
        {
            var result = _thingDoer.DoThingWithSpecialSite();

            if (result.HasValue)
            {
                return $"Value was 100 less than: {result.Value + 100}";
            }

            return ":(";
        }

    }

    public interface IStringGetter
    {
        string GetString();
    }

    public class GangOfFourSingleton : IStringGetter
    {
        //Ignore thread safety for now
        private static GangOfFourSingleton _instance;
        public static GangOfFourSingleton Instance => _instance ??= new GangOfFourSingleton();

        //CN -- Depends on something that we can't control in a test!
        public string GetString() => $"Oh no! Static state! {DateTime.Now.Second}";
    }

    public interface IThingDoer
    {
        int? DoThingWithSpecialSite();
    }

    public class ThingDoer : IThingDoer
    {
        public int? DoThingWithSpecialSite()
        {
            //CN -- not good use of resources -- async!
            var client = new HttpClient();

            //Slow vs normal unit tests
            var res = client.GetAsync("https://google.ca").Result;

            if (!res.IsSuccessStatusCode)
            {
                return null;
            }

            return res.Content.ReadAsStringAsync().Result.Length;

        }
    }
}
