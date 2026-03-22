using Puls.Sample.Domain.Commons;
using Puls.Sample.TestHelpers.Domain;
using System;

namespace Puls.Sample.TestHelpers.Domain
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class TenantIdBuilder
    {
        private Guid _value = Guid.NewGuid();
        private bool _valueIsSet = false;

        public TenantId Build()
        {
            return new TenantId(
                _value);
        }

        public TenantIdBuilder SetValue(Guid value)
        {
            if (_valueIsSet)
            {
                throw new System.InvalidOperationException(nameof(_value) + " already initialized");
            }
            _valueIsSet = true;
            _value = value;
            return this;
        }
    }
}
