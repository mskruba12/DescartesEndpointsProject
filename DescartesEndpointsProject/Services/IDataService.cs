using DescartesEndpointsProject.Classes;

namespace DescartesEndpointsProject.Services
{
    public class DataService : IDataService
    {
        private Dictionary<int, ReceivedData> leftDataDictionary = new Dictionary<int, ReceivedData>();
        private Dictionary<int, ReceivedData> rightDataDictionary = new Dictionary<int, ReceivedData>();

        //Gets the entirety of the data from this side
        public Dictionary<int, ReceivedData> GetLeftData()
        {
            return leftDataDictionary;
        }

        //Gets only the singular data entry by id
        public ReceivedData? GetLeftDataById(int id)
        {
            return leftDataDictionary.TryGetValue(id, out var data) ? data : null;
        }

        //Gets the entirety of the data from this side
        public Dictionary<int, ReceivedData> GetRightData()
        {
            return rightDataDictionary;
        }

        //Gets only the singular data entry by id
        public ReceivedData? GetRightDataById(int id)
        {
            return rightDataDictionary.TryGetValue(id, out var data) ? data : null;
        }

        //Sets the entirety of the data on this side
        public void SetLeftData(Dictionary<int, ReceivedData> data)
        {
            leftDataDictionary = data;
        }

        //Sets only the singular data entry by id
        public void SetLeftDataById(int id, ReceivedData data)
        {
            leftDataDictionary[id] = data;
        }

        //Sets the entirety of the data on this side
        public void SetRightData(Dictionary<int, ReceivedData> data)
        {
            rightDataDictionary = data;
        }

        //Sets only the singular data entry by id
        public void SetRightDataById(int id, ReceivedData data)
        {
            rightDataDictionary[id] = data; 
        }
    }

    public interface IDataService
    {
        ReceivedData? GetLeftDataById(int id);
        Dictionary<int, ReceivedData> GetLeftData();
        void SetLeftDataById(int id, ReceivedData data);
        void SetLeftData(Dictionary<int, ReceivedData> data);

        ReceivedData? GetRightDataById(int id);
        Dictionary<int, ReceivedData> GetRightData();
        void SetRightDataById(int id, ReceivedData data);
        void SetRightData(Dictionary<int, ReceivedData> data);
    }
}
