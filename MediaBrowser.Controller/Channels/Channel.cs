﻿using MediaBrowser.Controller.Entities;
using System;
using System.Linq;

namespace MediaBrowser.Controller.Channels
{
    public class Channel : Folder
    {
        public string OriginalChannelName { get; set; }

        public override bool IsVisible(User user)
        {
            if (user.Configuration.BlockedChannels.Contains(Id.ToString("N"), StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }
            
            return base.IsVisible(user);
        }
    }
}
