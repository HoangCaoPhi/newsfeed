using Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;
using System.ComponentModel.DataAnnotations;

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class Post : BaseEntity, IAggregateRoot, IRecordHistory
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

    public DateTime? Created { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public string ModifiedBy { get; set; }
    public Guid EditVersion { get; set; }

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
                             string content,
                             List<PostHashTag> postHashTags,
                             List<PostAttachment> postAttachments,
                             List<PostCategory> postCategories)
    {
        var post = new Post()
        {
            Title = title,
            PostType = Enumeration.FromDisplayName<PostType>(postType),
            ThumbnailId = thumbnailId,
            DisplayMode = Enumeration.FromDisplayName<DisplayMode>(displayMode),
            Author = Author.CreateAuthor("cde922a2-10cb-4149-ad0e-775a98663c2d", "Hoàng Cao Phi"),
            Content = content
        };

        post.AddPostHashTags(postHashTags);
        post.AddPostCategories(postCategories);
        post.AddPostAttachments(postAttachments);

        return post;
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

    public void UpdatePost(string title,
                             string thumbnailId,
                             string displayMode,
                             string content,
                             List<PostHashTag> postHashTags,
                             List<PostAttachment> postAttachments,
                             List<PostCategory> postCategories)
    {
        Title = title;
        ThumbnailId = thumbnailId;
        DisplayMode = Enumeration.FromDisplayName<DisplayMode>(displayMode);
        Content = content;

        _postHashTags.Clear();
        _postHashTags.AddRange(postHashTags);

        _postAttachments.Clear();
        _postAttachments.AddRange(postAttachments);

        _postCategories.Clear();
        _postCategories.AddRange(postCategories);
    }
}
