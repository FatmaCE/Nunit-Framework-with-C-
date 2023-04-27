using Newtonsoft.Json.Linq;
using System;
using System.IO;


        String myJsonString = File.ReadAllText("testData.json");


        var jsonObject = JToken.Parse(myJsonString);
        Console.WriteLine(jsonObject.SelectToken("username").Value<string>());
    
