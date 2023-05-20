using BeTherServer.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
using BeTherServer.MongoContext;
using BeTherServer.Services;
using Azure;


namespace BeTherMongoDB.Services;

public class PreviousQuestionsMongoContext : BaseMongoContext<PreviousQuestions>,IPreviousQuestionDBContext
{

    private static readonly string m_collectionName = "PreviousQuestions";


    public PreviousQuestionsMongoContext(IOptions<MongoDBSettings> i_mongoDBSettings) : base(i_mongoDBSettings, m_collectionName)
    {

    }

    public async Task<List<PreviousQuestions>> GetAllPerviousQuestionsByUser(string i_username)
    {
        FilterDefinition<PreviousQuestions> filter = Builders<PreviousQuestions>.Filter.Eq("username", i_username);
        List<PreviousQuestions> response = await base.GetAllObjectsByFilter(filter);
        //List<PreviousQuestions> responseUser = await base.Collection.Find(x => x.username == i_username).ToListAsync();
        return response;
    }

    //public async Task CreateAsync(PreviousQuestions i_previousQuestion)
    //{
    //    await m_previousQuestionsCollection.InsertOneAsync(i_previousQuestion);
    //    return;
    //}

    //public async Task<List<PreviousQuestions>> GetAsync()
    //{
    //    return await m_previousQuestionsCollection.Find(new BsonDocument()).ToListAsync();
    //}

    //public async Task AddToPreviousQuestionsAsync(string i_id, string i_previousQuestionId)
    //{
    //    FilterDefinition<PreviousQuestions> filter = Builders<PreviousQuestions>.Filter.Eq("Id", i_id);
    //    UpdateDefinition<PreviousQuestions> update = Builders<PreviousQuestions>.Update.AddToSet<string>("questions_items", i_previousQuestionId);
    //    await m_previousQuestionsCollection.UpdateOneAsync(filter, update);
    //    return;
    //}

    //public async Task DeleteAsync(string i_id)
    //{
    //    FilterDefinition<PreviousQuestions> filter = Builders<PreviousQuestions>.Filter.Eq("Id", i_id);
    //    await m_previousQuestionsCollection.DeleteOneAsync(filter);
    //    return;
    //}

}
