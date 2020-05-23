# line-chatbot-rulebased
Simple rule-based Line chatbot with Line Messaging API and Azure Function.

### Steps
- getting Line ready for development.
1. Create/Enabled Line developer account. Open [Line Developer Console](https://developers.line.biz/), create or use an existing account. Then Enabled open the console.
2. In Line Developer Console, create a Provider.
3. In side a Provider, create a Channel. In the created Channel, we will need to update Messaging API Webhook URL later on.
- getting Azure resources ready for development.
4. Create Azure account. Open [Azure Portal](https://portal.azure.com), create/enabled a free account.
5. Search for `Function App`, create a new function app by `+ Add`.
6. Complete all required fields, <br/>
    Subscription : (goes with the default one, except you have multiple subsciption - select one that will be for this project)<br/>
    Resource group : Create new - `chatbot` or any name you want.<br/>
    Publish : Code, as default.<br/>
    Runtime stack : .NET Core is what we use for this repo.<br/>
    Version : use the generated value.<br/>
    Region : use the generated value.<br/>
  Then `Review + create`
7. After the Function is created. Goes to the resource, then navigate to `Functions` option in the left hand panel.
8. `+ Add` to create a new Function. There will be a New Function section show on the right. Select `HTTP Trigger`. <br/>
      Name the function as wanted. <br/>
      Authorization Level : select `Anonymous`, to allow any caller. <br/>
   Then `Create Function`.
9. The portal will auto direct to the editor screen. Copy + paste the code from [repo](https://github.com/bbeebah/line-chatbot-rulebased/blob/master/run.csx) and don't forget to `Save`.
10. We will need a function URL to update in Line, `Get function URL` and copy the function URL.
- update Line to use our program
10. Goes back to [Line Developer Console](https://developers.line.biz/), in the channel what we've just created. Direct to `Messaging API` tabs, Webhook URL section. Edit/Update URL to be Azure function URL.
11. Enable `Use Webhook`. if it's still disabled.

Test Time!!! 
