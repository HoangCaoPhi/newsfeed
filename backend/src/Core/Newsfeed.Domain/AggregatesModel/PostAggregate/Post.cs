using Newsfeed.Domain.AggregatesModel.CategoryAggregate;
using Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class Post : BaseEntity, IAggregateRoot
{
    public string? Title { get; private set; }

    [Required]
    public string Content { get; private set; }

    public PostType PostType { get; private set; }

    public string? ThumbnailId { get; private set; }

    public DisplayMode DisplayMode { get; private set; }

    [Required]
    public Author Author { get; private set; }

    private readonly List<PostAttachment>? _postAttachments;

    public IReadOnlyCollection<PostAttachment> PostAttachments => _postAttachments?.AsReadOnly();

    private readonly List<PostHashTag>? _postHashTags;

    public IReadOnlyCollection<PostHashTag> PostHashTags => _postHashTags?.AsReadOnly();

    private readonly List<PostCategory>? _postCategories;

    public IReadOnlyCollection<PostCategory> PostCategories => _postCategories?.AsReadOnly();

    private Post()
    {
        _postAttachments = [];
        _postHashTags = [];
        _postCategories = [];
    }

    public static Post CreatePost(string title,
                             string postType,
                             string thumbnailId,
                             string displayMode,
                             string content)
    {
        return new Post()
        {
            Title = title,
            PostType = Enumeration.FromDisplayName<PostType>(postType),
            ThumbnailId = thumbnailId,
            DisplayMode = Enumeration.FromDisplayName<DisplayMode>(displayMode),
            Author = Author.CreateAuthor("cde922a2-10cb-4149-ad0e-775a98663c2d", "Hoàng Cao Phi"),
            Content = content
        };
    }

    public void AddPostHashTags(IReadOnlyList<PostHashTag> hashTags)
    {
        _postHashTags.AddRange(hashTags);
    }

    public void AddPostAttachments(IReadOnlyList<PostAttachment> postAttachments)
    {
        _postAttachments.AddRange(postAttachments);
    }

    public void AddPostCategories(IReadOnlyList<PostCategory> postCategories)
    {
        _postCategories.AddRange(postCategories);
    }
}
