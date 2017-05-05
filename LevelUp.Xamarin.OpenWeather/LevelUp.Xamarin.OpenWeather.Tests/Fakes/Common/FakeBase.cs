using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LevelUp.Xamarin.OpenWeather.Tests
{
	public class FakeBase
	{
		private readonly IDictionary<string, int> _memberCount;

		public FakeBase()
		{
			_memberCount = new Dictionary<string, int>();
		}

        protected void RecordOccurrence([CallerMemberName] string memberName = null)
        {
	        RecordOccurrence(memberName, new string[0]);
	    }

        protected void RecordOccurrence([CallerMemberName] string memberName = null, params object[] args)
		{
			int count;
		    var value = memberName + args.Aggregate(string.Empty, (x, y) => x + (y == null ? "" : ":" + y.ToString()));
			if (_memberCount.TryGetValue(value, out count))
			{
				count++;
				_memberCount[value] = count;
			}
			else
			{
				_memberCount.Add(value, 1);
			}
		}

		public bool HasOccurred(string memberName, int count)
		{
			return _memberCount.ContainsKey(memberName) && _memberCount[memberName] == count;
		}

	    public bool HasOccurredOnce(string memberName)
	    {
	        return HasOccurredOnly(memberName, 1);
	    }

        public bool HasNeverOccurred(string memberName)
        {
            return HasOccurredOnly(memberName, 0);
        }

		public bool HasOccurredOnly(string memberName, int count)
		{
			return Occurred(memberName) == count;
		}

        public int Occurred(string memberName)
        {
            return _memberCount.ContainsKey(memberName)
                ? _memberCount[memberName]
                : 0;
        }   
    }
}


