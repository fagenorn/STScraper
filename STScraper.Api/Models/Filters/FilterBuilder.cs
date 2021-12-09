namespace STScraper.Api.Models.Filters
{
    public class FilterBuilder
    {
        private BioBlacklistFilter _bioBlacklistFilter;

        private BioWhitelistFilter _bioWhitelistFilter;

        private FollowersFilter _followersFilter;

        private FollowingsFilter _followingsFilter;

        public FilterBuilder SetFollowersFilter(long minFollowers, long maxFollowers)
        {
            _followersFilter = new FollowersFilter(minFollowers, maxFollowers);

            return this;
        }

        public FilterBuilder SetFollowingsFilter(long minFollowings, long maxFollowings)
        {
            _followingsFilter = new FollowingsFilter(minFollowings, maxFollowings);

            return this;
        }

        public FilterBuilder SetBioWhitelistFilter(params string[] bioWhitelist)
        {
            _bioWhitelistFilter = new BioWhitelistFilter(bioWhitelist);

            return this;
        }

        public FilterBuilder SetBioBlacklistFilter(params string[] bioBlacklist)
        {
            _bioBlacklistFilter = new BioBlacklistFilter(bioBlacklist);

            return this;
        }

        public FilterCollection<IUser> Build()
        {
            var filter = new FilterCollection<IUser>();

            if ( _followersFilter != null )
            {
                filter.AddFilter(_followersFilter);
            }

            if ( _followingsFilter != null )
            {
                filter.AddFilter(_followingsFilter);
            }

            if ( _bioWhitelistFilter != null )
            {
                filter.AddFilter(_bioWhitelistFilter);
            }

            if ( _bioBlacklistFilter != null )
            {
                filter.AddFilter(_bioBlacklistFilter);
            }

            return filter;
        }
    }
}