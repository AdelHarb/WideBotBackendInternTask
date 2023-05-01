namespace WideBot.Models;

public class FacebookGalleryCard
{
    public string title {get; set;}
    public string image_url {get; set;}
    public string subtitle {get; set;}
    public FacebookGalleryAPIDefaultAction action {get; set;}
    public IEnumerable<FacebookGalleryAPIButton> buttons {get; set;}
}