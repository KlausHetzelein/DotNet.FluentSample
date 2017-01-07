using System;

namespace FluentApi
{
    public interface IAnyPerson
    {
        void DisplayState(Action<string> displayFunction);
        void DisplayWholeLife(Action<string> displayFunction);
    }

    public interface IAlivePerson : IAnyPerson
    {
        IAnyPerson Dies(DateTime when);
    }

    public interface IUnmarriedPerson : IAlivePerson
    {
        IMarriedPerson GetsMarried(string whom, DateTime when);
    }

    public interface IMarriedPerson : IAlivePerson
    {
        IUnmarriedPerson GetsDivorced(DateTime when);
        IUnmarriedPerson GetsWidowed(DateTime when);
    }
}
