namespace FluentApi
{
    public static class EventInPersonsLifeExtensions
    {
        public static string EventAsVerb(this EventInPersonsLife @event)
        {
            switch (@event)
            {
                case EventInPersonsLife.NotYetBorn:
                    return "not yet born";
                case EventInPersonsLife.Birth:
                    return "born";
                case EventInPersonsLife.Marriage:
                    return "married";
                case EventInPersonsLife.Divorce:
                    return "divorced";
                case EventInPersonsLife.Widowhood:
                    return "widowed";
                case EventInPersonsLife.Death:
                    return "died";
                default:
                    return "<unknown?>";
            }
        }
        public static string EventAsState(this EventInPersonsLife @event)
        {
            switch (@event)
            {
                case EventInPersonsLife.NotYetBorn:
                    return "unborn";
                case EventInPersonsLife.Birth:
                    return "single";
                case EventInPersonsLife.Marriage:
                    return "married";
                case EventInPersonsLife.Divorce:
                    return "divorced";
                case EventInPersonsLife.Widowhood:
                    return "widowed";
                case EventInPersonsLife.Death:
                    return "dead";
                default:
                    return "<unknown?>";
            }
        }
    }
}
