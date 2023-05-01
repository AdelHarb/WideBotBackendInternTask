using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WideBot.Models;

namespace SimpleRESTAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WideBotController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Integrate(int id)
    {
        var sampleAPI = "https://reqres.in/api/users";
        var httpClient = new HttpClient();

        var response =await httpClient.GetAsync(sampleAPI);

        if(response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            SampleAPI api = JsonConvert.DeserializeObject<SampleAPI>(json);
            var emp = api.data.FirstOrDefault(a => a.Id == id);
            FacebookGalleryCard apiToBeSent = new FacebookGalleryCard
            {
                title = emp.first_name,
                image_url = emp.avatar,
                subtitle = emp.last_name,
                action = new FacebookGalleryAPIDefaultAction
                {
                    type = "web_url",
                    url= $"https://mail.google.com/mail/u/0/?fs=1&tf=cm&to={emp.Email}&su=Hello&body=Send%20Email",
                    webview_height_ratio = "tall"
                },
                buttons = new FacebookGalleryAPIButton []
                {
                    new FacebookGalleryAPIButton
                    {
                        type = "web_url",
                        url= $"https://mail.google.com/mail/u/0/?fs=1&tf=cm&to={emp.Email}&su=Hello&body=Send%20Email",
                        title = "Send Email"
                    }
                }
                
            };
            return Ok(apiToBeSent);
        }
        return BadRequest("Error");
    }
}
