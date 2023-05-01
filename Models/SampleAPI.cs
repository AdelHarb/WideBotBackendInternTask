namespace WideBot.Models;

public class SampleAPI
{
    public int page {get; set;}
    public int per_page {get; set;}
    public int total {get; set;}
    public int total_pages {get; set;}
    public IEnumerable<Employee> data {get; set;}
}