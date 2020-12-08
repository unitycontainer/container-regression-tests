using System;

namespace Selection.Implicit
{
    public abstract partial class OldPattern : SelectionBase
    {

        private static object[] TestRecord(string name, Type contract, object instance, Type dependency, Type import, int index)
        {
            var member = Member.Substring(0, Member.Length - 1);
            var example = $"\n\nExpected: {index}\nRegisterInstance({contract.Name}, '{instance}');\nclass BaselineTestType\n{{\n    {member}();\n    {member}({dependency.Name} value);\n    {member}({import.Name} value);\n    {member}({dependency.Name} item1, {import.Name} item2);\n";

            return new object[] { name, contract, instance, dependency, import, index, example };
        }
    }
}
