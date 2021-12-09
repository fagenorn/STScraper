using System;
using System.Collections.Generic;
using System.Linq;

namespace STScraper.Api.Models.Filters
{
    public class FilterCollection<T> : IFilterType<T>
    {
        private readonly List<IFilterType<T>> _filters = new List<IFilterType<T>>();

        internal FilterCollection() { }

        public bool IsFiltered(T obj) { return _filters.Any(x => x.IsFiltered(obj)); }

        internal void AddFilter(IFilterType<T> filter) { _filters.Add(filter); }
    }

    internal class FollowersFilter : IFilterType<IUser>
    {
        private readonly long _maxFollowers;

        private readonly long _minFollowers;

        public FollowersFilter(long minFollowers, long maxFollowers)
        {
            _minFollowers = minFollowers;
            _maxFollowers = maxFollowers;
        }

        public bool IsFiltered(IUser obj) { return obj.Followers < _minFollowers || obj.Followers > _maxFollowers; }
    }

    internal class FollowingsFilter : IFilterType<IUser>
    {
        private readonly long _maxFollowings;

        private readonly long _minFollowings;

        public FollowingsFilter(long minFollowings, long maxFollowings)
        {
            _minFollowings = minFollowings;
            _maxFollowings = maxFollowings;
        }

        public bool IsFiltered(IUser obj) { return obj.Following < _minFollowings || obj.Following > _maxFollowings; }
    }

    internal class BioWhitelistFilter : IFilterType<IUser>
    {
        private readonly string[] _whitelist;

        public BioWhitelistFilter(params string[] whitelist) { _whitelist = whitelist; }

        public bool IsFiltered(IUser obj) { return !_whitelist.Any(x => obj.Bio.Contains(x, StringComparison.InvariantCultureIgnoreCase)); }
    }

    internal class BioBlacklistFilter : IFilterType<IUser>
    {
        private readonly string[] _blacklist;

        public BioBlacklistFilter(params string[] blacklist) { _blacklist = blacklist; }

        public bool IsFiltered(IUser obj) { return _blacklist.Any(x => obj.Bio.Contains(x, StringComparison.InvariantCultureIgnoreCase)); }
    }
}