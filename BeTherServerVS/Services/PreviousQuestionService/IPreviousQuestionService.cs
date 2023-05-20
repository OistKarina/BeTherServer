using System;
using BeTherServer.Models;
using BeTherServer.Services.Utils;

namespace BeTherServer.Services
{
	public interface IPreviousQuestionService
	{
        Task<ResultUnit<List<PreviousQuestions>>> GetAllPreviousQuestions(string i_username);
        Task InsertPreviousQuestionByUser(PreviousQuestions i_PreviousQuestionToInsert);
    }
}

