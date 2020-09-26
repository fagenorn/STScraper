using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace STScraper.Api.Models.Scrapers.JSON
{
    public class InstagramUser
    {
        public class EdgeFollowedBy
        {
            [JsonProperty("count")] public long Count { get; set; }
        }

        public class EdgeFollow
        {
            [JsonProperty("count")] public long Count { get; set; }
        }

        public class EdgeMutualFollowedBy
        {
            [JsonProperty("count")] public int Count { get; set; }

            [JsonProperty("edges")] public List<object> Edges { get; set; }
        }

        public class PageInfo
        {
            [JsonProperty("has_next_page")] public bool HasNextPage { get; set; }

            [JsonProperty("end_cursor")] public object EndCursor { get; set; }
        }

        public class EdgeFelixVideoTimeline
        {
            [JsonProperty("count")] public int Count { get; set; }

            [JsonProperty("page_info")] public PageInfo PageInfo { get; set; }

            [JsonProperty("edges")] public List<object> Edges { get; set; }
        }

        public class PageInfo2
        {
            [JsonProperty("has_next_page")] public bool HasNextPage { get; set; }

            [JsonProperty("end_cursor")] public string EndCursor { get; set; }
        }

        public class Dimensions
        {
            [JsonProperty("height")] public int Height { get; set; }

            [JsonProperty("width")] public int Width { get; set; }
        }

        public class User2
        {
            [JsonProperty("full_name")] public string FullName { get; set; }

            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("is_verified")] public bool IsVerified { get; set; }

            [JsonProperty("profile_pic_url")] public string ProfilePicUrl { get; set; }

            [JsonProperty("username")] public string Username { get; set; }
        }

        public class Node2
        {
            [JsonProperty("user")] public User2 User { get; set; }

            [JsonProperty("x")] public double X { get; set; }

            [JsonProperty("y")] public double Y { get; set; }
        }

        public class Edge2
        {
            [JsonProperty("node")] public Node2 Node { get; set; }
        }

        public class EdgeMediaToTaggedUser
        {
            [JsonProperty("edges")] public List<Edge2> Edges { get; set; }
        }

        public class Owner
        {
            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("username")] public string Username { get; set; }
        }

        public class DashInfo
        {
            [JsonProperty("is_dash_eligible")] public bool IsDashEligible { get; set; }

            [JsonProperty("video_dash_manifest")] public object VideoDashManifest { get; set; }

            [JsonProperty("number_of_qualities")] public int NumberOfQualities { get; set; }
        }

        public class Node3
        {
            [JsonProperty("text")] public string Text { get; set; }
        }

        public class Edge3
        {
            [JsonProperty("node")] public Node3 Node { get; set; }
        }

        public class EdgeMediaToCaption
        {
            [JsonProperty("edges")] public List<Edge3> Edges { get; set; }
        }

        public class EdgeMediaToComment
        {
            [JsonProperty("count")] public int Count { get; set; }
        }

        public class EdgeLikedBy
        {
            [JsonProperty("count")] public int Count { get; set; }
        }

        public class EdgeMediaPreviewLike
        {
            [JsonProperty("count")] public int Count { get; set; }
        }

        public class ThumbnailResource
        {
            [JsonProperty("src")] public string Src { get; set; }

            [JsonProperty("config_width")] public int ConfigWidth { get; set; }

            [JsonProperty("config_height")] public int ConfigHeight { get; set; }
        }

        public class Dimensions2
        {
            [JsonProperty("height")] public int Height { get; set; }

            [JsonProperty("width")] public int Width { get; set; }
        }

        public class EdgeMediaToTaggedUser2
        {
            [JsonProperty("edges")] public List<object> Edges { get; set; }
        }

        public class Owner2
        {
            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("username")] public string Username { get; set; }
        }

        public class Node4
        {
            [JsonProperty("__typename")] public string Typename { get; set; }

            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("shortcode")] public string Shortcode { get; set; }

            [JsonProperty("dimensions")] public Dimensions2 Dimensions { get; set; }

            [JsonProperty("display_url")] public string DisplayUrl { get; set; }

            [JsonProperty("edge_media_to_tagged_user")]
            public EdgeMediaToTaggedUser2 EdgeMediaToTaggedUser { get; set; }

            [JsonProperty("fact_check_overall_rating")]
            public object FactCheckOverallRating { get; set; }

            [JsonProperty("fact_check_information")]
            public object FactCheckInformation { get; set; }

            [JsonProperty("gating_info")] public object GatingInfo { get; set; }

            [JsonProperty("media_overlay_info")] public object MediaOverlayInfo { get; set; }

            [JsonProperty("media_preview")] public string MediaPreview { get; set; }

            [JsonProperty("owner")] public Owner2 Owner { get; set; }

            [JsonProperty("is_video")] public bool IsVideo { get; set; }

            [JsonProperty("accessibility_caption")]
            public string AccessibilityCaption { get; set; }
        }

        public class Edge4
        {
            [JsonProperty("node")] public Node4 Node { get; set; }
        }

        public class EdgeSidecarToChildren
        {
            [JsonProperty("edges")] public List<Edge4> Edges { get; set; }
        }

        public class Node
        {
            [JsonProperty("__typename")] public string Typename { get; set; }

            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("shortcode")] public string Shortcode { get; set; }

            [JsonProperty("dimensions")] public Dimensions Dimensions { get; set; }

            [JsonProperty("display_url")] public string DisplayUrl { get; set; }

            [JsonProperty("edge_media_to_tagged_user")]
            public EdgeMediaToTaggedUser EdgeMediaToTaggedUser { get; set; }

            [JsonProperty("fact_check_overall_rating")]
            public object FactCheckOverallRating { get; set; }

            [JsonProperty("fact_check_information")]
            public object FactCheckInformation { get; set; }

            [JsonProperty("gating_info")] public object GatingInfo { get; set; }

            [JsonProperty("media_overlay_info")] public object MediaOverlayInfo { get; set; }

            [JsonProperty("media_preview")] public string MediaPreview { get; set; }

            [JsonProperty("owner")] public Owner Owner { get; set; }

            [JsonProperty("is_video")] public bool IsVideo { get; set; }

            [JsonProperty("accessibility_caption")]
            public string AccessibilityCaption { get; set; }

            [JsonProperty("dash_info")] public DashInfo DashInfo { get; set; }

            [JsonProperty("has_audio")] public bool HasAudio { get; set; }

            [JsonProperty("tracking_token")] public string TrackingToken { get; set; }

            [JsonProperty("video_url")] public string VideoUrl { get; set; }

            [JsonProperty("video_view_count")] public int VideoViewCount { get; set; }

            [JsonProperty("edge_media_to_caption")]
            public EdgeMediaToCaption EdgeMediaToCaption { get; set; }

            [JsonProperty("edge_media_to_comment")]
            public EdgeMediaToComment EdgeMediaToComment { get; set; }

            [JsonProperty("comments_disabled")] public bool CommentsDisabled { get; set; }

            [JsonProperty("taken_at_timestamp")] public int TakenAtTimestamp { get; set; }

            [JsonProperty("edge_liked_by")] public EdgeLikedBy EdgeLikedBy { get; set; }

            [JsonProperty("edge_media_preview_like")]
            public EdgeMediaPreviewLike EdgeMediaPreviewLike { get; set; }

            [JsonProperty("location")] public object Location { get; set; }

            [JsonProperty("thumbnail_src")] public string ThumbnailSrc { get; set; }

            [JsonProperty("thumbnail_resources")] public List<ThumbnailResource> ThumbnailResources { get; set; }

            [JsonProperty("felix_profile_grid_crop")]
            public object FelixProfileGridCrop { get; set; }

            [JsonProperty("product_type")] public string ProductType { get; set; }

            [JsonProperty("edge_sidecar_to_children")]
            public EdgeSidecarToChildren EdgeSidecarToChildren { get; set; }
        }

        public class Edge
        {
            [JsonProperty("node")] public Node Node { get; set; }
        }

        public class EdgeOwnerToTimelineMedia
        {
            [JsonProperty("count")] public int Count { get; set; }

            [JsonProperty("page_info")] public PageInfo2 PageInfo { get; set; }

            [JsonProperty("edges")] public List<Edge> Edges { get; set; }
        }

        public class PageInfo3
        {
            [JsonProperty("has_next_page")] public bool HasNextPage { get; set; }

            [JsonProperty("end_cursor")] public object EndCursor { get; set; }
        }

        public class EdgeSavedMedia
        {
            [JsonProperty("count")] public int Count { get; set; }

            [JsonProperty("page_info")] public PageInfo3 PageInfo { get; set; }

            [JsonProperty("edges")] public List<object> Edges { get; set; }
        }

        public class PageInfo4
        {
            [JsonProperty("has_next_page")] public bool HasNextPage { get; set; }

            [JsonProperty("end_cursor")] public object EndCursor { get; set; }
        }

        public class EdgeMediaCollections
        {
            [JsonProperty("count")] public int Count { get; set; }

            [JsonProperty("page_info")] public PageInfo4 PageInfo { get; set; }

            [JsonProperty("edges")] public List<object> Edges { get; set; }
        }

        public class EdgeRelatedProfiles
        {
            [JsonProperty("edges")] public List<object> Edges { get; set; }
        }

        public class User
        {
            [JsonProperty("biography")] public string Biography { get; set; }

            [JsonProperty("blocked_by_viewer")] public bool BlockedByViewer { get; set; }

            [JsonProperty("business_email")] public string BusinessEmail { get; set; }

            [JsonProperty("restricted_by_viewer")] public object RestrictedByViewer { get; set; }

            [JsonProperty("country_block")] public bool CountryBlock { get; set; }

            [JsonProperty("external_url")] public Uri ExternalUrl { get; set; }

            [JsonProperty("external_url_linkshimmed")]
            public string ExternalUrlLinkshimmed { get; set; }

            [JsonProperty("edge_followed_by")] public EdgeFollowedBy EdgeFollowedBy { get; set; }

            [JsonProperty("followed_by_viewer")] public bool FollowedByViewer { get; set; }

            [JsonProperty("edge_follow")] public EdgeFollow EdgeFollow { get; set; }

            [JsonProperty("follows_viewer")] public bool FollowsViewer { get; set; }

            [JsonProperty("full_name")] public string FullName { get; set; }

            [JsonProperty("has_ar_effects")] public bool HasArEffects { get; set; }

            [JsonProperty("has_clips")] public bool HasClips { get; set; }

            [JsonProperty("has_guides")] public bool HasGuides { get; set; }

            [JsonProperty("has_channel")] public bool HasChannel { get; set; }

            [JsonProperty("has_blocked_viewer")] public bool HasBlockedViewer { get; set; }

            [JsonProperty("highlight_reel_count")] public int HighlightReelCount { get; set; }

            [JsonProperty("has_requested_viewer")] public bool HasRequestedViewer { get; set; }

            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("is_business_account")] public bool IsBusinessAccount { get; set; }

            [JsonProperty("is_joined_recently")] public bool IsJoinedRecently { get; set; }

            [JsonProperty("business_category_name")]
            public object BusinessCategoryName { get; set; }

            [JsonProperty("overall_category_name")]
            public object OverallCategoryName { get; set; }

            [JsonProperty("category_enum")] public object CategoryEnum { get; set; }

            [JsonProperty("is_private")] public bool IsPrivate { get; set; }

            [JsonProperty("is_verified")] public bool IsVerified { get; set; }

            [JsonProperty("edge_mutual_followed_by")]
            public EdgeMutualFollowedBy EdgeMutualFollowedBy { get; set; }

            [JsonProperty("profile_pic_url")] public string ProfilePicUrl { get; set; }

            [JsonProperty("profile_pic_url_hd")] public Uri ProfilePicUrlHd { get; set; }

            [JsonProperty("requested_by_viewer")] public bool RequestedByViewer { get; set; }

            [JsonProperty("username")] public string Username { get; set; }

            [JsonProperty("connected_fb_page")] public object ConnectedFbPage { get; set; }

            [JsonProperty("edge_felix_video_timeline")]
            public EdgeFelixVideoTimeline EdgeFelixVideoTimeline { get; set; }

            [JsonProperty("edge_owner_to_timeline_media")]
            public EdgeOwnerToTimelineMedia EdgeOwnerToTimelineMedia { get; set; }

            [JsonProperty("edge_saved_media")] public EdgeSavedMedia EdgeSavedMedia { get; set; }

            [JsonProperty("edge_media_collections")]
            public EdgeMediaCollections EdgeMediaCollections { get; set; }

            [JsonProperty("edge_related_profiles")]
            public EdgeRelatedProfiles EdgeRelatedProfiles { get; set; }
        }

        public class Graphql
        {
            [JsonProperty("user")] public User User { get; set; }
        }

        public class Root : IUser
        {
            [JsonProperty("logging_page_id")] public string LoggingPageId { get; set; }

            [JsonProperty("show_suggested_profiles")]
            public bool ShowSuggestedProfiles { get; set; }

            [JsonProperty("show_follow_dialog")] public bool ShowFollowDialog { get; set; }

            [JsonProperty("graphql")] public Graphql Graphql { get; set; }

            [JsonProperty("toast_content_on_load")]
            public object ToastContentOnLoad { get; set; }

            [JsonProperty("show_view_shop")] public bool ShowViewShop { get; set; }

            public string Username => Graphql?.User.Username;

            public string Nickname => Graphql?.User.FullName;

            public string Bio => Graphql?.User.Biography;

            public Uri Website => Graphql?.User.ExternalUrl;

            public string Email => Graphql?.User.BusinessEmail ?? Graphql?.User.Biography?.ExtractEmail();

            public Uri ProfileImage => Graphql?.User.ProfilePicUrlHd;

            public long Followers => Graphql?.User.EdgeFollowedBy.Count ?? 0;

            public long Following => Graphql?.User.EdgeFollow.Count ?? 0;
        }
    }
}