// See https://aka.ms/new-console-template for more information
using Figgle.Fonts;

using Spectre.Console;
using Survay.Contracts.ServiceContracts;
using Survay.Domain.Entities;
using Survay.InMemory;
using Survay.Services;
using System;
using static Azure.Core.HttpHeader;


ILoginService _login = new LoginService();
IPollService _poll = new PollService();
IQuestionService _question =new QuestionService();
IAnswerService _answer = new AnswerService();
IPoll_NUserService _pollNUser= new Poll_NUserService();
IVoteService _vote =new VoteService();
while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(FiggleFonts.Standard.Render("Survay"));
    Console.ResetColor();
    var select = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title("[white]Select an option[/]")
                   .HighlightStyle("yellow")
                   .AddChoices(new[] { "Login", "Exit" })
           );
    try
    {
        switch (select)
        {
            case "Login":
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(FiggleFonts.Standard.Render("Login"));
                    Console.ResetColor();
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    var result = _login.Login(username, password);
                    if (result)
                    {

                        if (InMemoryDb.CurrentUser.Role == "Admin")
                        {
                            AdminMenue();
                        }
                        else if (InMemoryDb.CurrentUser.Role == "Normal")
                        {
                            NormalMenue();
                        }
                        

                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Login Faild \nPassword Or Username wasnot correct.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                }
                break;
            case "Exit":
                {
                    Environment.Exit(0);
                }
                break;
        }

    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
        Console.ReadKey();

    }

}

void AdminMenue()
{
    while (InMemoryDb.IsAthenticate())
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(FiggleFonts.Standard.Render("Admin Menue"));
        Console.ResetColor();
        var select = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .Title("[white]Select an option[/]")
                       .HighlightStyle("yellow")
                       .AddChoices(new[] { "Add Poll","Show All Polls","Delete Poll","Show Result", "Logout" })
                        );

        try
        {
            switch (select)
            {
                case "Add Poll":
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(FiggleFonts.Standard.Render("Add Poll"));
                        Console.ResetColor();

                        Console.Write("Enter the total number of questions: ");
                        int totalquestions = Int32.Parse(Console.ReadLine());
                        Console.Write("Enter Title of the survay: ");
                        string pollTitle = Console.ReadLine();
                        int pollId = _poll.AddPoll(InMemoryDb.CurrentUser.Id, pollTitle, totalquestions);
                        for (int i = 1; i <= totalquestions; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"Enter Question{i} text: ");
                            Console.ResetColor();
                            string Question = Console.ReadLine();
                            int qId = _question.AddQuestion(Question, pollId, i);
                            for (int j = 1; j <= 4; j++)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"Enter Answer text {j}: ");
                                Console.ResetColor();
                                string answer = Console.ReadLine();
                                bool addAnswer = _answer.AddAnswer(qId, answer, j);
                                if (addAnswer)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Item Added");
                                    Console.ResetColor();
                                }

                            }


                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Poll Created");
                        Console.ResetColor();
                        Console.ReadKey();


                    }
                    break;
                case "Show All Polls":
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(FiggleFonts.Standard.Render("Show All Polls"));
                        Console.ResetColor();
                        var list = _poll.GetAlPollsThatCreateByCurrentUser(InMemoryDb.CurrentUser.Id);

                        var table = new Table()
                        .Title("Polls")
.AddColumn("Id")
.AddColumn("Title")
.AddColumn("CreatedBy")
.Border(TableBorder.Square)
.Centered();
                        foreach (var name in list)
                        {
                            table.AddRow(name.Id.ToString(), name.Title.ToString(), name.CreatedBy.ToString());
                            table.UseSafeBorder = true;
                            table.ShowRowSeparators = true;
                            table.SquareBorder();


                        }

                        AnsiConsole.Write(table);
                        Console.ReadKey();
                    }
                    break;
                case "Delete Poll":
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(FiggleFonts.Standard.Render("Delete Poll"));
                        Console.ResetColor();
                        var list = _poll.GetAlPollsThatCreateByCurrentUser(InMemoryDb.CurrentUser.Id);

                        var pollMap = new Dictionary<string, int>();

                        foreach (var poll in list)
                        {
                            string display = $"{poll.Title}";
                            pollMap[display] = poll.Id;
                        }
                        pollMap.Add("Exit", 0);
                        var selectitem = AnsiConsole.Prompt(
                  new SelectionPrompt<string>()
                      .Title("[white]Select an option[/]")
                      .HighlightStyle("red")
                      .AddChoices(pollMap.Keys)
                       );

                        int pollId = pollMap[selectitem];

                        switch (pollId)
                        {
                            case 0:
                                break ;
                            default:
                                {
                                    var questionId=_question.GetQuestionId(pollId);
                                    var answerId = _answer.GetAnswerId(questionId);
                                    var result1=   _vote.DeleteVote(answerId);
                                    var result2= _answer.DeleteAnswers(questionId);
                                    var result3= _question.DeleteQuestions(pollId);
                                    var result4=  _pollNUser.DeletePollForUser(pollId);
                                    var result5=  _poll.DeletePoll(pollId);
                                    if (result1 && result2 && result3 &&  result4 && result5)
                                    {
                                        Console.WriteLine("Poll Deleted");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Poll Dont Deleted\nsomthing is wrong");
                                        Console.ReadKey();
                                    }

                                }
                                break;
                        }

                        }
                    break;
                case "Show Result":
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(FiggleFonts.Standard.Render("Show Result"));
                        Console.ResetColor();
                        var list = _poll.GetAlPollsThatCreateByCurrentUser(InMemoryDb.CurrentUser.Id);

                        var pollMap = new Dictionary<string, int>();

                        foreach (var poll in list)
                        {
                            string display = $"{poll.Title}";
                            pollMap[display] = poll.Id;
                        }

                        var selectitem = AnsiConsole.Prompt(
                  new SelectionPrompt<string>()
                      .Title("[white]Select an option[/]")
                      .HighlightStyle("green")
                      .AddChoices(pollMap.Keys)
                       );

                        int pollId = pollMap[selectitem];

                        switch (pollId)
                        {

                            default:
                                {
                                    Console.WriteLine($"{selectitem}");
                                    var results = _poll.ShowResults(pollId);
                                    foreach (var result in results)
                                    {
                                        Console.WriteLine($"{result.QuestionNumber}.{result.QuestionText}");

                                        var answers=result.Answers;
                                        var table = new Table()
                         .Title("Results")
 .AddColumn("Number")
 .AddColumn("Text")
 .AddColumn("Votes")
 .Border(TableBorder.Rounded)
 .Centered();
                                        foreach (var name in answers)
                                        {
                                            table.AddRow(name.Number.ToString(), name.Text.ToString(), name.Vote.ToString());
                                            table.UseSafeBorder = true;
                                            table.ShowRowSeparators = true;
                                            table.RoundedBorder();


                                        }

                                        AnsiConsole.Write(table);
                                        
                                    }
                                    Console.ReadKey();
                                }
                                break;
                        }
                    }
                        break;
                case "Logout":
                    InMemoryDb.CurrentUser = null;
                    break;

            }
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            Console.ReadKey();

        }


    }
}

void NormalMenue()
{
    while (InMemoryDb.IsAthenticate())
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(FiggleFonts.Standard.Render("Normal User Menue"));
        Console.ResetColor();
        var select = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .Title("[white]Select an option[/]")
                       .HighlightStyle("yellow")
                       .AddChoices(new[] { "Vote", "Logout" })
                        );

        try
        {
            switch (select)
            {
                case "Vote":
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(FiggleFonts.Standard.Render("Vote"));
                        Console.ResetColor();

                        var list = _poll.ShowPolls();
                        
                        var pollMap = new Dictionary<string, int>();

                        foreach (var poll in list)
                        {
                            string display = $"{poll.Title}";
                            pollMap[display] = poll.Id;
                        }
                        pollMap.Add("Exit", 0);
                        
                        var selectitem = AnsiConsole.Prompt(
                  new SelectionPrompt<string>()
                      .Title("[white]Select an option[/]")
                      .HighlightStyle("green")
                      .AddChoices(pollMap.Keys)
                       );

                        int polldId = pollMap[selectitem];

                        switch (polldId)
                        {
                            case 0:
                                break;

                            default:
                                Console.WriteLine($"{selectitem}");
                                bool doesVoted=_pollNUser.DoesUserVoted(polldId, InMemoryDb.CurrentUser.Id);
                                if (!doesVoted)
                                {

                                    var questionList= _question.ShowQuestions(polldId);
                                    foreach (var question in questionList)
                                    {
                                        Console.WriteLine($"{question.QuestionNumber}.{question.Text}");
                                        var answerList= _answer.GetANswerByQuestion(question.Id);
                                        var answerMap=new Dictionary<string, int>();
                                        foreach (var item in answerList)
                                        {
                                            string display = $"{item.Number}.{item.Text}";
                                            answerMap[display] = item.Id;
                                        }
                                        var selectAnswer = AnsiConsole.Prompt(
                  new SelectionPrompt<string>()
                      .Title("[white]Select an option[/]")
                      .HighlightStyle("green")
                      .AddChoices(answerMap.Keys)
                       );

                                        int answerId = answerMap[selectAnswer];
                                        
                                        var addvote = _vote.AddVote(InMemoryDb.CurrentUser.Id, answerId);
                                        if (addvote)
                                        {
                                            
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("vote genarated");
                                                Console.ResetColor();
                                            
                                        }
                                      
                                    }
                                    if (_pollNUser.CreatePollForUser(polldId, InMemoryDb.CurrentUser.Id))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                       
                                        Console.WriteLine("\nYou voted to all questions.");
                                        Console.ResetColor();
                                        Console.ReadKey();

                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\nOperation Faild.");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                   

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("you voted this poll recently");
                                    Console.ResetColor();
                                    Console.ReadKey();

                                }
                                
                                break;

                                
                        }
                    }
                    break;
                
                case "Logout":
                    InMemoryDb.CurrentUser = null;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            Console.ReadKey();

        }
    }
}



