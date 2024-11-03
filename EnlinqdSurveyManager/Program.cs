using EnlinqdSurveyManager.Application.Commands;
using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EnlinqdDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SurveyContext")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IUpdateSurveyCommandHandler, UpdateSurveyCommandHandler>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddControllers();

            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            //#region endpoints

            ////Get Surveys
            //app.MapGet("/surveys", (SurveyDBContext context) =>
            //{
            //    return context.SurveyDefinitions.ToList();
            //}).WithName("GetSurveys");

            //SurveyDefinition testSurvey = new SurveyDefinition
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "By Naresh",
            //    Json = JsonConvert.SerializeObject("{\r\n  \"title\": \"COVID-19 Screening Form\",\r\n  \"description\": \"All fields with an asterisk (*) are required fields and must be filled out in order to process the information in strict confidentiality.\",\r\n  \"logo\": \"https://api.surveyjs.io/private/Surveys/files?name=fe375fa6-4c8c-40ab-a9c7-51a97b7ad500\",\r\n  \"questionErrorLocation\": \"bottom\",\r\n  \"logoFit\": \"cover\",\r\n  \"logoPosition\": \"right\",\r\n  \"pages\": [\r\n    {\r\n      \"name\": \"patient-info\",\r\n      \"title\": \"Patient Information\",\r\n      \"elements\": [\r\n        {\r\n          \"type\": \"panel\",\r\n          \"name\": \"full-name\",\r\n          \"title\": \"Full name\",\r\n          \"elements\": [\r\n            {\r\n              \"type\": \"text\",\r\n              \"name\": \"first-name\",\r\n              \"title\": \"First name\",\r\n              \"isRequired\": true,\r\n              \"maxLength\": 25\r\n            },\r\n            {\r\n              \"type\": \"text\",\r\n              \"name\": \"last-name\",\r\n              \"startWithNewLine\": false,\r\n              \"title\": \"Last name\",\r\n              \"isRequired\": true,\r\n              \"maxLength\": 25\r\n            }\r\n          ]\r\n        },\r\n        {\r\n          \"type\": \"panel\",\r\n          \"name\": \"personal-info\",\r\n          \"elements\": [\r\n            {\r\n              \"type\": \"text\",\r\n              \"name\": \"ssn\",\r\n              \"title\": \"Social Security number\",\r\n              \"isRequired\": true,\r\n              \"maxLength\": 9,\r\n              \"validators\": [\r\n                {\r\n                  \"type\": \"regex\",\r\n                  \"text\": \"Your SSN must be a 9-digit number.\",\r\n                  \"regex\": \"^\\\\d{9}$\"\r\n                }\r\n              ]\r\n            },\r\n            {\r\n              \"type\": \"text\",\r\n              \"name\": \"birthdate\",\r\n              \"startWithNewLine\": false,\r\n              \"title\": \"Date of Birth\",\r\n              \"isRequired\": true,\r\n              \"inputType\": \"date\"\r\n            }\r\n          ]\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"name\": \"symptoms\",\r\n      \"title\": \"Current Symptoms\",\r\n      \"elements\": [\r\n        {\r\n          \"type\": \"checkbox\",\r\n          \"name\": \"symptoms\",\r\n          \"title\": \"Have you experienced any of the following symptoms of COVID-19 within the last 48 hours?\",\r\n          \"isRequired\": true,\r\n          \"choices\": [\r\n            \"Fever or chills\",\r\n            \"New and persistent cough\",\r\n            \"Shortness of breath or difficulty breathing\",\r\n            \"Fatigue\",\r\n            \"Muscle or body aches\",\r\n            \"New loss of taste or smell\",\r\n            \"Sore throat\"\r\n          ],\r\n          \"showNoneItem\": true,\r\n          \"noneText\": \"No symptoms\"\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"name\": \"contacts\",\r\n      \"title\": \"Contacts\",\r\n      \"elements\": [\r\n        {\r\n          \"type\": \"boolean\",\r\n          \"name\": \"contacted-person-with-symptoms\",\r\n          \"title\": \"Have you been in contact with anyone in the last 14 days who is experiencing these symptoms?\"\r\n        },\r\n        {\r\n          \"type\": \"radiogroup\",\r\n          \"name\": \"contacted-covid-positive\",\r\n          \"title\": \"Have you been in contact with anyone who has since tested positive for COVID-19?\",\r\n          \"choices\": [ \"Yes\", \"No\", \"Not sure\" ]\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"name\": \"travels\",\r\n      \"title\": \"Travels\",\r\n      \"elements\": [\r\n        {\r\n          \"type\": \"boolean\",\r\n          \"name\": \"travelled\",\r\n          \"title\": \"Have you travelled abroad in the last 14 days?\"\r\n        },\r\n        {\r\n          \"type\": \"text\",\r\n          \"name\": \"travel-destination\",\r\n          \"visibleIf\": \"{travelled} = true\",\r\n          \"title\": \"Where did you go?\"\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"name\": \"tests\",\r\n      \"title\": \"Tests\",\r\n      \"elements\": [\r\n        {\r\n          \"type\": \"boolean\",\r\n          \"name\": \"tested-covid-positive\",\r\n          \"title\": \"Have you tested positive for COVID-19 in the past 10 days?\"\r\n        },\r\n        {\r\n          \"type\": \"boolean\",\r\n          \"name\": \"awaiting-covid-test\",\r\n          \"title\": \"Are you currently awaiting results from a COVID-19 test?\"\r\n        },\r\n        {\r\n          \"type\": \"paneldynamic\",\r\n          \"name\": \"emergency-contacts\",\r\n          \"title\": \"Emergency Contacts\",\r\n          \"description\": \"If possible, it's best to specify at least TWO emergency contacts.\",\r\n          \"panelsState\": \"firstExpanded\",\r\n          \"confirmDelete\": true,\r\n          \"panelAddText\": \"Add a new contact person\",\r\n          \"visibleIf\": \"(({tested-covid-positive} = true or {contacted-covid-positive} = 'Yes') or ({symptoms} notempty and {symptoms} notcontains 'none'))\",\r\n          \"isRequired\": true,\r\n          \"templateElements\": [\r\n            {\r\n              \"type\": \"text\",\r\n              \"name\": \"emergency-first-name\",\r\n              \"title\": \"First name\"\r\n            },\r\n            {\r\n              \"type\": \"text\",\r\n              \"name\": \"emergency-last-name\",\r\n              \"startWithNewLine\": false,\r\n              \"title\": \"Last name\"\r\n            },\r\n            {\r\n              \"type\": \"text\",\r\n              \"name\": \"emergency-relationship\",\r\n              \"title\": \"Relationship\"\r\n            },\r\n            {\r\n              \"type\": \"text\",\r\n              \"name\": \"emergency-phone\",\r\n              \"startWithNewLine\": false,\r\n              \"title\": \"Phone number\",\r\n              \"inputType\": \"tel\"\r\n            }\r\n          ]\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"name\": \"finalization\",\r\n      \"title\": \"Miscellaneous\",\r\n      \"elements\": [\r\n        {\r\n          \"type\": \"comment\",\r\n          \"name\": \"additional-info\",\r\n          \"title\": \"Additional information\"\r\n        },\r\n        {\r\n          \"type\": \"text\",\r\n          \"name\": \"date\",\r\n          \"title\": \"Date\",\r\n          \"inputType\": \"date\"\r\n        },\r\n        {\r\n          \"type\": \"signaturepad\",\r\n          \"name\": \"signature\",\r\n          \"startWithNewLine\": false,\r\n          \"title\": \"Signature\"\r\n        }\r\n      ]\r\n    }\r\n  ],\r\n  \"completeText\": \"Submit\",  \r\n  \"showPreviewBeforeComplete\": \"showAnsweredQuestions\",\r\n  \"showQuestionNumbers\": false,\r\n  \"widthMode\": \"static\",\r\n  \"width\": \"1000px\"\r\n};")
            //};

            //app.MapPost("/add-survey", (SurveyDefinition survey, SurveyDBContext context) =>
            //{
            //    context.SurveyDefinitions.Add(testSurvey);
            //    context.Add(survey);
            //    context.SaveChanges();
            //}).WithName("AddSurvey");
            //#endregion endpoints

            app.Run();
        }
    }
}