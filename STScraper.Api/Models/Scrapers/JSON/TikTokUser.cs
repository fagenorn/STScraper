using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace STScraper.Api.Models.Scrapers.JSON
{
    public class TikTokUser
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class PageState
        {
            [JsonProperty("regionAppId")] public int RegionAppId { get; set; }

            [JsonProperty("os")] public string Os { get; set; }

            [JsonProperty("region")] public string Region { get; set; }

            [JsonProperty("baseURL")] public string BaseURL { get; set; }

            [JsonProperty("appType")] public string AppType { get; set; }

            [JsonProperty("fullUrl")] public string FullUrl { get; set; }
        }

        public class UserData
        {
            [JsonProperty("secUid")] public string SecUid { get; set; }

            [JsonProperty("userId")] public string UserId { get; set; }

            [JsonProperty("isSecret")] public bool IsSecret { get; set; }

            [JsonProperty("uniqueId")] public string UniqueId { get; set; }

            [JsonProperty("nickName")] public string NickName { get; set; }

            [JsonProperty("signature")] public string Signature { get; set; }

            [JsonProperty("covers")] public List<string> Covers { get; set; }

            [JsonProperty("coversMedium")] public List<string> CoversMedium { get; set; }

            [JsonProperty("following")] public long Following { get; set; }

            [JsonProperty("fans")] public long Fans { get; set; }

            [JsonProperty("heart")] public string Heart { get; set; }

            [JsonProperty("video")] public int Video { get; set; }

            [JsonProperty("verified")] public bool Verified { get; set; }

            [JsonProperty("digg")] public int Digg { get; set; }

            [JsonProperty("ftc")] public bool Ftc { get; set; }

            [JsonProperty("relation")] public int Relation { get; set; }

            [JsonProperty("openFavorite")] public bool OpenFavorite { get; set; }
        }

        public class ShareUser
        {
            [JsonProperty("secUid")] public string SecUid { get; set; }

            [JsonProperty("userId")] public string UserId { get; set; }

            [JsonProperty("uniqueId")] public string UniqueId { get; set; }

            [JsonProperty("nickName")] public string NickName { get; set; }

            [JsonProperty("signature")] public string Signature { get; set; }

            [JsonProperty("covers")] public List<object> Covers { get; set; }

            [JsonProperty("coversMedium")] public List<object> CoversMedium { get; set; }

            [JsonProperty("coversLarger")] public List<object> CoversLarger { get; set; }

            [JsonProperty("isSecret")] public bool IsSecret { get; set; }

            [JsonProperty("secret")] public bool Secret { get; set; }

            [JsonProperty("relation")] public int Relation { get; set; }
        }

        public class ShareMeta
        {
            [JsonProperty("title")] public string Title { get; set; }

            [JsonProperty("desc")] public string Desc { get; set; }
        }

        public class Child
        {
            [JsonProperty("value")] public string Value { get; set; }

            [JsonProperty("label")] public string Label { get; set; }
        }

        public class LangList
        {
            [JsonProperty("value")] public string Value { get; set; }

            [JsonProperty("alias")] public string Alias { get; set; }

            [JsonProperty("label")] public string Label { get; set; }

            [JsonProperty("children")] public List<Child> Children { get; set; }
        }

        public class MetaParams
        {
            [JsonProperty("title")] public string Title { get; set; }

            [JsonProperty("keywords")] public string Keywords { get; set; }

            [JsonProperty("description")] public string Description { get; set; }

            [JsonProperty("canonicalHref")] public string CanonicalHref { get; set; }

            [JsonProperty("robotsContent")] public string RobotsContent { get; set; }

            [JsonProperty("applicableDevice")] public string ApplicableDevice { get; set; }
        }

        public class DescVideo { }

        public class Body
        {
            [JsonProperty("pageState")] public PageState PageState { get; set; }

            [JsonProperty("userData")] public UserData UserData { get; set; }

            [JsonProperty("shareUser")] public ShareUser ShareUser { get; set; }

            [JsonProperty("shareMeta")] public ShareMeta ShareMeta { get; set; }

            [JsonProperty("statusCode")] public int StatusCode { get; set; }

            [JsonProperty("langList")] public List<LangList> LangList { get; set; }

            [JsonProperty("metaParams")] public MetaParams MetaParams { get; set; }

            [JsonProperty("itemList")] public List<object> ItemList { get; set; }

            [JsonProperty("descVideo")] public DescVideo DescVideo { get; set; }
        }

        public class Root : IUser
        {
            [JsonProperty("body")] public Body Body { get; set; }

            [JsonProperty("statusCode")] public int StatusCode { get; set; }

            [JsonProperty("errMsg")] public object ErrMsg { get; set; }

            public string Username => Body?.UserData?.UniqueId;

            public string Nickname => Body?.UserData?.NickName;

            public string Bio => Body?.UserData?.Signature;

            public Uri Website => null;

            public string Email => Body?.UserData?.Signature?.ExtractEmail();

            public Uri ProfileImage => Body?.UserData?.CoversMedium?[0] != null ? new Uri(Body?.UserData?.CoversMedium[0]) : null;

            public long Followers => Body?.UserData?.Fans ?? 0;

            public long Following => Body?.UserData?.Following ?? 0;
        }
    }
}