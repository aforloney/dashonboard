using ParseDiff;
using System.Collections.Generic;
using System.Linq;

namespace Dashonboard.Services.Extenstions
{
    public static class LineDiffExtenstions
    {
        public static IEnumerable<LineDiff> GetAdds(this IEnumerable<LineDiff> lineDiffs)
        {
            return lineDiffs.Where(chg => chg.Add == true);
        }

        public static IEnumerable<LineDiff> GetDeletes(this IEnumerable<LineDiff> lineDiffs)
        {
            return lineDiffs.Where(chg => chg.Delete == true);
        }
    }
}
