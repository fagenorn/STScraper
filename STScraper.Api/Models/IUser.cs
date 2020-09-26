using System;

namespace STScraper.Api.Models
{
    public interface IUser
    {
        public string Username { get; }

        public string Nickname { get; }

        public string Bio { get; }

        public Uri Website { get; }

        public string Email { get; }

        public Uri ProfileImage { get; }

        public long Followers { get; }

        public long Following { get; }
    }
}