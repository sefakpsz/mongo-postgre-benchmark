using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContentMongo.API.Entities;

public class Content
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Title { get; set; }
    public byte Status { get; set; } = 1;
    public int? CoverImageId { get; set; }
    public int? DetailImageId { get; set; }
    public string? CoverImage { get; set; }
    public string? DetailImage { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public string? Description { get; set; }
    public int ContentDetailId { get; set; }
    public int UserId { get; set; }
    public string User { get; set; }
    public byte ContentTypeId { get; set; }
    public string ContentType { get; set; }
    public int SeoDetailId { get; set; }
    public string SeoDetail { get; set; }
    public string ContentDetail { get; set; }
    public string? HoroscopeGuide { get; set; }
}