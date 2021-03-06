﻿using MediaBrowser.Model.MediaInfo;
using System;
using System.Collections.Generic;

namespace MediaBrowser.Controller.Channels
{
    public class ChannelMediaInfo
    {
        public string Path { get; set; }

        public Dictionary<string, string> RequiredHttpHeaders { get; set; }

        public string Container { get; set; }
        public string AudioCodec { get; set; }
        public string VideoCodec { get; set; }

        public int? AudioBitrate { get; set; }
        public int? VideoBitrate { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? AudioChannels { get; set; }
        public int? AudioSampleRate { get; set; }

        public string VideoProfile { get; set; }
        public float? VideoLevel { get; set; }
        public float? Framerate { get; set; }

        public bool? IsAnamorphic { get; set; }

        public MediaProtocol Protocol { get; set; }

        public long? RunTimeTicks { get; set; }

        public ChannelMediaInfo()
        {
            RequiredHttpHeaders = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // This is most common
            Protocol = MediaProtocol.Http;
        }
    }
}