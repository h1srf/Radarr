using System.Collections.Generic;
using NLog;
using NzbDrone.Common.Http;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.Parser;
using NzbDrone.Core.Parser.Model;

namespace NzbDrone.Core.Indexers.Easynews
{
    public class Easynews : HttpIndexerBase<EasynewsSettings>
    {
        public Easynews(IHttpClient httpClient, IIndexerStatusService indexerStatusService, IConfigService configService, IParsingService parsingService, Logger logger)
            : base(httpClient, indexerStatusService, configService, parsingService, logger)
        {
        }

        public override bool SupportsRss
        {
            get
            {
                return false;
            }
        }

        public override string Name
        {
            get
            {
                return "easynews";
            }
        }

        public override DownloadProtocol Protocol
        {
            get
            {
                return DownloadProtocol.File;
            }
        }

        public override IIndexerRequestGenerator GetRequestGenerator()
        {
            return new EasynewsRequestGenerator() { Settings = Settings };
        }

        public override IParseIndexerResponse GetParser()
        {
            return new EasynewsRssParser();
        }

        public override int PageSize
        {
            get
            {
                return 10;
            }
        }

        protected override bool IsFullPage(IList<ReleaseInfo> page)
        {
            return true;
        }
    }
}
