namespace Discount.API.Entities;

public class Content
{
    public int id { get; set; }
    public string title { get; set; }
    public byte status { get; set; } = 1;
    public int? coverimageid { get; set; }
    public int? detailimageid { get; set; }
    public string? coverimage { get; set; }
    public string? detailimage { get; set; }
    public int createdby { get; set; }
    public int? updatedby { get; set; }
    public string? description { get; set; }
    public int contentdetailid { get; set; }
    public int userid { get; set; }
    public string username { get; set; }
    public byte contenttypeid { get; set; }
    public string contenttype { get; set; }
    public int seodetailid { get; set; }
    public string seodetail { get; set; }
    public string contentdetail { get; set; }
    public string? horoscopeguide { get; set; }
}