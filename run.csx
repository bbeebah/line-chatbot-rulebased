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
        // var text = data.events[0].message.text;
        // log.LogInformation(text);
        log.LogInformation("return(empty)");
        return new BadRequestObjectResult("not text");
    }

    
    using (var client = new HttpClient())
    {

        /* handle input */
        List<string> list2 = new List<string>()
        {
            "วันนี้เป็นไงมั่งงง",
            "เบื่อ ๆ เหงา ๆ อยุ่ ป่าววว",
            "ไว้ไปกินโมโม่หลังโควิทหายนะ หาย-นะ ที่ไม่ใช่ หา-ยะ-นะ",
            "เบื่อ ๆ ก้ฝากหาวิธีดู Disney+ หน่อยสิ่ อยากดูจุงงง",
            "ตอนนี้ใครใครก้เบื่อทั้งนั้นแหล่ะ อดทนหน่อยสิ่",
            "อยากรวย ก้ต้องหาทาง",
            "อะไรเอ่ย เอ่ยออกมาจากแชท!"
        };

        var output = list2[DateTime.Now.Second % 7];
        var input = (string) data.events[0].message.text;
        // log.LogInformation(input);
        input = input.ToLower();
        List<string> list1 = new List<string>()
        {
            "hi",
            "hello",
            "hey",
            "hey",
            "สวัสดี",
            "ฮัลโหล",
            "yo"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = "ทักทาย Hi jraaaaa :)";
            }
        }

        list1 = new List<string>()
        {
            "stupid",
            "noob",
            "โง่",
            "กาก",
            "อ่อน",
            "ควาย"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = "ยอมรับ และอาจจะนำไปปรับปรุง แต่ไม่สัญญานะ 5555555555";
            }
        }
        list1 = new List<string>()
        {
            "ฉลาด",
            "เก่ง",
            "เอ๋อ",
            "เนิด",
            "เด๋อ"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = "หวาวววววว นี่ชมใคร หรือประชดรึเปล่าอ่ะ ไม่น่าเป็นเราได้";
            }
        }
        if(input.Contains("เน็ต") || input.Contains("net")){
                output = "เน็ตกากรึเปล่า เน็ตไม่น่ารักรึเปล่า ....";
            }
        if(input.Contains("เบื่อ") || input.Contains("ว่าง") || input.Contains("เหงา")){
                output = "ไม่ต่างกัน... ไม่งั้นไม่ทำอันนี้หรอกกก 55555555555";
            }
        if(input.Contains("ใคร") || input.Contains("ชื่อ")){
                output = "เราเป็นใคร หรือคุณเป็นใครมันไม่สำคัญ ;)";
            }
        // log.LogInformation(DateTime.Now.Second.ToString());
        list1 = new List<string>()
        {
            "กิน",
            "หิว",
            "ทาน",
            "แดก",
            "อาหาร"
        };
        list2 = new List<string>()
        {
            "ทานไข่เจียวมั้ยง่าย ๆ",
            "ลองเปิด grab แล้วไล่ดูสิ่ ๆ",
            "มันถึงเวลาแล้วหร๊อ!",
            "ไปซื้อมาทานสิ่ ทำเองต้องล้านจานด้วยนะ",
            "มาม่าม้ะหล่ะ",
            "อิ่มใจก็จะมีความสุขนะ 555555555"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = list2[DateTime.Now.Second % 5];
            }
        }
        list1 = new List<string>()
        {
            "เบ็นซ์",
            "เจ้เบ้น",
            "เจ๊เบ้น",
            "เจ๊เบ็นซ์",
            "เบ้น",
            "benz"
        };
        list2 = new List<string>()
        {
            "เจ๊ใหญ่ของทุกคนไงง",
            "คุณหมอฟัน... ที่ไม่ค่่อยมีแรง",
            "บางทีก็เจ้าระเบียบแบบงง ๆ ม้ะ",
            "อย่าไปแหยมเจ๊นะ เดี๋ยวเจอเจ๊ทวงของคืนนะเอออออ"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = list2[DateTime.Now.Second % 4];
            }
        }
        list1 = new List<string>()
        {
            "เบล",
            "เจ้เบล",
            "เจ๊เบล",
            "เจ๊เบล",
            "bell"
        };
        list2 = new List<string>()
        {
            "พนักงาน STM ไงง",
            "คนอะไร อ้วนเอ๊า อ้วนเอา 555555555555",
            "บางทีก็ใจร้อน... ใจเย็น ๆ ก่อนน้ะจ้ะะ",
            "นางเล่น hay day อยู่รึเปล่าา 555555555"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = list2[DateTime.Now.Second % 4];
            }
        }
        list1 = new List<string>()
        {
            "จิงป่ะ",
            "หรอ",
            "หว่าย",
            "เชื่อ"
        };
        list2 = new List<string>()
        {
            "จริงสิ่จ้ะ",
            "แน่นอนอยู่แล้วววว",
            "ไม่เชื่อกันหรออออ",
            "อย่ามากวนกันน้าาาา"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = list2[DateTime.Now.Second % 4];
            }
        }
        list1 = new List<string>()
        {
            "โบ",
            "bow",
            "beau"
        };
        list2 = new List<string>()
        {
            "ไอ่เอ๋อออ",
            "ขี้เกียจอ่านหนังสืออยู่อ่ะดิ่",
            "ไม่ต้องได้ 4.00 ตลอดก็ได้น้ะไอ่น้อง",
            "เก่งเกินไปอ่ะบางทีคนเรา"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = list2[DateTime.Now.Second % 4];
            }
        }
        list1 = new List<string>()
        {
            "บอล",
            "ball"
        };
        list2 = new List<string>()
        {
            "ถ้าสองทุ่มคริ่งแล้ว ก็คิดว่าน้องคงไม่อยู่ใกล้ ๆ หล่ะสิ่",
            "จิงจิง ตอนเด็ก ๆ มันก็น่ารักดีน้ะ",
            "เด็กอะไรเอ่ย เครียดเก่งงงงง แต่ไม่ค่อยทำอะไรนะ เครียดอย่างเดียว 5555555",
            "ฟึด ๆ หน่อยดิ่ว้ะ ลูกผู้ชายไทยยย!"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = list2[DateTime.Now.Second % 4];
            }
        }
        list1 = new List<string>()
        {
            "บี๋",
            "bee",
            "bee+"
        };
        list2 = new List<string>()
        {
            "ก็บี๋ไง จะใครหล่ะ 5555555555",
            "ถึงคิ้วจะไม่ค่อยมี หน้าผากก้ดันกว้างไปอีกจ่ะะะ CP อาจจะต้องการเรา",
            "เป็นคนนะ ไม่ใช่คอม",
            "คุยรู้เรื่อง 100%"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = list2[DateTime.Now.Second % 4];
            }
        }
        list1 = new List<string>()
        {
            "บาย",
            "bye",
            "บ้าย",
            "ลาก่อน",
            "โชค"
        };
        list2 = new List<string>()
        {
            "จะไปแล้วหรอ เล่นด้วยกันก่อนสิ่",
            "บ้ายบายยย ขอบคุณที่แวะมาคุยกันนะ",
            "เราทำผิดอะไร ทำไมเทเร็วจัง",
            "แล้วมาคุยกันใหม่นะ -3-"
        };
        foreach( var word in list1){
            if(input.Contains(word)){
                output = list2[DateTime.Now.Second % 4];
            }
        }
        /* end handle input */


        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Authorization", "Bearer <token-from-Line-portal");
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
       
        dictionary.Add("type", "text");
        dictionary.Add("text", output);
        // var aa = handleAnswer(data.events[0].message.text);
        // log.LogInformation(dictionary["text"]);
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
        log.LogInformation(result);
    }


    return name != null
        ? (ActionResult)new OkObjectResult($"Hello, {name}")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
    
}


public class ReplyBody
{
    public string replyToken { get; set; }
    public List<Dictionary<string, string>> messages { get; set; }
}
