using Newsfeed.Domain.AggregatesModel.CategoryAggregate;
using Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;
using System.ComponentModel.DataAnnotations;

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class Post : BaseEntity, IAggregateRoot
{
    public string? Title { get; private set; }

    [Required]
    public string Content { get; private set; }

    private int _postType;
    public PostType PostType { get; private set; }

    public string? ThumbnailId { get; private set; }

    [Required]
    public Author Author { get; private set; }

    private readonly List<PostAttachment>? _postAttachments;

    public IReadOnlyCollection<PostAttachment> PostAttachments => _postAttachments?.AsReadOnly();

    public DisplayMode DisplayMode { get; private set; }

    private readonly List<HashTag> _hashTags;

    public IReadOnlyCollection<HashTag> HashTags => _hashTags?.AsReadOnly();

    private readonly List<Category>? _categories;

    public IReadOnlyCollection<Category> Categories => _categories?.AsReadOnly();
}
