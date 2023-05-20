using BeTherServer.Models;
using Microsoft.Extensions.Options;
using BeTherServer.Services.Utils;
using BeTherServer.Services;


namespace BeTherMongoDB.Services;

public class PreviousQuestionsService :IPreviousQuestionService
{

    IPreviousQuestionDBContext m_PreviousQuestionDBSContext;

    public PreviousQuestionsService(IPreviousQuestionDBContext i_PreviousQuestionDBSContext)
    {
        m_PreviousQuestionDBSContext = i_PreviousQuestionDBSContext;
    }

    public async Task<ResultUnit<List<PreviousQuestions>>> GetAllPreviousQuestions(string i_username)
    {
        ResultUnit<List<PreviousQuestions>> result = new ResultUnit<List<PreviousQuestions>>();
        List<PreviousQuestions> response = await m_PreviousQuestionDBSContext.GetAllPerviousQuestionsByUser(i_username);
        if(response is null)
        {
            result.IsSuccess = false;
            result.ResultMessage = "No previous questions";
        }
        else
        {
            result.ReturnValue = response;
        }

        return result;
    }

    public async Task InsertPreviousQuestionByUser(PreviousQuestions i_PreviousQuestionToInsert)
    {
        await m_PreviousQuestionDBSContext.InsertOneObject(i_PreviousQuestionToInsert);
    }

}
