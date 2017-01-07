using System;

namespace FluentApi
{
    public interface IAnyPerson
    {
        IAnyPerson DisplayState(Action<string> displayFunction);
        IAnyPerson DisplayWholeLife(Action<string> displayFunction);
    }

    public interface IAlivePerson : IAnyPerson
    {
        new IAlivePerson DisplayState(Action<string> displayFunction);
        new IAlivePerson DisplayWholeLife(Action<string> displayFunction);
        IAnyPerson Dies(DateTime when);
    }

    public interface IUnmarriedPerson : IAlivePerson
    {
        new IUnmarriedPerson DisplayState(Action<string> displayFunction);
        new IUnmarriedPerson DisplayWholeLife(Action<string> displayFunction);
        IMarriedPerson GetsMarried(string whom, DateTime when);
    }

    public interface IMarriedPerson : IAlivePerson
    {
        new IMarriedPerson DisplayState(Action<string> displayFunction);
        new IMarriedPerson DisplayWholeLife(Action<string> displayFunction);
        IUnmarriedPerson GetsDivorced(DateTime when);
        IUnmarriedPerson GetsWidowed(DateTime when);
    }
}
