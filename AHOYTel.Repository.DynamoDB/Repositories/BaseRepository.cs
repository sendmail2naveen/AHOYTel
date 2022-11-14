using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHOYTel.Repository.DB
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public abstract class BaseRepository 
    {
        protected static IAmazonDynamoDB amazonDynamoDB;
        protected static IDynamoDBContext dynamoDBContext;

        public BaseRepository(IAmazonDynamoDB amazonDynamoDB, IDynamoDBContext dynamoDBContext)
        {
            BaseRepository.amazonDynamoDB = amazonDynamoDB;
            BaseRepository.dynamoDBContext = dynamoDBContext;
        }

        public BaseRepository(IAmazonDynamoDB amazonDynamoDb)
        {
            BaseRepository.amazonDynamoDB = amazonDynamoDb;

            dynamoDBContext = new DynamoDBContext(amazonDynamoDB);
        }
    }
}
