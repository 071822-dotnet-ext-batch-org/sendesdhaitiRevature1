using System;
using MS.ACTIONS;

namespace MS.REPO
{
	public interface Idbcheck
	{
	}

    public class dbcheck
    {
        private readonly IDBCONNECTION connection;
        private readonly Imsactions actions;

        public dbcheck(IDBCONNECTION conn, Imsactions act)
        {
            this.connection = conn;
            this.actions = act;
        }
    }
}

