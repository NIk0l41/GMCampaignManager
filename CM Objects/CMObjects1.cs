using System;
using System.Collections.Generic;

namespace GMCM {

    public abstract class CMObject {
        public string name;
        public List<string> tags;
        public List<CMNote> notes;
    }

    public class CMLocation : CMObject {
        public List<CMLocation> childLocations;
    }

    public class CMNPC : CMObject {
        public int[6] stats;
        public List<CMItem> inventory;
        public CMLocation location;
    }

    public class CMEvent : CMObject {
        
    }

    public class CMItem : CMObject {
        public CMLocation location;
        public List<CMItem> contains;

    }

    public class CMCatalogue {
        public List<CMItem> items;
        public List<int> price;
    }

    public class CMNote {
        
    }

}
