using System;
using BeTherServer.Models;

namespace BeTherServer.Services
{
	public interface IPreviousQuestionDBContext
	{
        Task<List<PreviousQuestions>> GetAllPerviousQuestionsByUser(string i_username);
        Task InsertOneObject(PreviousQuestions i_objectToInsrtToCollection);

    }
}

