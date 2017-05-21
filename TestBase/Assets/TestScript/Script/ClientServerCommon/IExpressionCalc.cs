namespace ClientServerCommon
{
    using System;

    public interface IExpressionCalc
    {
        double CalcExpression(string exp, params IExpressionObject[] objs);
    }
}

