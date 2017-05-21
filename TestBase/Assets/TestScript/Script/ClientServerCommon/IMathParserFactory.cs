namespace ClientServerCommon
{
    using System;

    public interface IMathParserFactory
    {
        IMathParser CreateMathParser(string expression);
    }
}

