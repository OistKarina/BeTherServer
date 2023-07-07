using System;
using Microsoft.AspNetCore.Mvc;
using BeTherServer.Models;
using BeTherServer.Services;
using BeTherServer.Services.Utils;

namespace BeTherServer.Controllers;

[Controller]
[Route("api/[controller]")]
public class PreviousQuestionsController : Controller
{

    private readonly IPreviousQuestionService m_PreiousQuestionsLogic;

    public PreviousQuestionsController(IPreviousQuestionService i_PreiousQuestionsLogic)
    {
        m_PreiousQuestionsLogic = i_PreiousQuestionsLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPreviousQuestions(string UserName)
    {
        ResultUnit<List<PreviousQuestions>> previousQuestions = await m_PreiousQuestionsLogic.GetAllPreviousQuestions(UserName);
        try
        {
            if (previousQuestions.IsSuccess)
            {
                return Ok(previousQuestions.ReturnValue);
            }
            else
            {
                return NotFound(previousQuestions.ResultMessage);
            }
        }
        catch(Exception ex)
        {
            return StatusCode(500);
        }
    
    }



    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PreviousQuestions i_previousQuestion)
    {
        try
        {
            await m_PreiousQuestionsLogic.InsertPreviousQuestionByUser(i_previousQuestion);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    //[HttpPut("{id}")] 
    //public async Task<IActionResult> AddToPreviousQuestion(string id, [FromBody] string i_previousQuestionId)
    //{
    //    await m_mongoDBServices.AddToPreviousQuestionsAsync(id, i_previousQuestionId);
    //    return NoContent();

    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(string id)
    //{
    //    await m_mongoDBServices.DeleteAsync(id);
    //    return NoContent();

    //}
}