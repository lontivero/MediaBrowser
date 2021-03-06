﻿using MediaBrowser.Common.Net;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Providers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediaBrowser.Providers.Movies
{
    public class MovieDbTrailerProvider : IRemoteMetadataProvider<Trailer, TrailerInfo>, IHasOrder
    {
        private readonly IHttpClient _httpClient;

        public MovieDbTrailerProvider(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<MetadataResult<Trailer>> GetMetadata(TrailerInfo info, CancellationToken cancellationToken)
        {
            return MovieDbProvider.Current.GetItemMetadata<Trailer>(info, cancellationToken);
        }

        public Task<IEnumerable<RemoteSearchResult>> GetSearchResults(TrailerInfo searchInfo, CancellationToken cancellationToken)
        {
            return MovieDbProvider.Current.GetMovieSearchResults(searchInfo, cancellationToken);
        }

        public string Name
        {
            get { return MovieDbProvider.Current.Name; }
        }

        public bool HasChanged(IHasMetadata item, DateTime date)
        {
            return MovieDbProvider.Current.HasChanged(item, date);
        }

        public int Order
        {
            get
            {
                // After Omdb
                return 1;
            }
        }

        public Task<HttpResponseInfo> GetImageResponse(string url, CancellationToken cancellationToken)
        {
            return _httpClient.GetResponse(new HttpRequestOptions
            {
                CancellationToken = cancellationToken,
                Url = url,
                ResourcePool = MovieDbProvider.Current.MovieDbResourcePool
            });
        }
    }
}
