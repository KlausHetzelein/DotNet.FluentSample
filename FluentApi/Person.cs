using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi
{
    public class Person
    {
        List<EventInPersonsLifeData> _history = new List<EventInPersonsLifeData>();

        public string Name { get; set; }

        public DateTime Birth
        {
            get
            {
                if (_history.Count > 0)
                {
                    return _history[0].When;
                }

                return new DateTime(1900, 1, 1);
            }
            set
            {
                _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Birth, When = value });
            }
        }

        public static Person GetsBorn(string name, DateTime birthDate)
        {
            return new Person { Name = name, Birth = birthDate };
        }

        public Person Dies(DateTime when)
        {
            _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Death, When = when });
            return this;
        }

        public Person GetsMarried(string whom, DateTime when)
        {
            _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Marriage, When = when, AdditionalInfo = whom });
            return this;
        }

        public Person GetsDivorced(DateTime when)
        {
            _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Divorce, When = when });
            return this;
        }

        public Person GetsWidowed(DateTime when)
        {
            _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Widowhood, When = when });
            return this;
        }

        public Person DisplayState(Action<string> displayFunction)
        {
            displayFunction?.Invoke(GetCurrentState());
            return this;
        }

        public string GetCurrentState()
        {
            if (_history.Count > 0)
            {
                var currentState = _history[_history.Count - 1].What;
                return $"{Name} is {currentState.EventAsState()}";
            }

            return String.Empty;
        }

        public Person DisplayWholeLife(Action<string> displayFunction)
        {
            if (null != displayFunction)
            {
                StringBuilder historyTexts = new StringBuilder();
                historyTexts.Append($"{Name}'s life: {Environment.NewLine}");
                foreach (var @event in _history)
                {
                    var when = @event.When;
                    var what = @event.What;

                    if (what == EventInPersonsLife.Marriage)
                    {
                        var marriedWhom = @event.AdditionalInfo;
                        historyTexts.Append($"{what.EventAsVerb()} {marriedWhom} {when.Day}.{when.Month}.{when.Year}{Environment.NewLine}");
                    }
                    else
                    {
                        historyTexts.Append($"{what.EventAsVerb()} {when.Day}.{when.Month}.{when.Year}{Environment.NewLine}");
                    }
                }

                historyTexts.Append(GetCurrentState());
                displayFunction(historyTexts.ToString());
            }

            return this;
        }
    }
}
