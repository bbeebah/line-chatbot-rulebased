#r "Newtonsoft.Json"
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{

    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    
    name = name ?? data?.name;

    if (data.events[0].message.type != "text") {
        log.LogInformation("return(empty)");
        return new BadRequestObjectResult("not text");
    }

    
    using (var client = new HttpClient())
    {
        var input = (string) data.events[0].message.text;
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Authorization", "Bearer <token-from-Line-portal");
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
       
        dictionary.Add("type", "text");
//         change input value here for message that you want bot to reply. 
//         in case it's not acho bot anymore ;p.
        dictionary.Add("text", input);
        
        var temp = new ReplyBody();
        temp.replyToken = data.events[0].replyToken;
        temp.messages = new List<Dictionary<string, string>>();
        temp.messages.Add(dictionary);

        string json = JsonConvert.SerializeObject(temp);

        var requestData = new StringContent(json, Encoding.UTF8, "application/json");
        var url = "https://api.line.me/v2/bot/message" + "/reply";
        var response = await client.PostAsync(url, requestData);
        var result = await response.Content.ReadAsStringAsync();

        log.LogInformation("----result-----");
//         if success, the result will be empty (May 2020).
        log.LogInformation(result);
    }


    return name != null
        ? (ActionResult)new OkObjectResult($"Hello, {name}")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
    
}

// return object structure (May 2020)
public class ReplyBody
{
    public string replyToken { get; set; }
    public List<Dictionary<string, string>> messages { get; set; }
}
