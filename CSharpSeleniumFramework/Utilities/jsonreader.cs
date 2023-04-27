using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.Utilities
{
    public class jsonreader
    {

        public jsonreader() { }

        public string extractData(String tokenName) {
          var myJsonString=  File.ReadAllText("Utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
           return  jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string[] extractDataArray(String tokenName)
        {
            var myJsonString = File.ReadAllText("Utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<string> productList = jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productList.ToArray();
        }
    }
}
