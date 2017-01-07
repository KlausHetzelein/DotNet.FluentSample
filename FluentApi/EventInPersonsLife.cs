using System;

namespace FluentApi
{
    public enum EventInPersonsLife
    {
        Birth,
        Marriage,
        Divorce,
        Widowhood,
        Death,
    }

    internal class EventInPersonsLifeData
    {
        public EventInPersonsLife What { get; set; }

        public DateTime When { get; set; }

        public string AdditionalInfo { get; set; } = String.Empty;
    }
}
