using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.Repository.DB
{
    public interface IHotelRepository
    {
        Task<Hotel> LoadAsync(string key, object sortKey);
        Task<IList<Hotel>> QueryAsync(string key, QueryOperatorEnum queryOperator, IEnumerable<string> values);
    }
}
