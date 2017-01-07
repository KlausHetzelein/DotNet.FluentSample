using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi
{
    public class Person : IAnyPerson, IAlivePerson, IUnmarriedPerson, IMarriedPerson
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

                return new DateTime(1, 1, 1);
            }
            set
            {
                _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Birth, When = value });
            }
        }

        public static IUnmarriedPerson GetsBorn(string name, DateTime birthDate)
        {
            return new Person { Name = name, Birth = birthDate };
        }

        public IAnyPerson Dies(DateTime when)
        {
            _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Death, When = when });
            return this;
        }

        public IMarriedPerson GetsMarried(string whom, DateTime when)
        {
            _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Marriage, When = when, AdditionalInfo = whom });
            return this;
        }

        public IUnmarriedPerson GetsDivorced(DateTime when)
        {
            _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Divorce, When = when });
            return this;
        }

        public IUnmarriedPerson GetsWidowed(DateTime when)
        {
            _history.Add(new EventInPersonsLifeData { What = EventInPersonsLife.Widowhood, When = when });
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

        public void DisplayState(Action<string> displayFunction)
        {
            displayFunction?.Invoke(GetCurrentState());
        }

        public void DisplayWholeLife(Action<string> displayFunction)
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
        }

        IAnyPerson IAnyPerson.DisplayState(Action<string> displayFunction)
        {
            DisplayState(displayFunction);
            return this;
        }
        IAnyPerson IAnyPerson.DisplayWholeLife(Action<string> displayFunction)
        {
            DisplayWholeLife(displayFunction);
            return this;
        }
        IAlivePerson IAlivePerson.DisplayState(Action<string> displayFunction)
        {
            DisplayState(displayFunction);
            return this;
        }
        IAlivePerson IAlivePerson.DisplayWholeLife(Action<string> displayFunction)
        {
            DisplayWholeLife(displayFunction);
            return this;
        }
        IUnmarriedPerson IUnmarriedPerson.DisplayState(Action<string> displayFunction)
        {
            DisplayState(displayFunction);
            return this;
        }
        IUnmarriedPerson IUnmarriedPerson.DisplayWholeLife(Action<string> displayFunction)
        {
            DisplayWholeLife(displayFunction);
            return this;
        }
        IMarriedPerson IMarriedPerson.DisplayState(Action<string> displayFunction)
        {
            DisplayState(displayFunction);
            return this;
        }
        IMarriedPerson IMarriedPerson.DisplayWholeLife(Action<string> displayFunction)
        {
            DisplayWholeLife(displayFunction);
            return this;
        }
    }
}
