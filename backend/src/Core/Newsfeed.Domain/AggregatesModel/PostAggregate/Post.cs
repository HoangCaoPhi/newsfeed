﻿using System.ComponentModel.DataAnnotations;
using Newsfeed.Domain.AggregatesModel.CategoryAggregate;

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class Post : BaseEntity, IAggregateRoot
{
    public string? Title { get; private set; }

    [Required]
    public string Content { get; private set; }

    public string PostType { get; private set; }

    public string? ThumbnailId { get; private set; }

    [Required]
    public Author Author { get; private set; }

    public int? CategoryID { get; private set; }

    public string? CategoryName { get; private set; }

    private readonly List<PostAttachment>? _postAttachments;

    public IReadOnlyCollection<PostAttachment> PostAttachments => _postAttachments?.AsReadOnly();

    public PostStatus PostStatus { get; private set; }

    private readonly List<HashTag> _hashTags;

    public IReadOnlyCollection<HashTag> HashTags => _hashTags?.AsReadOnly();

    private readonly List<int>? _categoryIds;

    public IReadOnlyCollection<int> CategoryIds => _categoryIds?.AsReadOnly();
}
