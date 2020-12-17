using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextualWebSearchClient.Parameters.Url.Required
{
    public class RequiredParameters : AbstractParameters
    {
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value >= 1 && value <= 50)
                    _pageSize = value;
                else
                    throw new ArgumentOutOfRangeException("PageNumber",
                        new Exception("PageSize must be between 1 and 50"));
            }
        }

        public bool AutoCorrect { get; set; } = true;

    }
}
