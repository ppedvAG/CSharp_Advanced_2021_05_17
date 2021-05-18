using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using Bond;
using Microsoft.CodeAnalysis;


[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
//[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace Microsoft.CodeAnalysis
{
    [CompilerGenerated]
    [Embedded]
    internal sealed class EmbeddedAttribute : Attribute
    {
    }
}


namespace System.Runtime.CompilerServices
{
    [CompilerGenerated]
    [Microsoft.CodeAnalysis.Embedded]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
    internal sealed class NullableAttribute : Attribute
    {
        public readonly byte[] NullableFlags;

        public NullableAttribute(byte P_0)
        {
            byte[] array = new byte[1];
            array[0] = P_0;
            NullableFlags = array;
        }

        public NullableAttribute(byte[] P_0)
        {
            NullableFlags = P_0;
        }
    }
    [CompilerGenerated]
    [Microsoft.CodeAnalysis.Embedded]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
    internal sealed class NullableContextAttribute : Attribute
    {
        public readonly byte Flag;

        public NullableContextAttribute(byte P_0)
        {
            Flag = P_0;
        }
    }





    internal class Person : IEquatable<Person>
    {
        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly int _id;

        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _firstname;

        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _lastname;



        public void Deconstruct(out int id, out string Firstname, out string Lastname)
        {
            id = this._id;
            Firstname = this.Firstname;
            Lastname = this.Lastname;
        }

        [System.Runtime.CompilerServices.Nullable(1)]
        protected virtual Type EqualityContract
        {
            [System.Runtime.CompilerServices.NullableContext(1)]
            [CompilerGenerated]
            get
            {
                return typeof(Person);
            }
        }

        public int id
        {
            [CompilerGenerated]
            get
            {
                return _id;
            }
            [CompilerGenerated]
            init
            {
                _id = value;
            }
        }

        public string Firstname
        {
            [CompilerGenerated]
            get
            {
                return _firstname;
            }
            [CompilerGenerated]
            init
            {
                _firstname = value;
            }
        }

        public string Lastname
        {
            [CompilerGenerated]
            get
            {
                return _lastname;
            }
            [CompilerGenerated]
            init
            {
                _lastname = value;
            }
        }

        public Person(int id, string Firstname, string Lastname)
            : base()
        {
            _id = id;
            _firstname = Firstname;
            _lastname = Lastname;
            
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Person");
            stringBuilder.Append(" { ");
            if (PrintMembers(stringBuilder))
            {
                stringBuilder.Append(" ");
            }
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        [System.Runtime.CompilerServices.NullableContext(1)]
        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append("id");
            builder.Append(" = ");
            builder.Append(id.ToString());
            builder.Append(", ");
            builder.Append("Firstname");
            builder.Append(" = ");
            builder.Append((object)Firstname);
            builder.Append(", ");
            builder.Append("Lastname");
            builder.Append(" = ");
            builder.Append((object)Lastname);
            return true;
        }

        [System.Runtime.CompilerServices.NullableContext(2)]
        public static bool operator !=(Person r1, Person r2)
        {
            return !(r1 == r2);
        }

        [System.Runtime.CompilerServices.NullableContext(2)]
        public static bool operator ==(Person r1, Person r2)
        {
            return (object)r1 == r2 || ((object)r1 != null && r1.Equals(r2));
        }

        public override int GetHashCode()
        {
            return ((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(< id > k__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(< Firstname > k__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(< Lastname > k__BackingField);
        }

        [System.Runtime.CompilerServices.NullableContext(2)]
        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        [System.Runtime.CompilerServices.NullableContext(2)]
        public virtual bool Equals(Person other)
        {
            return (object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(< id > k__BackingField, other.< id > k__BackingField) && EqualityComparer<string>.Default.Equals(< Firstname > k__BackingField, other.< Firstname > k__BackingField) && EqualityComparer<string>.Default.Equals(< Lastname > k__BackingField, other.< Lastname > k__BackingField);
        }

        [System.Runtime.CompilerServices.NullableContext(1)]
        public virtual Person<Clone>$()
        {
            return new Person(this);
        }


        

    }
}





namespace RecordInDll
{
    class SubClass
    {
    }
}
