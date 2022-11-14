using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.Repository.DB
{
    public class HotelRepository : BaseRepository, IHotelRepository
    {
        public HotelRepository(IAmazonDynamoDB amazonDynamoDb, IDynamoDBContext dynamoDBContext) : base(amazonDynamoDb, dynamoDBContext)
        {
        }
        public async Task<Hotel> LoadAsync(string key, object sortKey)
        {
            var hotel = await dynamoDBContext.LoadAsync<Hotel>(key, sortKey);
            return hotel;//Need to do Mapping 
        }

        public async Task<IList<Hotel>> QueryAsync(string key, QueryOperatorEnum queryOperator, IEnumerable<string> values)
        {
            var op = (QueryOperator)queryOperator;
            var hotels = await dynamoDBContext.QueryAsync<Hotel>(key, op, values).GetRemainingAsync();
            return hotels;//Need to do Mapping 
        }

    }
    public enum QueryOperatorEnum
    {
        Equal = 0,
        LessThanOrEqual = 1,
        LessThan = 2,
        GreaterThanOrEqual = 3,
        GreaterThan = 4,
        BeginsWith = 5,
        Between = 6,
        Contains = 7
    }
}
