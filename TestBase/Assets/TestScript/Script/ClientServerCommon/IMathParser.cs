namespace ClientServerCommon
{
    using System;

    public interface IMathParser
    {
        double Evaluate();
        string GetExpression();
        void RemoveAllVariables();
        void SetExpression(string expression);
        void SetVariable(string name, float value);
    }
}

