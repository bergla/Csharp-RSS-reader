using System;
using System.Collections.Generic;

namespace Logic.Entities
{

    public abstract class AFeed
    {
        public abstract string Name { set; get; }
    }

    public class Feed : AFeed
    {
        public Guid Id { get; set; }
        public override string Name { get; set; }
        public string feedUrl { get; set; }
        public List<FeedItem> Items { get; set; }
        public string Category { get; set; }
        public int Interval { get; set; }
    }
}