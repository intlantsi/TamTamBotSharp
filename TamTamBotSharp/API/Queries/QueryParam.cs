using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Queries
{
    public class QueryParam<T>: QueryParam
    {
        #region Fields
        private T value;
        #endregion

        #region Constructors
        public QueryParam(string name, TamTamQuery holder):base(name)
        {
            value = default(T);
            holder.AddParam(this);
        }
        #endregion

        #region Properties
        public T Value { get; set; }
        public override object QueryParamValue 
        { 
            get
            {
                if (Value.ToString()=="" || Value.ToString() == "0")
                {
                    return null;
                }
                return Value;
            }
        }
        #endregion

        #region Methods
        public string Format()
        {
            return value.ToString();
        }
        #endregion
    }

    public class QueryParam
    {
        #region Fields
        private readonly string name;
        private bool isRequired;
        #endregion

        public QueryParam(string name)
        {
            this.name = name;
        }

        #region Properties
        public string Name { get => name; }
        public virtual object QueryParamValue { get;}
        public bool Required 
        { 
            get => isRequired;
            set => isRequired = value;
        }
        #endregion
    }
}
